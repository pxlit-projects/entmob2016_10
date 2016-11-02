﻿using MvvmCross.Core.ViewModels;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.EventArgs;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.ViewModel
{
    public class MyViewModel : INotifyPropertyChanged
    {
        IBluetoothLE ble;
        IAdapter adapter;
        string bleStatus;
        ObservableCollection<DeviceItemViewModel> deviceList = new ObservableCollection<DeviceItemViewModel>();

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string bleStatus) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(bleStatus));
        }

        public MyViewModel(IAdapter adapter, IBluetoothLE ble)
        {
            this.ble = ble;
            this.adapter = adapter;
            bleStatus = GetStateText();
            ble.StateChanged += OnStateChanged;
            StartScanCommand = new Command(StartScan);
            
        }
        private void OnStateChanged(object sender, BluetoothStateChangedArgs e)
        {
            BleStatus = GetStateText();
        }
        public Command StartScanCommand { get; }

        private async void StartScan() {
            try
            {
                adapter.DeviceDiscovered += (s, a) => deviceList.Add(new DeviceItemViewModel(a.Device));
                await adapter.StartScanningForDevicesAsync();
            } catch
            {

            }
        }
        
        public string BleStatus
        {
            get { return bleStatus; }
            set
            {
                bleStatus = value;
                OnPropertyChanged(nameof(BleStatus));
            }
        }
        public ObservableCollection<DeviceItemViewModel> DeviceList
        {
            get { return deviceList; }
            set
            {
                deviceList = value;
                OnPropertyChanged(nameof(DeviceList));
            }
        }

        private string GetStateText()
        {
            switch (ble.State)
            {
                case BluetoothState.Unknown:
                    return "Unknown BLE state.";
                case BluetoothState.Unavailable:
                    return "BLE is not available on this device.";
                case BluetoothState.Unauthorized:
                    return "You are not allowed to use BLE.";
                case BluetoothState.TurningOn:
                    return "BLE is warming up, please wait.";
                case BluetoothState.On:
                    return "BLE is on.";
                case BluetoothState.TurningOff:
                    return "BLE is turning off. That's sad!";
                case BluetoothState.Off:
                    return "BLE is off. Turn it on!";
                default:
                    return "Unknown BLE state.";
            }
        }

    }
}
