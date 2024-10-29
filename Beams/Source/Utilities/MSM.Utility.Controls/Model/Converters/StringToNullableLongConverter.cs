using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HCM.Utility.Controls.Converters
{
    public class StringToNullableLongConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            long? d = (long?)value;
            if (d.HasValue)
                return d.Value.ToString(culture);
            else
                return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string s = (string)value;
            if (string.IsNullOrEmpty(s))
                return null;
            else
                return (long?)long.Parse(s, culture);
        }
    }
}