using StrongPlate.App.Services;
using StrongPlate.DAL;
using StrongPlate.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongPlate.Tests.Mocks
{
    class MockSPService : IStrongPlateService
    {
        private IStrongPlateRepository repository;

        public MockSPService(IStrongPlateRepository spRepository)
        {
            this.repository = spRepository;
        }

        public ObservableCollection<Employee> GetAllEmployees()
        {
            return repository.GetAllEmployees();
        }

        public Employee GetEmployeeByID(int ID)
        {
            return repository.GetEmployeeByID(ID);
        }

        public ObservableCollection<Employee> GetTopSpeed()
        {
            return repository.GetTopSpeed();
        }

        public ObservableCollection<Employee> GetTopSteadyness()
        {
            return repository.GetTopSteadyness();
        }
    }
}
