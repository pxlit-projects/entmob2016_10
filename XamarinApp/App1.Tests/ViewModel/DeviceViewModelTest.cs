using App1.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.Tests.ViewModel
{
    [TestClass]
    public class DeviceViewModelTest
    {

        private DeviceViewModel deviceViewModel;


        [TestMethod]
        public void TestBLEStateIsNotAvailable()
        {
            //Arrange 
            var adaper = new Mock<IAdapter>();
            var ble = new Mock<IBluetoothLE>();
            var navigation = new Mock<INavigation>();
            ble.Setup(c => c.State).Returns(BluetoothState.Unavailable);
            deviceViewModel = new DeviceViewModel(adaper.Object, ble.Object, navigation.Object);

            //Actual
            string bleState = "BLE is not available on this device.";

            Assert.AreEqual(bleState, deviceViewModel.BleStatus);


        }
    }
}
