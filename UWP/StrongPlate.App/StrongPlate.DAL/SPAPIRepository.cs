using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrongPlate.Domain;
<<<<<<< HEAD
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
=======
using System.Net.Http;
using Newtonsoft.Json;
>>>>>>> master

namespace StrongPlate.DAL
{
    public class SPAPIRepository : IStrongPlateRepository
    {
        public List<Employee> GetAllEmployees()
        {
<<<<<<< HEAD
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8090/User/getUsers");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes("1:secret")));
            HttpResponseMessage response = client.GetAsync(client.BaseAddress.AbsoluteUri).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(result);
                return GetFullName(employees);
            }
            else
            {
                return null;
            }
        }

        private List<Employee> GetFullName(List<Employee> employees)
        {
            foreach (Employee e in employees)
            {
                e.FullName = e.FirstName + " " + e.LastName;
            }

            return employees;
=======
            string apiEmployees = "http://localhost:8090/User/getUsers";
            var uri = new Uri(String.Format("{0}?format=json", apiEmployees));
            var client = new HttpClient();
            var response = Task.Run(() => client.GetAsync(uri)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            var root = JsonConvert.DeserializeObject<RootObject<Employee>>(result);
            return root.results;
>>>>>>> master
        }

        public Employee GetEmployeeByID(int ID)
        {
<<<<<<< HEAD
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
=======
            string apiEmployees = "http://localhost:8090/User/getUserById/" + ID;
            var uri = new Uri(String.Format("{0}?format=json", apiEmployees));
            var client = new HttpClient();
            var response = Task.Run(() => client.GetAsync(uri)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            return JsonConvert.DeserializeObject<Employee>(result);
>>>>>>> master
        }

        public List<Employee> GetTopSpeed()
        {
            List<Employee> ordered = GetAllEmployees().OrderBy(e => e.AverageSpeed).ToList();
            List<Employee> top = new List<Employee>();
<<<<<<< HEAD
            for (int i = 0; i < ordered.Count; i++)
            {
                top.Add(ordered.ElementAt(i));
                top.ElementAt(i).FullName = i + 1 + ". " + top.ElementAt(i).FullName;
=======
            for (int i = 0; i < 5; i++)
            {
                top.Add(ordered.ElementAt(i));
                top.ElementAt(i).LastName = i + 1 + ". " + top.ElementAt(i).LastName;
>>>>>>> master
            }

            return top;
        }

        public List<Employee> GetTopSteadyness()
        {
            List<Employee> ordered = GetAllEmployees().OrderBy(e => e.AverageSteadyness).ToList();
            List<Employee> top = new List<Employee>();
<<<<<<< HEAD
            for (int i = 0; i < ordered.Count; i++)
            {
                top.Add(ordered.ElementAt(i));
                top.ElementAt(i).FullName = i + 1 + ". " + top.ElementAt(i).FullName;
=======
            for (int i = 0; i < 5; i++)
            {
                top.Add(ordered.ElementAt(i));
                top.ElementAt(i).LastName = i + 1 + ". " + top.ElementAt(i).LastName;
>>>>>>> master
            }

            return top;
        }
<<<<<<< HEAD
=======

        class RootObject<T>
        {
            public int count { get; set; }
            public object next { get; set; }
            public object previous { get; set; }
            public List<T> results { get; set; }
        }
>>>>>>> master
    }
}
