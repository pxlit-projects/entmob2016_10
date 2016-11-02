using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.ViewModel
{
    public class ServiceListViewModel
    {
        IAdapter adapter;
        IDevice device;
        public ServiceListViewModel(IAdapter adapter, IDevice device)
        {
            this.adapter = adapter;
            this.device = device;
        }


    }
}
