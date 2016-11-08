using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrongPlate.Domain;
using System.Net.Http;
using Newtonsoft.Json;

namespace StrongPlate.DAL
{
    public class SPAPIRepository : IStrongPlateRepository
    {
        public List<Employee> GetAllEmployees()
        {
            string apiEmployees = "http://swapi.co/api/films"; // AANPASSSEN
            var uri = new Uri(String.Format("{0}?format=json", apiEmployees));
            var client = new HttpClient();
            var response = Task.Run(() => client.GetAsync(uri)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            var root = JsonConvert.DeserializeObject<RootObject<Employee>>(result);
            return root.results;
        }

        public Employee GetEmployeeByID(int ID)
        {
            string apiEmployees = "http://swapi.co/api/films/" + ID; // AANPASSSEN
            var uri = new Uri(String.Format("{0}?format=json", apiEmployees));
            var client = new HttpClient();
            var response = Task.Run(() => client.GetAsync(uri)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            return JsonConvert.DeserializeObject<Employee>(result);
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

        class RootObject<T>
        {
            public int count { get; set; }
            public object next { get; set; }
            public object previous { get; set; }
            public List<T> results { get; set; }
        }
    }
}
