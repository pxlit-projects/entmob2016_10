using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongPlateEF.Model
{
    public class Employee 
    {
        [Key]
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public bool Male { get; set; }
        public string Password { get; set; }
        public double Speed { get; set; }
        public double Steadyness { get; set; }
    }
}
