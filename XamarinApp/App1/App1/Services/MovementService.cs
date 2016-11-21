using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Services
{
    public class MovementService
    {
        public static double Gyro(byte[] bytes,string position)
        {
            Int16 data = BitConverter.ToInt16(bytes, 0);
            switch (position.ToLower())
            {
                case "x":
                    data = BitConverter.ToInt16(bytes, 0);
                    break;
                case "y":
                    data = BitConverter.ToInt16(bytes, 2);
                    break;
                case "z":
                    data = BitConverter.ToInt16(bytes, 4);
                    break;
            }           
            return (data * 1.0) / (65536 / 500);
        }

        public static double Acc(byte[] bytes, string position)
        {
            Int16 data = BitConverter.ToInt16(bytes, 0);
            switch (position.ToLower())
            {
                case "x":
                    data = BitConverter.ToInt16(bytes, 6);
                    break;
                case "y":
                    data = BitConverter.ToInt16(bytes, 8);
                    break;
                case "z":
                    data = BitConverter.ToInt16(bytes, 10);
                    break;
            }
            return (data * 1.0) / (32768 / 2);
        }

        public static double Mag(byte[] bytes, string position)
        {
            Int16 data = BitConverter.ToInt16(bytes, 0);
            switch (position.ToLower())
            {
                case "x":
                    data = BitConverter.ToInt16(bytes, 12);
                    break;
                case "y":
                    data = BitConverter.ToInt16(bytes, 14);
                    break;
                case "z":
                    data = BitConverter.ToInt16(bytes, 16);
                    break;
            }
            return 1.0 * data;
        }    
    }
}
