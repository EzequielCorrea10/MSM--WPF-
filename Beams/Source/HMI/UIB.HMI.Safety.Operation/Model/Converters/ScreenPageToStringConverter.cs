using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace HSM.HMI.Safety.Operation.Converters
{
    using HSM.HMI.Safety.Operation.Enumerations;

    internal class ScreenPageToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;

            if (value is ScreenPages)
            {
                bool title = true;
                if (parameter != null && parameter is bool)
                {
                    title = (bool)parameter;
                }

                ScreenPages type = (ScreenPages)value;
                switch(type)
                {
                    case ScreenPages.Collecting:
                        return (title) ? "Collecting Zone" : "Safety Zones";
                    case ScreenPages.Pilling:
                        return (title) ? "Pilling Zone" : "Safety Zones";
                    case ScreenPages.Position:
                        return (title) ? "Position Semi Automatic" : "Safety Zones";
                    case ScreenPages.Target:
                        return (title) ? "Target Semi Automatic" : "Safety Zones";
                    case ScreenPages.Requests:
                        return (title) ? "Equipment" : "Safety Zones";
                    case ScreenPages.Interlocks:
                        return (title) ? "Interlocks" : "Safety Zones";
                    case ScreenPages.Alarms:
                        return (title) ? "Alarms" : "Safety Zones";
                    default:
                        return "";
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
