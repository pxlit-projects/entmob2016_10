using Microsoft.VisualStudio.TestTools.UnitTesting;
using App1.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using App1.Domain;

namespace App1.Tests.ViewModel
{
    [TestClass]
    public class LoginViewModelTests
    {

        private LoginViewModel loginViewModel;
        private List<User> users;

        [TestInitialize]
        public async void Initialize()
        {
            users = await TaskUser();
        }

        [TestMethod]
        public void TestIfReturnedSha256IsRightLength()
        {
            loginViewModel = new LoginViewModel();
            string data = "Hello";
            string result = loginViewModel.getSha256(data);
            Assert.AreEqual(64, result.Length);
        }

        private Task<List<User>> TaskUser()
        {
           
            return Task.Run(async () =>
            {
                List<User> users = await loginViewModel.GetUsers();
                return users;
            });
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
