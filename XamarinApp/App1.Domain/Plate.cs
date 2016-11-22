using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Domain
{
    public class Plate
    {

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("created_on")]
        public DateTime Datetime { get; set; }
        

        [JsonProperty("xG")]
        public double GryroX { get; set; }
        [JsonProperty("yG")]
        public double GryroY { get; set; }
        [JsonProperty("zG")]
        public double GryroZ { get; set; }


        [JsonProperty("xS")]
        public double AccX { get; set; }
        [JsonProperty("yS")]
        public double AccY { get; set; }
        [JsonProperty("zS")]
        public double AccZ { get; set; }


        [JsonProperty("xUt")]
        public double MagneX { get; set; }
        [JsonProperty("yUt")]
        public double MagneY { get; set; }
        [JsonProperty("zUt")]
        public double MagneZ { get; set; }


        [JsonProperty("magnetic")]
        public bool Magnetic { get; set; }
        [JsonProperty("userId")]
        public int UserId { get; set; }


    }
}
