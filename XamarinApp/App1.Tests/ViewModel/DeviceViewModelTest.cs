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
        private Mock<IAdapter> adapter;
        private Mock<IBluetoothLE> ble;
        private Mock<INavigation> navigation;


        [TestInitialize]
        public void Init()
        {
            adapter = new Mock<IAdapter>();
            ble = new Mock<IBluetoothLE>();
            navigation = new Mock<INavigation>();
        }


        [TestMethod]
        public void TestBLEStateIsNotAvailable()
        {
            //Arrange
            ble.Setup(c => c.State).Returns(BluetoothState.Unavailable);
            deviceViewModel = new DeviceViewModel(adapter.Object, ble.Object, navigation.Object);

            //Actual
            string ExpectedBleState = "BLE is not available on this device.";

            Assert.AreEqual(ExpectedBleState, deviceViewModel.BleStatus);

        }

        [TestMethod]
        public void TestBLEStateIsOn()
        {
            //Arrange 
            ble.Setup(c => c.State).Returns(BluetoothState.On);
            deviceViewModel = new DeviceViewModel(adapter.Object, ble.Object, navigation.Object);

            //Actual
            string ExpectedBleState = "BLE is on.";

            Assert.AreEqual(ExpectedBleState, deviceViewModel.BleStatus);

        }

    }
}
