using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HSM.HMI.Safety.Operation.Converters
{
    public class LayoutLeftConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double canvas_width = (double)parameter;

            int min = 0;
            if (value is int)
            {
                min = (int)value;
            }
            else
            {
                return null;
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public static double GetRealPosition(double pixel, double canvas_width)
        {
            return 0;
        }
    }
}