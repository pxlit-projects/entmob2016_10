using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        private Mock<Command> command;
        private Mock<Task> task;

        [TestInitialize]
        public async void Initialize()
        {
            nav = new Mock<INavigation>();
            adapter = new Mock<IAdapter>();
            ble = new Mock<IBluetoothLE>();
            command = new Mock<Command>();
            task = new Mock<Task>();
        }

        [TestMethod]
        public void TestIfReturnedSha256IsRightLength()
        {
            loginViewModel = new LoginViewModel(adapter.Object,ble.Object,nav.Object);
            string data = "Hello";
            string result = loginViewModel.getSha256(data);
            Assert.AreEqual(64, result.Length);
        }

        [TestMethod]
        public void TestCommand()
        {
            loginViewModel = new LoginViewModel(adapter.Object, ble.Object, nav.Object);
            loginViewModel.LoginCommand.Execute(null);
            
            Assert.AreEqual(null, loginViewModel.LoginStatus);
        }

    }
}
