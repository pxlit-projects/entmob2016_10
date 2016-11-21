using StrongPlate.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrongPlate.Domain;
<<<<<<< HEAD
using Newtonsoft.Json;
using System.Net.Http.Headers;
=======
>>>>>>> master
using System.Net.Http;

namespace StrongPlate.Tests.Mocks
{
    class MockSPAPIRepository : IStrongPlateRepository
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
                return JsonConvert.DeserializeObject<List<Employee>>(result);
            }
            else
            {
                return null;
            }
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
            for (int i = 0; i < 5; i++)
            {
                top.Add(ordered.ElementAt(i));
                top.ElementAt(i).LastName = i + 1 + ". " + top.ElementAt(i).LastName;
            }

            return top;
        }

        public List<Employee> GetTopSteadyness()
        {
            List<Employee> ordered = GetAllEmployees().OrderBy(e => e.AverageSteadyness).ToList();
            List<Employee> top = new List<Employee>();
            for (int i = 0; i < 5; i++)
            {
                top.Add(ordered.ElementAt(i));
                top.ElementAt(i).LastName = i + 1 + ". " + top.ElementAt(i).LastName;
            }

            return top;
        }
<<<<<<< HEAD
    }
}

=======

        class RootObject<T>
        {
            public int count { get; set; }
            public object next { get; set; }
            public object previous { get; set; }
            public List<T> results { get; set; }
        }
    }
}
>>>>>>> master
