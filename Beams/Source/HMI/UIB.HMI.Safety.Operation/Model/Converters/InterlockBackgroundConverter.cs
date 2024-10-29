using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace HSM.HMI.Safety.Operation.Converters
{
    public class InterlockBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Brush background = Brushes.Transparent;

            if (value != null && value is HSM.HMI.Safety.Operation.Enumerations.InterlockTypes)
            {
                switch ((HSM.HMI.Safety.Operation.Enumerations.InterlockTypes)value)
                {
                    case HSM.HMI.Safety.Operation.Enumerations.InterlockTypes.Zones:
                        background = new SolidColorBrush(Color.FromRgb(0x36, 0x1a, 0x18));
                        break;
                    case HSM.HMI.Safety.Operation.Enumerations.InterlockTypes.Equipment:
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