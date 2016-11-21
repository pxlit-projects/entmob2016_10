﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using App1.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using App1.Domain;
using Xamarin.Forms;
using Moq;
using Plugin.BLE.Abstractions.Contracts;

namespace App1.Tests.ViewModel
{
    [TestClass]
    public class LoginViewModelTests
    {

        private LoginViewModel loginViewModel;
        private List<User> users;
        private Mock<INavigation> nav;
        private Mock<IAdapter> adapter;
        private Mock<IBluetoothLE> ble;

        [TestInitialize]
        public async void Initialize()
        {
            nav = new Mock<INavigation>();
            adapter = new Mock<IAdapter>();
            ble = new Mock<IBluetoothLE>();
        }

        [TestMethod]
        public void TestIfNavigationIsWorking()
        {
            //Nog niet af!
            nav.Setup(n => n.PushAsync(new ConnectSensorPage(adapter.Object, ble.Object)));

            Assert.AreEqual(1, nav.Object.NavigationStack.Count);
        }

        [TestMethod]
        public void TestIfReturnedSha256IsRightLength()
        {
            loginViewModel = new LoginViewModel();
            string data = "Hello";
            string result = loginViewModel.getSha256(data);
            Assert.AreEqual(64, result.Length);
        }


        [TestMethod]
        public void TestIfListOfUsersIsReturned()
        {
            //arrange
            loginViewModel = new LoginViewModel();

            //action
            
            

            //test
            CollectionAssert.AllItemsAreInstancesOfType(users, typeof(User));
        }
    }
}
