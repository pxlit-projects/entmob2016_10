using App1.Services;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace App1.ViewModel
{
    public class ServiceListViewModel : INotifyPropertyChanged
    {
        private DeviceItemViewModel device;
        private IList<ICharacteristic> _writeCharacteristics = new List<ICharacteristic>();
        private IList<ICharacteristic> _characteristics = new List<ICharacteristic>();
        private double _temperatureData;

        public event PropertyChangedEventHandler PropertyChanged;

        public ServiceListViewModel(DeviceItemViewModel device)
        {
            this.device = device;
            GetServices();
        }
        private async void GetServices()
        {
            await GetTempService();           
            await TurnServiceOn();
            readTemp();
        }
        private async Task GetTempService()
        {
            try
            {
                IService service = await device.Device.GetServiceAsync(Guid.Parse("f000aa00-0451-4000-b000-000000000000"));
                ICharacteristic dataCharacteristic = await service.GetCharacteristicAsync(Guid.Parse("f000aa01-0451-4000-b000-000000000000"));
                ICharacteristic configCharacteristic = await service.GetCharacteristicAsync(Guid.Parse("f000aa02-0451-4000-b000-000000000000"));
                _writeCharacteristics.Add(configCharacteristic);
                _characteristics.Add(dataCharacteristic);
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
                for (int i = 0; i < _writeCharacteristics.Count; i++)
                {               
                    var characteristic = _writeCharacteristics[i];
                    await characteristic.WriteAsync(new byte[] { 0x01 });   
                                  
                }
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error TurnServiceOn :" + ex);
            }
        }


        private async void readTemp() {
            ICharacteristic characteristic = null;
            for (int i = 0; i < _characteristics.Count; i++) {
                characteristic = _characteristics[i];
            }

            characteristic.ValueUpdated += (o, args) =>
            {
                byte[] bytes = args.Characteristic.Value;
                //_temperatureData = Math.Round(ServiceConverter.AmbientTemperature(bytes), 2);
                _temperatureData = ServiceConverter.AmbientTemperature(bytes);
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

        private void onPropertyChanged(string temperature)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(temperature));
        }


       
    }
}
