using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App1.ViewModel;
using App1.Domain;
using Moq;

namespace App1.Tests.ViewModel
{
    [TestClass]
    public class ServiceListViewModelTests
    {

        private ServiceListViewModel serviceListViewModel;
        private Gyroscope gyro;

        [TestInitialize]
        public void Init()
        {
            serviceListViewModel = new ServiceListViewModel();
            gyro = new Gyroscope();
            
        }

        [TestMethod]
        public void TestXValueGyro()
        {
            //arrange
            gyro.X = 5;
            serviceListViewModel.Gyro = gyro;

            //actual
            double expectedX = 5;

            Assert.AreEqual(expectedX, serviceListViewModel.Gyro.X);

        }

    }
}
