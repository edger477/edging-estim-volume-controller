using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;
//using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolumeController.Services
{
    internal class VolumeService
    {
        //System.Media.SystemSound()
        public IEnumerable<CoreAudioDevice> GetAvailableDevices()
        {
            return new CoreAudioController().GetPlaybackDevices(DeviceState.Active);
        }
        public CoreAudioDevice GetDefaultDevice()
        {
            return new CoreAudioController().GetDefaultDevice(AudioSwitcher.AudioApi.DeviceType.Playback, AudioSwitcher.AudioApi.Role.Multimedia);
        }

        public void SetVolume(CoreAudioDevice device, double volume)
        {
            device.Volume = volume;
        }
    }
}
