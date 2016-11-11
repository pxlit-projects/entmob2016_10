using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Model
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; }
        [JsonProperty("averageSpeed")]
        public double AverageSpeed { get; set; }
        [JsonProperty("averageSteadyness")]
        public double AverageSteadyness { get; set; }
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
        
    }
}
