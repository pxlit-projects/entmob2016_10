using StrongPlate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongPlate.App.Services
{
    public interface IStrongPlateService
    {
        Employee GetEmployeeByID(int ID);
        List<Employee> GetAllEmployees();
        List<Employee> GetTopSpeed();
        List<Employee> GetTopSteadyness();
    }
}
