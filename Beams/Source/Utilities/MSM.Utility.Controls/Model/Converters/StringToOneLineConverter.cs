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
    public class StringToOneLineConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;

            if (value is string && !string.IsNullOrEmpty((string)value))
            {
                string[] splitValue = ((string)value).Split('\r', '\n');
                if (splitValue.Length <= 0)
                {
                    return (string)value;
                }
                else if (splitValue.Length == 1)
                {
                    return splitValue[0].Replace("\r", "").Replace("\n", "");
                }
                else
                {
                    return string.Format("{0} (...)", splitValue[0].Replace("\r", "").Replace("\n", ""));
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}