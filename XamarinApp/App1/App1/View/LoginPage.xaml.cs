using App1.Services;
using App1.ViewModel;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App1.View
{
    public partial class LoginPage : ContentPage
    {

        public LoginPage(IAdapter adapter, IBluetoothLE ble)
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(adapter,ble,Navigation);
        }
    }
}
