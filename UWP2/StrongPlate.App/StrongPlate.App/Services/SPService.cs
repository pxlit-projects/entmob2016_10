using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrongPlate.Domain;
using StrongPlate.DAL;
using System.Collections.ObjectModel;

namespace StrongPlate.App.Services
{
    public class SPService : IStrongPlateService
    {
        private IStrongPlateRepository repository;

        public SPService(IStrongPlateRepository repository)
        {
            this.repository = repository;
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
