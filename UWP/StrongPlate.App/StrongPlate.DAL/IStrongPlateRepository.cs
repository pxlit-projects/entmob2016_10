using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrongPlate.Domain;

namespace StrongPlate.DAL
{
    public interface IStrongPlateRepository
    {
        Employee GetEmployeeByID(int ID);
        List<Employee> GetAllEmployees();
        List<Employee> GetTopSpeed();
        List<Employee> GetTopSteadyness();
    }
}
