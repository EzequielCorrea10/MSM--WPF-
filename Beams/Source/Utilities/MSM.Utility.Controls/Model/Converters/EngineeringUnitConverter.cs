using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace HCM.Utility.Controls.Converters
{
    using HCM.Utility.Common.Enumerations;
    using HCM.Utility.Common.Handlers;

    public class EngineeringUnitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter != null && parameter is EngineeringUnits)
            {
                return EngineeringUnitHandler.GetDisplayUnit((EngineeringUnits)parameter);
            }
            else if (value != null)
            {
                if (value is EngineeringUnits)
                {
                    return EngineeringUnitHandler.GetDisplayUnit((EngineeringUnits)value);
                }
                else if (value is string)
                {
                    return EngineeringUnitHandler.GetDisplayUnit((string)value);
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