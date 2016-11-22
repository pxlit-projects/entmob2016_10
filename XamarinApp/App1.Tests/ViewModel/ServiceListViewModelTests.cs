using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App1.ViewModel;
using App1.Domain;
using Moq;
using App1.Services;

namespace App1.Tests.ViewModel
{
    [TestClass]
    public class ServiceListViewModelTests
    {

        private ServiceListViewModel serviceListViewModel;
        private Gyroscope gyro;
        private Magnetometer magne;
        private Accelerometer acc;
        private Mock<IStrongPlateDataService> database;
        

        [TestInitialize]
        public void Init()
        {
            database = new Mock<IStrongPlateDataService>();
            serviceListViewModel = new ServiceListViewModel(database.Object);
            gyro = new Gyroscope();
            magne = new Magnetometer();
            acc = new Accelerometer();
        }

        [TestMethod]
        public void TestValueGyroSetter()
        {
            //arrange
            gyro.X = 5;
            gyro.Y = 6;
            gyro.Z = 8;
            serviceListViewModel.Gyro = gyro;

            Assert.AreEqual(5, serviceListViewModel.Gyro.X);
        }

        [TestMethod]
        public void TestValueMagneSetter()
        {
            //arrange
            magne.X = 58;
            magne.Y = 66.216;
            magne.Z = -18;
            serviceListViewModel.Mag = magne;

            Assert.AreEqual(-18, serviceListViewModel.Mag.Z);
        }

        [TestMethod]
        public void TestValueAccSetter()
        {
            //arrange
            acc.X = 85.27;
            acc.Y = -6992.6;
            acc.Z = 812.5121;
            serviceListViewModel.Acc = acc;

            Assert.AreEqual(-6992.6, serviceListViewModel.Acc.Y);
        }

    }
}
