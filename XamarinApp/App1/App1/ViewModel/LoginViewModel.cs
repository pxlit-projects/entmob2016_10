using App1.Model;
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

namespace App1.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private IAdapter adapter;
        private IBluetoothLE ble;
        private INavigation navigation;
        private List<User> users = null;

        #region PropertyChangedEvent
        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion

        public Command LoginCommand { get; }
        public LoginViewModel(IAdapter adapter,IBluetoothLE ble,INavigation navigation)
        {
            this.adapter = adapter;
            this.ble = ble;
            this.navigation = navigation;
            WaitGetUsers();
            LoginCommand = new Command(Login);
        }

        private async void WaitGetUsers()
        {
            users =  await GetUsers();
        }

        private string getSha256(string data) {
            byte[] byteData = Encoding.UTF8.GetBytes(data);
            var hasher = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha256);
            byte[] hash = hasher.HashData(byteData);
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }

        private async void Login()
        {
            Debug.WriteLine("Name " + _username + " Pass " + _password);
            if (users != null)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].FirstName == _username)
                    {
                        
                        string password = getSha256(_password);
                        Debug.WriteLine("ApiPass = " + users[i].Password);
                        Debug.WriteLine("XamPass = " + password);
                        if (users[i].Password == password)
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
            }
            else
            {
                _loginStatus = "Wait for users are loaded!";
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

        private string _username;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
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

        private async Task<List<User>> GetUsers()
        {
            
            var baseUri = "http://192.168.1.108:8090/User/getUsers";

            string json = await JsonApiClientGetRequest(baseUri);
            if (json != null)
            {
                users = JsonConvert.DeserializeObject<List<User>>(json);
                return users;       
            }
            return null;
        }

        private async Task<string> JsonApiClientGetRequest(string baseUri)
        {
            string json = null;
            string username = "1";
            string password = "secret";
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUri);
                    client.DefaultRequestHeaders.Accept.Clear();                   
                    string authenticationLogin = Convert.ToBase64String(Encoding.UTF8.GetBytes(username + ":" + password));
                    client.DefaultRequestHeaders.Authorization = (new AuthenticationHeaderValue("Basic", authenticationLogin));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.GetAsync(baseUri);
                    if (response.IsSuccessStatusCode)
                    {
                        json = await response.Content.ReadAsStringAsync();
                    }

                    return json;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error jsonApiClientRequest : " + ex.Message);
            }

            return null;
        }
    }  
}
