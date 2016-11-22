using Newtonsoft.Json;
using StrongPlate.DAL;
using StrongPlate.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StrongPlate.Tests.Mocks
{
    class MockSPAPIRepository : IStrongPlateRepository
    {
        private ObservableCollection<Employee> Employees;

        public MockSPAPIRepository()
        {
            Employees = new ObservableCollection<Employee>();
            Employees.Add(new Employee(1, "Boss", "The", "The Boss", 20, true, "sha265"));
            Employees.Add(new Employee(2, "Ober", "The", "The Ober", 18, true, "sha265"));
            Employees.Add(new Employee(3, "Ober", "The", "The Ober", 19, true, "sha265"));

        }
        public ObservableCollection<Employee> GetAllEmployees()
        {
            return Employees;
        }

        public Employee GetEmployeeByID(int ID)
        {
            return (Employee)Employees.Where(r => r.ID == ID);
        }

        public ObservableCollection<Employee> GetTopSpeed()
        {
            List<Employee> ordered = Employees.OrderBy(e => e.AverageSpeed).ToList();
            ObservableCollection<Employee> top = new ObservableCollection<Employee>();
            if (ordered.Count < 5)
            {
                for (int i = 0; i < ordered.Count; i++)
                {
                    top.Add(ordered.ElementAt(i));
                    top.ElementAt(i).FullName = i + 1 + ". " + top.ElementAt(i).FullName;
                }

                return top;
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    top.Add(ordered.ElementAt(i));
                    top.ElementAt(i).FullName = i + 1 + ". " + top.ElementAt(i).FullName;
                }

                return top;
            }

        }

        public ObservableCollection<Employee> GetTopSteadyness()
        {
            List<Employee> ordered = Employees.OrderBy(e => e.AverageSteadyness).ToList();
            ObservableCollection<Employee> top = new ObservableCollection<Employee>();
            if (ordered.Count < 5)
            {
                for (int i = 0; i < ordered.Count; i++)
                {
                    top.Add(ordered.ElementAt(i));
                    top.ElementAt(i).FullName = i + 1 + ". " + top.ElementAt(i).FullName;
                }

                return top;
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    top.Add(ordered.ElementAt(i));
                    top.ElementAt(i).FullName = i + 1 + ". " + top.ElementAt(i).FullName;
                }

                return top;
            }
        }
    }
}