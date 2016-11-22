using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrongPlate.Domain;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Collections.ObjectModel;
using Windows.UI.Popups;

namespace StrongPlate.DAL
{
    public class SPAPIRepository : IStrongPlateRepository
    {
        public ObservableCollection<Employee> GetAllEmployees()
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:8090/User/getUsers");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes("1:secret")));
                HttpResponseMessage response = client.GetAsync(client.BaseAddress.AbsoluteUri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    ObservableCollection<Employee> employees = JsonConvert.DeserializeObject<ObservableCollection<Employee>>(result);
                    return GetFullName(employees);
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                MessageDialog dialog = new MessageDialog("Verbind met de API en herstart!");
                ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
                Employee employee = new Employee();              
                employees.Add(employee);
                return employees;

            }
        }

        private ObservableCollection<Employee> GetFullName(ObservableCollection<Employee> employees)
        {
            foreach (Employee e in employees)
            {
                e.FullName = e.FirstName + " " + e.LastName;
            }

            return employees;
        }

        public Employee GetEmployeeByID(int ID)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:8090/User/getUsers");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes("1:secret")));
                HttpResponseMessage response = client.GetAsync(client.BaseAddress.AbsoluteUri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Employee>(result);
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                MessageDialog dialog = new MessageDialog("Verbind met de API en herstart!");
                Employee employee = new Employee();
                return employee;
            }
        }

        public ObservableCollection<Employee> GetTopSpeed()
        {
            List<Employee> ordered = GetAllEmployees().OrderBy(e => e.AverageSpeed).ToList();
            ObservableCollection<Employee> top = new ObservableCollection<Employee>();
            if(ordered.Count < 5)
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
            List<Employee> ordered = GetAllEmployees().OrderBy(e => e.AverageSteadyness).ToList();
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
