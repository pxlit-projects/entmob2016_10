using StrongPlateEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongPlateEF.Services
{
    public interface ISPDataService
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
    }
}
