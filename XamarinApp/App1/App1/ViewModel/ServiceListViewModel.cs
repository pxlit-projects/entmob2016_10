using App1.Model;
using App1.Services;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.ViewModel
{
    public class ServiceListViewModel : INotifyPropertyChanged
    {
        private IDevice device;
        private IList<ICharacteristic> _configCharacteristics = new List<ICharacteristic>();
        private IList<ICharacteristic> _characteristics = new List<ICharacteristic>();
        private double _temperatureData;

        public event PropertyChangedEventHandler PropertyChanged;

        public ServiceListViewModel()
        {           
            MessagingCenter.Subscribe<DeviceItem>(this, "connectdevice", (arg) =>
            {
                this.device = arg.Device;
                GetServices();
            });
            MessagingCenter.Send("true", "senddevice");
        }
        
        private async void GetServices()
        {
            await GetTempService();
            await GetMovementService();           
            //await TurnServiceOn();
            //readTemp();
        }
        
        private async Task GetTempService()
        {
            try
            {
                IService service = await device.GetServiceAsync(Guid.Parse("f000aa00-0451-4000-b000-000000000000"));
                ICharacteristic dataCharacteristic = await service.GetCharacteristicAsync(Guid.Parse("f000aa01-0451-4000-b000-000000000000"));
                ICharacteristic configCharacteristic = await service.GetCharacteristicAsync(Guid.Parse("f000aa02-0451-4000-b000-000000000000"));
                //_configCharacteristics.Add(configCharacteristic);
                //_characteristics.Add(dataCharacteristic);

                await configCharacteristic.WriteAsync(new byte[] { 0x01 });

                dataCharacteristic.ValueUpdated += (o, args) =>
                {
                    byte[] bytes = args.Characteristic.Value;
                    _temperatureData = AmbientTemperature(bytes);
                    onPropertyChanged(nameof(TemperatureData));
                };
                await dataCharacteristic.StartUpdatesAsync();

            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error getTempService: " + ex);
            }
        }

        private async Task TurnServiceOn()
        {
            try
            {
                for (int i = 0; i < _configCharacteristics.Count; i++)
                {               
                    var characteristic = _configCharacteristics[i];
                    await characteristic.WriteAsync(new byte[] { 0x01 });

                }
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error TurnServiceOn :" + ex);
            }
        }


        private async void readTemp()
        {
            ICharacteristic characteristic = null;
            for (int i = 0; i < _characteristics.Count; i++)
            {
                characteristic = _characteristics[i];
            }

            characteristic.ValueUpdated += (o, args) =>
            {
                byte[] bytes = args.Characteristic.Value;             
                _temperatureData = AmbientTemperature(bytes);
                onPropertyChanged(nameof(TemperatureData));
            };
            await characteristic.StartUpdatesAsync();
        }

        public double TemperatureData
        {
            get { return _temperatureData; }
            set
            {
                _temperatureData = value;
                onPropertyChanged(nameof(TemperatureData));
            }
        }

        public double AmbientTemperature(byte[] bytes)
        {

            var ambientTemp = BitConverter.ToUInt16(bytes, 2) / 128.0;
            return ambientTemp;
        }

        private void onPropertyChanged(string temperature)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(temperature));
        }


        private async Task GetMovementService()
        {
            try
            {
                IService service = await device.GetServiceAsync(Guid.Parse("f000aa80-0451-4000-b000-000000000000"));
                ICharacteristic dataCharacteristic = await service.GetCharacteristicAsync(Guid.Parse("f000aa81-0451-4000-b000-000000000000"));
                ICharacteristic configCharacteristic = await service.GetCharacteristicAsync(Guid.Parse("f000aa82-0451-4000-b000-000000000000"));
                // _configCharacteristics.Add(configCharacteristic);
                //_characteristics.Add(dataCharacteristic);
                await configCharacteristic.WriteAsync(new byte[] { 0x7F, 0x00 });
                _gyro = new Gyroscope();
                dataCharacteristic.ValueUpdated += (o, args) =>
                {
                    
                    byte[] bytes = args.Characteristic.Value;

                    _gyro.X = MovementService.Gyro(bytes, "x");
                    _gyro.Y = MovementService.Gyro(bytes, "y");
                    _gyro.Z = MovementService.Gyro(bytes, "z");
                    onPropertyChanged(nameof(Gyro));
                };
                await dataCharacteristic.StartUpdatesAsync();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error GetMovementService: " + ex);
            }
        }

        private async Task GetGyroscoopData()
        {
            //morgen verder
        }

        private async Task GetMagnetometerService()
        {
            try
            {
                IService service = await device.GetServiceAsync(Guid.Parse("f000aa80-0451-4000-b000-000000000000"));
                ICharacteristic dataCharacteristic = await service.GetCharacteristicAsync(Guid.Parse("f000aa81-0451-4000-b000-000000000000"));
                ICharacteristic configCharacteristic = await service.GetCharacteristicAsync(Guid.Parse("f000aa82-0451-4000-b000-000000000000"));
                // _configCharacteristics.Add(configCharacteristic);
                //_characteristics.Add(dataCharacteristic);
                await configCharacteristic.WriteAsync(new byte[] { 0x7F, 0x00 });
                _gyro = new Gyroscope();
                dataCharacteristic.ValueUpdated += (o, args) =>
                {

                    byte[] bytes = args.Characteristic.Value;

                    _gyro.X = MovementService.Gyro(bytes, "x");
                    _gyro.Y = MovementService.Gyro(bytes, "y");
                    _gyro.Z = MovementService.Gyro(bytes, "z");
                    onPropertyChanged(nameof(Gyro));
                };
                await dataCharacteristic.StartUpdatesAsync();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error GetMovementService: " + ex);
            }
        }

        private Gyroscope _gyro;

        public Gyroscope Gyro
        {
            get { return _gyro; }
            set
            {
                _gyro = value;
            }
        }

        private Gyroscope _mag;

        public Gyroscope Mag
        {
            get { return _mag; }
            set
            {
                _mag = value;
            }
        }


    }
}
