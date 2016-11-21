﻿using StrongPlate.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrongPlate.Domain;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;

namespace StrongPlate.Tests.Mocks
{
    class MockSPAPIRepository : IStrongPlateRepository
    {
        public List<Employee> GetAllEmployees()
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
                return JsonConvert.DeserializeObject<List<Employee>>(result);
            }
            else
            {
                return null;
            }
        }

        public Employee GetEmployeeByID(int ID)
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
    }
}