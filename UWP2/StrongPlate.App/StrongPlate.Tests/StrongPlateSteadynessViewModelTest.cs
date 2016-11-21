using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using StrongPlate.App.Services;
using StrongPlate.App.ViewModel;
using StrongPlate.Domain;
using StrongPlate.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongPlate.Tests
{
    [TestClass]
    class StrongPlateSteadynessViewModelTest
    {
        private IStrongPlateService strongPlateService;

        private IFrameNavigationService frameNavigationService;

        private StrongPlateSteadynessViewModel GetViewModel()
        {
            return new StrongPlateSteadynessViewModel(frameNavigationService, strongPlateService);
        }

        [TestInitialize]
        public void Init()
        {
            strongPlateService = new MockSPService();
            frameNavigationService = new MockFrameNavigationService();
        }

        [TestMethod]
        public void GetTopSteadynessEmployees()
        {
            // Arrange
            ObservableCollection<Employee> employees;
            ObservableCollection<Employee> expectedEmployees = strongPlateService.GetTopSpeed();

            // Act
            StrongPlateSteadynessViewModel viewModel = GetViewModel();
            employees = viewModel.TopEmployees;

            // Assert
            Assert.AreEqual(employees, expectedEmployees);
        }
    }
}