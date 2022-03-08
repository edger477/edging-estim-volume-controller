using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VolumeController.Models;
using VolumeController.Services;

namespace VolumeController
{
    public partial class VolumeController : Form
    {
        private VolumeService _service;
        private HeartRateService _heartRateService;
        private int currentHeartRate;
        AudioSwitcher.AudioApi.CoreAudio.CoreAudioDevice selectedDevice;
        private VolumeSettingsModel volumeSettings = new VolumeSettingsModel();
        private HeartRateSettingsModel heartRateSettings = new HeartRateSettingsModel();


        public VolumeController()
        {
            InitializeComponent();
            _service = new VolumeService();
            _heartRateService = new HeartRateService();
            _heartRateService.Start();
            var devices = _service.GetAvailableDevices();

            cbOutputDevice.Items.AddRange(devices.ToArray());
            cbOutputDevice.DisplayMember = "FullName";
            _availableSensors.DisplayMember = "Name";
            var defaultDeviceId = _service.GetDefaultDevice().Id;
            cbOutputDevice.SelectedItem = devices.Single(d => d.Id == defaultDeviceId);

            numMaxVol.DataBindings.Add(nameof(numMaxVol.Value), volumeSettings, nameof(volumeSettings.Max), false, DataSourceUpdateMode.OnPropertyChanged);
            numMinVol.DataBindings.Add(nameof(numMinVol.Value), volumeSettings, nameof(volumeSettings.Min), false, DataSourceUpdateMode.OnPropertyChanged);
            numChangeFreq.DataBindings.Add(nameof(numChangeFreq.Value), volumeSettings, nameof(volumeSettings.ChangeFrequency), false, DataSourceUpdateMode.OnPropertyChanged);
            numChgStepDown.DataBindings.Add(nameof(numChgStepDown.Value), volumeSettings, nameof(volumeSettings.ChangeStepDown), false, DataSourceUpdateMode.OnPropertyChanged);
            numChgStepUp.DataBindings.Add(nameof(numChgStepUp.Value), volumeSettings, nameof(volumeSettings.ChangeStepUp), false, DataSourceUpdateMode.OnPropertyChanged);
            label_currentVolume.DataBindings.Add(nameof(label_currentVolume.Text), volumeSettings, nameof(volumeSettings.CurrentVolume));

            numHRMax.DataBindings.Add(nameof(numHRMax.Value), heartRateSettings, nameof(heartRateSettings.Max), false, DataSourceUpdateMode.OnPropertyChanged);
            numHRMin.DataBindings.Add(nameof(numHRMin.Value), heartRateSettings, nameof(heartRateSettings.Min), false, DataSourceUpdateMode.OnPropertyChanged);
            numHRDesired.DataBindings.Add(nameof(numHRDesired.Value), heartRateSettings, nameof(heartRateSettings.Desired), false, DataSourceUpdateMode.OnPropertyChanged);
            numHRAverageWindow.DataBindings.Add(nameof(numHRAverageWindow.Value), heartRateSettings, nameof(heartRateSettings.AverageWindow), false, DataSourceUpdateMode.OnPropertyChanged);
            label_heartRate.DataBindings.Add(nameof(label_heartRate.Text), heartRateSettings, nameof(heartRateSettings.CurrentHeartRate));
            label_heartRate.DataBindings.Add(nameof(label_heartRate.ForeColor), heartRateSettings, nameof(heartRateSettings.CurrentHeartRateColor));
            label_heartRateAverage.DataBindings.Add(nameof(label_heartRateAverage.Text), heartRateSettings, nameof(heartRateSettings.HeartRateAverage));
            label_heartRateAverage.DataBindings.Add(nameof(label_heartRateAverage.ForeColor), heartRateSettings, nameof(heartRateSettings.HeartRateAverageColor));

            heartRateSettings.PropertyChanged += HeartRateSettings_PropertyChanged;
        }

        private void HeartRateSettings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(heartRateSettings.HeartRateAverage))
            {
                if (heartRateSettings.Max <= heartRateSettings.HeartRateAverage)
                {
                    volumeSettings.CurrentVolume = volumeSettings.Min;
                }
                else if (heartRateSettings.Desired < heartRateSettings.HeartRateAverage)
                {
                    volumeSettings.CurrentVolume = Math.Max(volumeSettings.Min, volumeSettings.CurrentVolume - volumeSettings.ChangeStepDown);
                }
                else if (heartRateSettings.Desired > heartRateSettings.HeartRateAverage)
                {
                    volumeSettings.CurrentVolume = Math.Min(volumeSettings.Max, volumeSettings.CurrentVolume + volumeSettings.ChangeStepUp);
                }


                selectedDevice = (cbOutputDevice as ComboBox).SelectedItem as AudioSwitcher.AudioApi.CoreAudio.CoreAudioDevice;
                selectedDevice.Volume = volumeSettings.CurrentVolume;
            }
        }

        private void numMaxVol_ValueChanged(object sender, EventArgs e)
        {
            //_service.SetVolume(cbOutputDevice.SelectedItem as AudioSwitcher.AudioApi.CoreAudio.CoreAudioDevice, Convert.ToDouble((sender as NumericUpDown).Value));
        }

        private void selectSensor(object sender, EventArgs e)
        {
            var item = (HeartRateService.HeartRateSensor)_availableSensors.SelectedItem;
            _heartRateService.Subscribe(item.Address, HeartRateUpdated);

            _availableSensors.Enabled = false;

            selectSensorBtn.Visible = false;
            btn_ResetSensor.Visible = true;
        }

        private void HeartRateUpdated(object sender, HeartRateService.HeartRateReading e)
        {
            BeginInvoke((Action)(() =>
            {
                heartRateSettings.CurrentHeartRate = e.BeatsPerMinute;
            }));
        }

        private void btn_ResetSensor_Click(object sender, EventArgs e)
        {
            var item = (HeartRateService.HeartRateSensor)_availableSensors.SelectedItem;
            _heartRateService.UnSubscribe(item.Address, HeartRateUpdated);

            _availableSensors.Enabled = true;

            selectSensorBtn.Visible = true;
            btn_ResetSensor.Visible = false;
        }


        private void _availableSensors_MouseClick(object sender, MouseEventArgs e)
        {
            _availableSensors.Items.Clear();
            var devices = _heartRateService.GetAvailableDevices();
            _availableSensors.Items.AddRange(devices.ToArray());
            btn_ResetSensor.Visible = false;
        }


        private void cbOutputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedDevice = (sender as ComboBox).SelectedItem as AudioSwitcher.AudioApi.CoreAudio.CoreAudioDevice;

            if (selectedDevice != null)
            {
                volumeSettings.CurrentVolume = selectedDevice.Volume;
            }
        }

    }
}
