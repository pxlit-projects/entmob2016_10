using App1.ViewModel;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class ConnectSensorPage : ContentPage
    {
        public ConnectSensorPage(IAdapter adapter,IBluetoothLE ble)
        {
            InitializeComponent();
            DeviceViewModel deviceViewModel = new DeviceViewModel(adapter, ble, this.Navigation);
            BindingContext = deviceViewModel;

        }
   
    }
}
