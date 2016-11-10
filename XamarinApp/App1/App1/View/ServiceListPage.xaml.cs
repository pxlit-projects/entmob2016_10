using App1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App1.View
{
    public partial class ServiceListPage : ContentPage
    {
        public ServiceListPage()
        {
            InitializeComponent();
            BindingContext = new ServiceListViewModel(); 

        }
    }
}
