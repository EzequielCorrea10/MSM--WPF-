using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;


namespace MSM.Utility.Controls.Converters
{
    public class PositionFormattedConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values.Length > 0)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i] == DependencyProperty.UnsetValue) 
                    {
                        values[i] = null;                    
                    }
                }
                
                if (parameter != null && parameter is bool)
                {
                    return GetPositionFormatted(((bool)parameter), values);
                }

                return GetPositionFormatted(false, values);
            }

            return string.Empty;
        }

        public object[] ConvertBack(
            object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public static string GetPositionFormatted(bool parameter, params object[] values)
        {
            if (parameter)
            {
                string name = string.Empty;

                if (values[0] != null && values[0] != DependencyProperty.UnsetValue && values[0] is string)
                    if (!string.IsNullOrEmpty((string)values[0]))
                        return name = string.Format("{0} ", values[0]);

                object[] values_skipped = values.Skip(1).ToArray();

                if (values_skipped.All(p => p == null) || values_skipped.Any(p => p == DependencyProperty.UnsetValue))
                    return name;

                return string.Format("{0}({1})", name, string.Join(", ", values_skipped.Select(p => string.Format("{0:0.###}", p))));
            }

            if (values.All(p => p == null) || values.Any(p => p == DependencyProperty.UnsetValue))
                return string.Empty;

            return string.Format("({0})", string.Join(", ", values.Select(p => string.Format("{0:0.###}", p))));
        }
    }
}