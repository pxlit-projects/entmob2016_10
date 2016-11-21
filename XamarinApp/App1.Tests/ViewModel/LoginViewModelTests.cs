using Microsoft.VisualStudio.TestTools.UnitTesting;
using App1.ViewModel;
using App1.Model;
using System.Collections.Generic;

namespace App1.Tests.ViewModel
{
    [TestClass]
    public class LoginViewModelTests
    {

        private LoginViewModel loginViewModel;

        [TestMethod]
        public void TestIfReturnedSha256IsRightLength()
        {
            loginViewModel = new LoginViewModel();
            string data = "Hello";
            string result = loginViewModel.getSha256(data);
            Assert.AreEqual(64, result.Length);
        }

        [TestMethod]
        public async void TestIfListOfUsersIsReturned()
        {
            //arrange
            loginViewModel = new LoginViewModel();

            //action
            List<User> users = await loginViewModel.GetUsers();

            //test
            CollectionAssert.AllItemsAreInstancesOfType(users, typeof(User));
        }
    }
}
