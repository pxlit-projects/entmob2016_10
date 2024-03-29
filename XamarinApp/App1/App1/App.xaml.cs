﻿using App1.Services;
using App1.View;
using App1.ViewModel;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App1
{
    public partial class App : Application
    {
        IAdapter adapter = CrossBluetoothLE.Current.Adapter;
        IBluetoothLE ble = CrossBluetoothLE.Current;
        IStrongPlateDataService database = new StrongPlateDataService();
        public App()
        {
            InitializeComponent();
            NavigationPage navigation = new NavigationPage(new LoginPage(adapter, ble,database)
            {
                Title = "StrongPlate"
            });
            MainPage = navigation;
        }
        

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
