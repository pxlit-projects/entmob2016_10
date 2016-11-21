using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StrongPlate.Domain
{
    public class Employee : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
<<<<<<< HEAD
        public string FullName { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
=======
        public int Age { get; set; }
        public bool Male { get; set; }
>>>>>>> master
        public string Password { get; set; }

        public double averageSpeed;
        public double AverageSpeed
        {
            get { return averageSpeed; }
            set
            {
                averageSpeed = value;
                OnPropertyChanged();
            }
        }

        public double averageSteadyness;
        public double AverageSteadyness
        {
            get { return averageSteadyness; }
            set
            {
                averageSteadyness = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }

        }
    }
}
