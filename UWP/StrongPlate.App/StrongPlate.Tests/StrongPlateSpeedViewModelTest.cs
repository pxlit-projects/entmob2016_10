using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using StrongPlate.App.Services;
using StrongPlate.App.ViewModel;
using StrongPlate.Domain;
using StrongPlate.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongPlate.Tests
{
    [TestClass]
    class StrongPlateSpeedViewModelTest
    {
        private IStrongPlateService strongPlateService;

        private IFrameNavigationService frameNavigationService;

        private StrongPlateSpeedViewModel GetViewModel()
        {
            return new StrongPlateSpeedViewModel(frameNavigationService, strongPlateService);
        }

        [TestInitialize]
        public void Init()
        {
            strongPlateService = new MockSPService();
            frameNavigationService = new MockFrameNavigationService();
        }

        [TestMethod]
        public void GetTopSpeedEmployees()
        {
            // Arrange
            List<Employee> employees;
            List<Employee> expectedEmployees = strongPlateService.GetTopSpeed();

            // Act
            StrongPlateSpeedViewModel viewModel = GetViewModel();
            employees = viewModel.TopEmployees;

            // Assert
            Assert.AreEqual(employees, expectedEmployees);
        }
    }
}
