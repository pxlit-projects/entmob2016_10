using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrongPlate.Domain;
using StrongPlate.DAL;

namespace StrongPlate.App.Services
{
    class SPService : IStrongPlateService
    {
        private IStrongPlateRepository repository;

        public SPService(IStrongPlateRepository repository)
        {
            this.repository = repository;
        }

        public List<Employee> GetAllEmployees()
        {
            return repository.GetAllEmployees();
        }

        public Employee GetEmployeeByID(int ID)
        {
            return repository.GetEmployeeByID(ID);
        }

        public List<Employee> GetTopSpeed()
        {
            return repository.GetTopSpeed();
        }

        public List<Employee> GetTopSteadyness()
        {
            return repository.GetTopSteadyness();
        }
    }
}
