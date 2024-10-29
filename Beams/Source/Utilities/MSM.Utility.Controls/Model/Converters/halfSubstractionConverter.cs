using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace HSM.Utility.Controls.Converters
{
    public class HalfSubstractionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;

            if (value is double)
            {
                return ((double)value) / 2.0f;
            }
            else
            {
                double dblValue;
                if (double.TryParse(value.ToString(), out dblValue))
                {
                    return dblValue / 2.0f;
                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;

            if (value is double)
            {
                return ((double)value) * 2.0f;
            }
            else
            {
                double dblValue;
                if (double.TryParse(value.ToString(), out dblValue))
                {
                    return dblValue * 2.0f;
                }
            }

            return value;
        }
    }
}
