using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrongPlateEF.Model;
using StrongPlateEF.DataLayer;

namespace StrongPlateEF.Services
{
    class SPDataService : ISPDataService
    {
        private StrongPlateContext db = new StrongPlateContext();

        public List<Employee> GetAllEmployees()
        {
            var query = (from e in db.Employees
                         orderby e.LastName
                         select e).ToList();

            return query;
        }

        public Employee GetEmployeeById(int id)
        {
            var query = (from e in db.Employees
                         where e.ID == id
                         select e).Single();

            return query;
        }
    }
}
