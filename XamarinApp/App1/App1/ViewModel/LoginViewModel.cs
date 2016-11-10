using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.ViewModel
{
    public class LoginViewModel
    {
        private IAdapter adapter;
        private IBluetoothLE ble;
        private INavigation navigation;
        public Command LoginCommand { get; }
        public LoginViewModel(IAdapter adapter,IBluetoothLE ble,INavigation navigation)
        {
            this.adapter = adapter;
            this.ble = ble;
            this.navigation = navigation;
            LoginCommand = new Command(Login);
        }

        private async void Login()
        {
            await navigation.PushAsync(new ConnectSensorPage(adapter, ble)
            {
                Title = "StrongPlate"
            });
        }




    }  
}
