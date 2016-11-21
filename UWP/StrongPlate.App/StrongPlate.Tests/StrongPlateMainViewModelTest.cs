﻿using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
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
    class StrongPlateMainViewModelTest
    {
        private IStrongPlateService strongPlateService;
        private IFrameNavigationService frameNavigationService;

        public StrongPlateMainViewModel GetViewModel()
        {
            return new StrongPlateMainViewModel(frameNavigationService, strongPlateService);
        }

        [TestInitialize]
        public void Init()
        {
            strongPlateService = new MockSPService();
            frameNavigationService = new MockFrameNavigationService();
        }

        [TestMethod]
        public void GetEmployees()
        {
            // Arrange
            List<Employee> employees;
            List<Employee> expectedEmployees = strongPlateService.GetAllEmployees();

            // Act
            StrongPlateMainViewModel viewModel = GetViewModel();
            employees = viewModel.Employees;

            // Assert
            Assert.AreEqual(employees, expectedEmployees);
        }
    }
}