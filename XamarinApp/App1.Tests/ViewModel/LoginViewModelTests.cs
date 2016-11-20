using Microsoft.VisualStudio.TestTools.UnitTesting;
using App1.ViewModel;

namespace App1.Tests.ViewModel
{
    [TestClass]
    public class LoginViewModelTests
    {

        LoginViewModel loginViewModel;

        [TestMethod]
        public void TestIfReturnedSha256IsRightLength()
        {
            loginViewModel = new LoginViewModel();
            string data = "Hello";
            string result = loginViewModel.getSha256(data);
            Assert.AreEqual(64, result.Length);
        }
    }
}
