using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Storage.Streams;

namespace VolumeController.Services
{
    public class HeartRateService
    {
        public enum ContactSensorStatus
        {
            NotSupported,
            NotSupported2,
            NoContact,
            Contact
        }

        [Flags]
        public enum HeartRateFlags
        {
            None = 0,
            IsShort = 1,
            HasEnergyExpended = 1 << 3,
            HasRRInterval = 1 << 4,
        }

        public class HeartRateReading
        {
            public HeartRateFlags Flags { get; set; }
            public ContactSensorStatus Status { get; set; }
            public int BeatsPerMinute { get; set; }
            public int? EnergyExpended { get; set; }
            public int[] RRIntervals { get; set; }
            public bool IsError { get; set; }
            public string Error { get; set; }

            public DateTime Timestamp { get; } = DateTime.Now;
        }

        public class HeartRateSensor
        {
            public string Name { get; set; }
            public ulong Address { get; set; }
        }

        private byte[] _buffer;

        private ulong? _selectedDeviceAddress { get; set; }

        public List<ulong> EnumeratedDevices { get; set; } = new List<ulong>();
        public ConcurrentDictionary<ulong, string> HeartRateReaders { get; set; } = new ConcurrentDictionary<ulong, string>();

        GattCharacteristic monitoredCharacteristic;
        BluetoothLEAdvertisementWatcher Watcher { get; set; }
        public void Start()
        {
            Watcher = new BluetoothLEAdvertisementWatcher()
            {
                ScanningMode = BluetoothLEScanningMode.Active
            };
            Watcher.Received += Watcher_Received;
            Watcher.Stopped += Watcher_Stopped;
            Watcher.Start();
        }

        public List<HeartRateSensor> GetAvailableDevices()
        {
            return HeartRateReaders.Select(i => new HeartRateSensor() { Address = i.Key, Name = i.Value }).ToList();
        }

        public delegate void HeartRateUpdateHandler(object sender, HeartRateReading e);

        public event HeartRateUpdateHandler HeartRateUpdated;

        public void Subscribe(ulong address, HeartRateUpdateHandler heartRateUpdateHandler)
        {
            _selectedDeviceAddress = address;
            monitoredCharacteristic = null;

            HeartRateUpdated += heartRateUpdateHandler;
            Watcher.ScanningMode = BluetoothLEScanningMode.Passive;
        }
        public void UnSubscribe(ulong address, HeartRateUpdateHandler heartRateUpdateHandler)
        {
            if (_selectedDeviceAddress == address)
            {
                _selectedDeviceAddress = null;
                if (monitoredCharacteristic != null) {
                    monitoredCharacteristic.ValueChanged -= Characteristic_ValueChanged;
                    monitoredCharacteristic = null;
                }
            }

            HeartRateUpdated -= heartRateUpdateHandler;
            EnumeratedDevices.Clear();
            HeartRateReaders.Clear();
            Watcher.ScanningMode = BluetoothLEScanningMode.Active;
        }

