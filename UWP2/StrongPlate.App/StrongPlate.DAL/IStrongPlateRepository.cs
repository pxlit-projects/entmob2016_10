using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrongPlate.Domain;
using System.Collections.ObjectModel;

namespace StrongPlate.DAL
{
    public interface IStrongPlateRepository
    {
        Employee GetEmployeeByID(int ID);
        ObservableCollection<Employee> GetAllEmployees();
        ObservableCollection<Employee> GetTopSpeed();
        ObservableCollection<Employee> GetTopSteadyness();
    }
}
