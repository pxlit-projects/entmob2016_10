using App1.Services;
using App1.ViewModel;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App1.View
{
    public partial class ServiceListPage : ContentPage
    {
        public ServiceListPage(IStrongPlateDataService database)
        {
            InitializeComponent();
            BindingContext = new ServiceListViewModel(database);

        }
    }
}
