using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace HSM.Utility.Controls.Converters
{
    public class StringToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;

            if (value is string && !string.IsNullOrEmpty((string)value))
            {
                BitmapImage a = new BitmapImage(new Uri(string.Format("{0}", (string)value), UriKind.Relative));
                return new BitmapImage(new Uri(string.Format("{0}", (string)value), UriKind.Relative));

            }
            else 
            {
                return null;

            }
                
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}