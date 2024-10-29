using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace HSM.Utility.Controls.Converters
{
    public class ContentStringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value is Label)
            {
                Label lbl = (Label)value;
                if (string.IsNullOrEmpty(lbl.ContentStringFormat))
                {
                    return lbl.Content;
                }
                else
                {
                    return string.Format(lbl.ContentStringFormat, lbl.Content);
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