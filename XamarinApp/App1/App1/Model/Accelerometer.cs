﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace App1.Model
{
    public class Accelerometer
    {
        
        double x, y, z;

        public double X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
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
            }
        }
    }
}