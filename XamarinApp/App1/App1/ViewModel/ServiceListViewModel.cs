using App1.Domain;
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

        #region PropertyChangedEvent
        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion
        public ServiceListViewModel()
        {           
            MessagingCenter.Subscribe<DeviceItem>(this, "connectdevice", (arg) =>
            {
                device = arg.Device;
                GetServices();
            });
            MessagingCenter.Send("true", "senddevice");
        }
        
        private async void GetServices()
        {
            await GetMovementService();           
        }

        private async Task GetMovementService()
        {
            try
            {
                IService service = await device.GetServiceAsync(Guid.Parse("f000aa80-0451-4000-b000-000000000000"));
                ICharacteristic dataCharacteristic = await service.GetCharacteristicAsync(Guid.Parse("f000aa81-0451-4000-b000-000000000000"));
                ICharacteristic configCharacteristic = await service.GetCharacteristicAsync(Guid.Parse("f000aa82-0451-4000-b000-000000000000"));
                await configCharacteristic.WriteAsync(new byte[] { 0x7F, 0x00 });
                _gyro = new Gyroscope();
                _acc = new Accelerometer();
                _mag = new Magnetometer();
                dataCharacteristic.ValueUpdated += (o, args) =>
                {
                    
                    byte[] bytes = args.Characteristic.Value;

                    SetGyro(bytes);
                    SetAcc(bytes);
                    SetMag(bytes);
                };
                await dataCharacteristic.StartUpdatesAsync();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error GetMovementService: " + ex);
            }
        }

        private void SetGyro(byte[] bytes) {
            _gyro.X = MovementService.Gyro(bytes, "x");
            _gyro.Y = MovementService.Gyro(bytes, "y");
            _gyro.Z = MovementService.Gyro(bytes, "z");
            onPropertyChanged(nameof(Gyro));
        }

        private void SetMag(byte[] bytes)
        {
            _mag.X = MovementService.Mag(bytes, "x");
            _mag.Y = MovementService.Mag(bytes, "y");
            _mag.Z = MovementService.Mag(bytes, "z");
            onPropertyChanged(nameof(Mag));
        }

        private void SetAcc(byte[] bytes)
        {
            _acc.X = MovementService.Acc(bytes, "x");
            _acc.Y = MovementService.Acc(bytes, "y");
            _acc.Z = MovementService.Acc(bytes, "z");
            onPropertyChanged(nameof(Acc));
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

        private Accelerometer _acc;

        public Accelerometer Acc
        {
            get { return _acc; }
            set
            {
                _acc = value;
            }
        }

        private Magnetometer _mag;

        public Magnetometer Mag
        {
            get { return _mag; }
            set
            {
                _mag = value;
            }
        }
    }
}