        private async void Watcher_Received(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementReceivedEventArgs args)
        {
            if (_selectedDeviceAddress == null)
            {
                if (!EnumeratedDevices.Contains(args.BluetoothAddress))
                {
                    EnumeratedDevices.Add(args.BluetoothAddress);
                    BluetoothLEDevice bluetoothLeDevice = await BluetoothLEDevice.FromBluetoothAddressAsync(args.BluetoothAddress);
                    if (bluetoothLeDevice == null) return;
                    GattDeviceServicesResult result = await bluetoothLeDevice.GetGattServicesAsync();
                    if (result.Status == GattCommunicationStatus.Success)
                    {
                        var services = result.Services;
                        foreach (var service in services)
                        {
                            if (!service.Uuid.ToString().StartsWith("0000180d"))
                            {
                                continue;
                            }
                            GattCharacteristicsResult characteristicsResult = await service.GetCharacteristicsAsync();
                            if (characteristicsResult.Status == GattCommunicationStatus.Success)
                            {
                                var characteristics = characteristicsResult.Characteristics;
                                foreach (var characteristic in characteristics)
                                {
                                    if (!characteristic.Uuid.ToString().StartsWith("00002a37-0000-1000-8000-00805f9b34fb"))
                                    {
                                        continue;
                                    }
                                    GattCharacteristicProperties properties = characteristic.CharacteristicProperties;
                                    if (properties.HasFlag(GattCharacteristicProperties.Notify))
                                    {
                                        HeartRateReaders.TryAdd(args.BluetoothAddress, args.Advertisement.LocalName);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
                return;
            }
            if (args.BluetoothAddress == _selectedDeviceAddress)
            {
                if (monitoredCharacteristic != null) return;
                BluetoothLEDevice bluetoothLeDevice = await BluetoothLEDevice.FromBluetoothAddressAsync(args.BluetoothAddress);
                GattDeviceServicesResult result = await bluetoothLeDevice.GetGattServicesAsync();
                if (result.Status == GattCommunicationStatus.Success)
                {
                    var services = result.Services;
                    foreach (var service in services)
                    {
                        if (!service.Uuid.ToString().StartsWith("0000180d"))
                        {
                            continue;
                        }
                        GattCharacteristicsResult characteristicsResult = await service.GetCharacteristicsAsync();
                        if (characteristicsResult.Status == GattCommunicationStatus.Success)
                        {
                            var characteristics = characteristicsResult.Characteristics;
                            foreach (var characteristic in characteristics)
                            {
                                if (!characteristic.Uuid.ToString().StartsWith("00002a37-0000-1000-8000-00805f9b34fb"))
                                {
                                    continue;
                                }
                                GattCharacteristicProperties properties = characteristic.CharacteristicProperties;
                                if (properties.HasFlag(GattCharacteristicProperties.Notify))
                                {
                                    monitoredCharacteristic = characteristic;
                                    monitoredCharacteristic.ValueChanged += Characteristic_ValueChanged;
                                    GattWriteResult status = await characteristic.WriteClientCharacteristicConfigurationDescriptorWithResultAsync(GattClientCharacteristicConfigurationDescriptorValue.Notify);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Characteristic_ValueChanged(GattCharacteristic sender, GattValueChangedEventArgs args)
        {
            var buffer = args.CharacteristicValue;
            if (buffer.Length == 0) return;

            var byteBuffer = Interlocked.Exchange(ref _buffer, null)
                ?? new byte[buffer.Length];

            if (byteBuffer.Length != buffer.Length)
            {
                byteBuffer = new byte[buffer.Length];
            }

            try
            {
                using (var reader = DataReader.FromBuffer(buffer))
                {
                    reader.ReadBytes(byteBuffer);
                }

                var readingValue = ReadBuffer(byteBuffer, (int)buffer.Length);

                if (readingValue == null)
                {
                    Console.WriteLine($"Buffer was too small. Got {buffer.Length}.");
                    return;
                }

                var reading = readingValue;
                HeartRateUpdated?.Invoke(this, reading);

                // HeartRateUpdated?.Invoke(reading);
            }
            finally
            {
                Volatile.Write(ref _buffer, byteBuffer);
            }
        }
        private void Watcher_Stopped(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementWatcherStoppedEventArgs args)
        {
            ;
        }


        private static HeartRateReading ReadBuffer(byte[] buffer, int length)
        {
            if (length == 0) return null;

            var ms = new MemoryStream(buffer, 0, length);
            var flags = (HeartRateFlags)ms.ReadByte();
            var isshort = flags.HasFlag(HeartRateFlags.IsShort);
            var contactSensor = (ContactSensorStatus)(((int)flags >> 1) & 3);
            var hasEnergyExpended = flags.HasFlag(HeartRateFlags.HasEnergyExpended);
            var hasRRInterval = flags.HasFlag(HeartRateFlags.HasRRInterval);
            var minLength = isshort ? 3 : 2;

            if (buffer.Length < minLength) return null;

            var reading = new HeartRateReading
            {
                Flags = flags,
                Status = contactSensor,
                BeatsPerMinute = isshort ? ReadUInt16(ms) : ms.ReadByte()
            };

            if (hasEnergyExpended)
            {
                reading.EnergyExpended = ReadUInt16(ms);
            }

            if (hasRRInterval)
            {
                var rrvalueCount = (buffer.Length - ms.Position) / sizeof(ushort);
                var rrvalues = new int[rrvalueCount];
                for (var i = 0; i < rrvalueCount; ++i)
                {
                    rrvalues[i] = ReadUInt16(ms);
                }

                reading.RRIntervals = rrvalues;
            }

            return reading;
        }


        private static ushort ReadUInt16(Stream stream)
        {
            return (ushort)(stream.ReadByte() | (stream.ReadByte() << 8));
        }
    }
}
