//using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
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
using Xunit;

namespace StrongPlate.Tests
{
    //[TestClass]
    public class StrongPlateSteadynessViewModelTest
    {
        private IStrongPlateService strongPlateService;

        private IFrameNavigationService frameNavigationService;

        private StrongPlateSteadynessViewModel GetViewModel()
        {
            return new StrongPlateSteadynessViewModel(frameNavigationService, strongPlateService);
        }

        //[TestInitialize]
        public void Init()
        {
            strongPlateService = new MockSPService();
            frameNavigationService = new MockFrameNavigationService();
        }

        //[TestMethod]
        [Fact]
        public void GetTopSteadynessEmployees()
        {
            Init();

            // Arrange
            ObservableCollection<Employee> expectedEmployees = strongPlateService.GetTopSteadyness();


            // Act
            StrongPlateSteadynessViewModel viewModel = GetViewModel();
            ObservableCollection<Employee> employees = viewModel.TopEmployees;

            // Assert
            Assert.Equal(expectedEmployees.Count, employees.Count);

            for (int i = 0; i < employees.Count; i++)
            {
                Assert.Equal(expectedEmployees.ElementAt(i).LastName, employees.ElementAt(i).LastName);
            }
        }
    }
}