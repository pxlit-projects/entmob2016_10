using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace StrongPlate.App.Converter
{
    class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                BitmapImage img = new BitmapImage();
                bool male = (bool) value;
                string gender;
                if (male)
                    gender = "male";
                else
                    gender = "female";
                img.UriSource = new Uri("ms-appx:///Images/" + gender + ".png");
                return img;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
