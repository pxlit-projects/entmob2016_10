using StrongPlate.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongPlate.App.Services
{
    public interface IStrongPlateService
    {
        Employee GetEmployeeByID(int ID);
        ObservableCollection<Employee> GetAllEmployees();
        ObservableCollection<Employee> GetTopSpeed();
        ObservableCollection<Employee> GetTopSteadyness();
    }
}
