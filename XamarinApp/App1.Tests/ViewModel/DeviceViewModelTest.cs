using App1.Domain;
using App1.Services;
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
        private Mock<IStrongPlateDataService> database;


        [TestInitialize]
        public void Init()
        {
            adapter = new Mock<IAdapter>();
            ble = new Mock<IBluetoothLE>();
            navigation = new Mock<INavigation>();
            database = new Mock<IStrongPlateDataService>();
        }


        [TestMethod]
        public void TestBLEStateIsUnavailable()
        {
            //Arrange
            ble.Setup(c => c.State).Returns(BluetoothState.Unavailable);
            deviceViewModel = new DeviceViewModel(adapter.Object, ble.Object, navigation.Object, database.Object);

            //Actual
            string ExpectedBleState = "BLE is not available on this device.";

            Assert.AreEqual(ExpectedBleState, deviceViewModel.BleStatus);

        }

        [TestMethod]
        public void TestBLEStateIsOn()
        {
            //Arrange 
            ble.Setup(c => c.State).Returns(BluetoothState.On);
            deviceViewModel = new DeviceViewModel(adapter.Object, ble.Object, navigation.Object, database.Object);

            //Actual
            string ExpectedBleState = "BLE is on.";

            Assert.AreEqual(ExpectedBleState, deviceViewModel.BleStatus);

        }

        [TestMethod]
        public void TestBLEStateIsUnknown()
        {
            //Arrange 
            ble.Setup(c => c.State).Returns(BluetoothState.Unknown);
            deviceViewModel = new DeviceViewModel(adapter.Object, ble.Object, navigation.Object, database.Object);

            //Actual
            string ExpectedBleState = "Unknown BLE state.";

            Assert.AreEqual(ExpectedBleState, deviceViewModel.BleStatus);

        }

        [TestMethod]
        public void TestBLEStateIsUnauthorized()
        {
            //Arrange 
            ble.Setup(c => c.State).Returns(BluetoothState.Unauthorized);
            deviceViewModel = new DeviceViewModel(adapter.Object, ble.Object, navigation.Object, database.Object);

            //Actual
            string ExpectedBleState = "You are not allowed to use BLE.";

            Assert.AreEqual(ExpectedBleState, deviceViewModel.BleStatus);

        }

        [TestMethod]
        public void TestBLEStateIsTurningOn()
        {
            //Arrange 
            ble.Setup(c => c.State).Returns(BluetoothState.TurningOn);
            deviceViewModel = new DeviceViewModel(adapter.Object, ble.Object, navigation.Object, database.Object);

            //Actual
            string ExpectedBleState = "BLE is warming up, please wait.";

            Assert.AreEqual(ExpectedBleState, deviceViewModel.BleStatus);

        }
        [TestMethod]
        public void TestBLEStateIsTurningOff()
        {
            //Arrange 
            ble.Setup(c => c.State).Returns(BluetoothState.TurningOff);
            deviceViewModel = new DeviceViewModel(adapter.Object, ble.Object, navigation.Object, database.Object);

            //Actual
            string ExpectedBleState = "BLE is turning off. That's sad!";

            Assert.AreEqual(ExpectedBleState, deviceViewModel.BleStatus);

        }
        [TestMethod]
        public void TestBLEStateIsOff()
        {
            //Arrange 
            ble.Setup(c => c.State).Returns(BluetoothState.Off);
            deviceViewModel = new DeviceViewModel(adapter.Object, ble.Object, navigation.Object, database.Object);

            //Actual
            string ExpectedBleState = "BLE is off. Turn it on!";

            Assert.AreEqual(ExpectedBleState, deviceViewModel.BleStatus);
        }

        [TestMethod]
        public void TestDeviceListSetter()
        {
            deviceViewModel = new DeviceViewModel(adapter.Object, ble.Object, navigation.Object, database.Object);
            DeviceItem device = null;
            deviceViewModel.DeviceList.Add(device);
            deviceViewModel.DeviceList.Add(device);

            Assert.IsTrue(deviceViewModel.DeviceList.Count == 2);
        }

        [TestMethod]
        public void TestCommandExecute()
        {
            deviceViewModel = new DeviceViewModel(adapter.Object, ble.Object, navigation.Object, database.Object);
            DeviceItem device = null;
            deviceViewModel.DeviceList.Add(device);
            deviceViewModel.StartScanCommand.Execute(null);

            Assert.IsTrue(deviceViewModel.DeviceList.Count == 0);
        }

    }
}
