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
        private Mock<IStrongPlateDataService> database;
        

        [TestInitialize]
        public void Init()
        {
            database = new Mock<IStrongPlateDataService>();
            serviceListViewModel = new ServiceListViewModel(database.Object);
            gyro = new Gyroscope();           
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

    }
}
