using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Diagnostics;
using System.ComponentModel;
using PCLCrypto;
using App1.Domain;
using App1.DAL;
namespace App1.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private IAdapter adapter;
        private IBluetoothLE ble;
        private INavigation navigation;
        private User user = null;

        private App1Repository database;


        #region PropertyChangedEvent
        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion

        public Command LoginCommand { get; }

        public LoginViewModel() { }

        public LoginViewModel(IAdapter adapter, IBluetoothLE ble, INavigation navigation)
        {
            this.adapter = adapter;
            this.ble = ble;
            this.navigation = navigation;
            database = new App1Repository();

            LoginCommand = new Command(Login);
        }

        private async Task WaitGetUser(string id)
        {
            user = await database.GetUserById(id);
        }

        public string getSha256(string data)
        {
            byte[] byteData = Encoding.UTF8.GetBytes(data);
            var hasher = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha256);
            byte[] hash = hasher.HashData(byteData);
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }

        

        private async void Login()
        {
            await WaitGetUser(_id);
            if (user != null)
            {

                if (user.Id == Convert.ToInt32(_id))
                {

                    string password = getSha256(_password);
                    if (user.Password == password)
                    {
                        await navigation.PushAsync(new ConnectSensorPage(adapter, ble)
                        {
                            Title = "StrongPlate"
                        });
                    }
                    else
                    {
                        _loginStatus = "Wrong password!";
                        onPropertyChanged(nameof(LoginStatus));

                    }
                }
                else
                {
                    _loginStatus = "Username not found!";
                    onPropertyChanged(nameof(LoginStatus));
                }

            }
            else
            {

                _loginStatus = "Wait for good internet connection";
                onPropertyChanged(nameof(LoginStatus));
            }

        }

        private string _loginStatus;

        public string LoginStatus
        {
            get { return _loginStatus; }
            set
            {
                _loginStatus = value;
            }
        }

        private string _id;

        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                onPropertyChanged(nameof(Password));
            }
        }
    }
}
