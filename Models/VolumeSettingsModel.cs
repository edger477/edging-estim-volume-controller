using System.ComponentModel;

namespace VolumeController.Models
{
    public class VolumeSettingsModel : INotifyPropertyChanged
    {
        private double currentVolume;

        public int Max { get; set; } = 100;
        public int Min { get; set; } = 75;
        public int ChangeFrequency { get; set; } = 10;
        public double ChangeStepDown { get; set; } = 2f;
        public double ChangeStepUp { get; set; } = 0.5f;
        public double CurrentVolume
        {
            get => currentVolume; set
            {
                currentVolume = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentVolume)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
