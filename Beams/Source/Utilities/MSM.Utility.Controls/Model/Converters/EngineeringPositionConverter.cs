using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HSM.Utility.Controls.Converters
{
    using HSM.Utility.Common.Handlers;

    public class EngineeringPositionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values.Length > 0)
            {
                if (parameter != null && parameter is bool)
                {
                    return GetEngineeringPosition(((bool)parameter), values);
                }

                return GetEngineeringPosition(false, values);
            }

            return string.Empty;
        }

        public object[] ConvertBack(
            object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public static string GetEngineeringPosition(bool parameter, params object[] values)
        {
            string name = string.Empty;
            int[] positions;

            if (parameter)
            {
                if (values[0] != null && values[0] is string)
                    if (!string.IsNullOrEmpty((string)values[0]))
                        name = string.Format("{0} ", values[0]);

                if (values.Skip(1).All(p => p == null))
                    return name;

                return string.Format("{0}{1}", name, EngineeringUnitHandler.GetDisplayPosition(values.Skip(1).ToArray()));
            }
            else
            {
                if (values.All(p => p == null))
                    return string.Empty;

                positions = new int[values.Length];
            }

            return EngineeringUnitHandler.GetDisplayPosition(values);
        }
    }
}