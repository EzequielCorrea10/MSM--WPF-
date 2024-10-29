using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace HCM.HMI.Safety.Operation.Converters
{
    public class SystemModeBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Brush background = Brushes.Transparent;

            if (value != null && value is HCM.HMI.Safety.Operation.Enumerations.SystemModes)
            {
                switch ((HCM.HMI.Safety.Operation.Enumerations.SystemModes)value)
                {
                    case HCM.HMI.Safety.Operation.Enumerations.SystemModes.None:
                        background = new SolidColorBrush(Color.FromRgb(0x36, 0x1a, 0x18));
                        break;
                    case HCM.HMI.Safety.Operation.Enumerations.SystemModes.SomeOne:
                        background = new SolidColorBrush(Color.FromRgb(0x34, 0x28, 0x14));
                        break;
                    case HCM.HMI.Safety.Operation.Enumerations.SystemModes.All:
                        background = new SolidColorBrush(Color.FromRgb(0x29, 0x18, 0x36));
                        break;
                }
            }

            return background;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}