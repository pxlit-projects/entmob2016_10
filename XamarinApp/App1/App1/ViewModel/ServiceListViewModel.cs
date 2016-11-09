using App1.Services;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App1.ViewModel
{
    public class ServiceListViewModel : INotifyPropertyChanged
    {
        private IAdapter adapter = CrossBluetoothLE.Current.Adapter;
        private DeviceItemViewModel device;
        private ICharacteristic configCharacteristic;
        private ICharacteristic dataCharacteristic;
        private Queue<ICharacteristic> _writeCharacteristics = new Queue<ICharacteristic>();
        private IList<ICharacteristic> _characteristics = new List<ICharacteristic>();
        private byte[] bytes;

        private double _temperatureData;
        private bool writeTempOn = false;

        public IList<double> TemperaturesList = new List<double>();

        public event PropertyChangedEventHandler PropertyChanged;
        public ServiceListViewModel(DeviceItemViewModel device)
        {
            this.device = device;
            GetTempService();
            

        }

        private async void GetTempService() {

            try
            {
                IService service = await device.Device.GetServiceAsync(Guid.Parse("f000aa00-0451-4000-b000-000000000000"));
                dataCharacteristic = await service.GetCharacteristicAsync(Guid.Parse("f000aa01-0451-4000-b000-000000000000"));
                configCharacteristic = await service.GetCharacteristicAsync(Guid.Parse("f000aa02-0451-4000-b000-000000000000"));
                TurnServiceOn();
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error getTempService: " + ex);
            }
        }

        private async void TurnServiceOn()
        {
            try
            {
                await configCharacteristic.WriteAsync(GetBytes("1"));
                readTemp();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error TurnServiceOn :" + ex);
                writeTempOn = false;
            }
        }

        private async void readTemp() {
            dataCharacteristic.ValueUpdated += (o, args) =>
            {
                byte[] bytes = args.Characteristic.Value;
                //_temperatureData = Math.Round(ServiceConverter.AmbientTemperature(bytes), 2);
                _temperatureData = ServiceConverter.AmbientTemperature(bytes);
                onPropertyChanged(nameof(TemperatureData));
            };
            await dataCharacteristic.StartUpdatesAsync();

        }
        private static byte[] GetBytes(string text)
        {
            return text.Split(' ').Where(token => !string.IsNullOrEmpty(token)).Select(token => Convert.ToByte(token, 16)).ToArray();
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

        private void onPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }


       
    }
}
