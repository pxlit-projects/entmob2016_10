﻿using Plugin.BLE.Abstractions;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.ViewModel
{
    public class DeviceItemViewModel : INotifyPropertyChanged
    {
        public IDevice Device { get; set; }

        public Guid Id => Device.Id;
        public bool IsConnected => Device.State == DeviceState.Connected;
        public int Rssi => Device.Rssi;
        public string Name => Device.Name;

        public DeviceItemViewModel(IDevice device)
        {
            Device = device;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
