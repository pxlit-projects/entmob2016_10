using App1.DAL;
using App1.Domain;
using App1.Services;
using Java.Util;
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
        private App1Repository database;
        private List<Plate> Plates;
        private Timer apiTimer;
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
                //PostPlateData();
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
                Plates = new List<Plate>();
                dataCharacteristic.ValueUpdated += (o, args) =>
                {                   
                    byte[] bytes = args.Characteristic.Value;

                    SetGyro(bytes);
                    SetAcc(bytes);
                    SetMag(bytes);
                    addPlate();
                    
                };
                await dataCharacteristic.StartUpdatesAsync();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error GetMovementService: " + ex);
            }
        }
        private void addPlate()
        {
            
            Plates.Add(new Plate()
            {
                GryroX = Gyro.X,
                GryroY = Gyro.Y,
                GryroZ = Gyro.Z,
                AccX = Acc.X,
                AccY = Acc.Y,
                AccZ = Acc.Z,
                MagneX = Mag.X,
                MagneY = Mag.Y,
                MagneZ = Mag.Z,
                Magnetic = false,
                UserId = 1
            });
        }

        private async void PostPlateData()
        {
            
            await Task.Factory.StartNew(async () =>
            {
                await updateDatabase();
            });
            await Task.Delay(30000);
        }

        private async Task updateDatabase()
        {
            if (!Plates.Any()) {
                List<Plate> secondPlates = new List<Plate>();
                for (int i = 0; i < Plates.Count; i++)
                {
                    secondPlates.Add(Plates[i]);
                }
                Plates.Clear();
                for (int i = 0; i < secondPlates.Count; i++)
                {
                    await database.PostSetData(secondPlates[i]);
                }

            }
        }

        /*private async void updatebase() {

            await UpdateDatabase();
        }

        private async Task<bool> UpdateDatabase()
        {
            
            //return await database.PostSetData(plate);
        }*/

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
