using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Model
{
    public class Gyroscope 
    {
        double x, y, z;

        public Gyroscope() { }

        public double X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
                //OnPropertyChanged(nameof(X));
            }
        }

        public double Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
                //OnPropertyChanged(nameof(Y));
            }
        }

        public double Z
        {
            get
            {
                return z;
            }

            set
            {
                z = value;
                //OnPropertyChanged(nameof(Z));
            }
        }

       /* public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string gryo)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(gryo));
        }*/
    }
}
