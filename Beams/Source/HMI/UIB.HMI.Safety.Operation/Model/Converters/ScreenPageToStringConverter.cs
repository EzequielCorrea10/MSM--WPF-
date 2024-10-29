using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace HCM.HMI.Safety.Operation.Converters
{
    using HCM.HMI.Safety.Operation.Enumerations;

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
                    case ScreenPages.Layout:
                        return (title) ? "Layout" : "Safety Zones";
                    case ScreenPages.LayoutSemiAuto:
                        return (title) ? "Layout Semi Automatic" : "Safety Zones";
                    case ScreenPages.Position:
                        return (title) ? "Position Semi Automatic" : "Safety Zones";
                    case ScreenPages.Target:
                        return (title) ? "Target Semi Automatic" : "Safety Zones";
                    case ScreenPages.Zones:
                        return (title) ? "Zones" : "Safety Zones";
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
