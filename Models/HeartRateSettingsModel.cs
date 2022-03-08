using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Drawing;

namespace VolumeController.Models
{
    public class HeartRateSettingsModel : INotifyPropertyChanged
    {
        private int _currentHeartRate;
        private int heartRateAverage;
        class Reading
        {
            public Reading(int bpm)
            {
                this.BPM = bpm;
            }
            public int BPM;
            public DateTime Timestamp = DateTime.Now;
        }

        private ConcurrentQueue<Reading> _heartRateReadingQueue = new ConcurrentQueue<Reading>();

        public HeartRateSettingsModel()
        {
            Max = 135;
            Min = 75;
            Desired = 115;
            AverageWindow = 5;
        }

        public int Max { get; set; }
        public int Min { get; set; }
        public int Desired { get; set; }
        public int AverageWindow { get; set; }
        public int CurrentHeartRate
        {
            get => _currentHeartRate; set
            {
                _currentHeartRate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentHeartRate)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentHeartRateColor)));

                _heartRateReadingQueue.Enqueue(new Reading(value));
                if (_heartRateReadingQueue.Count >= AverageWindow)
                {
                    List<Reading> results = new List<Reading>();
                    Reading result = null;
                    while (_heartRateReadingQueue.TryDequeue(out result) && !_heartRateReadingQueue.IsEmpty)
                    {
                        results.Add(result);
                    }
                    var avg = results.Average(r => r.BPM);
                    HeartRateAverage = Convert.ToInt32(Math.Round(avg));
                }
            }
        }

        public Color CurrentHeartRateColor
        {
            get
            {
                var color = CurrentHeartRate < Desired ? Color.Green : (CurrentHeartRate < Max ? Color.Yellow : Color.Red);
                return color;
            }
        }

        public int HeartRateAverage
        {
            get => heartRateAverage; set
            {
                heartRateAverage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HeartRateAverage)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HeartRateAverageColor)));
            }
        }
        public Color HeartRateAverageColor
        {
            get
            {
                var color = HeartRateAverage < Desired ? Color.Green : (HeartRateAverage < Max ? Color.Yellow : Color.Red);
                return color;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
