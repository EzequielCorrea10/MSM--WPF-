using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HCM.HMI.Safety.Operation.Converters
{
    public class LayoutHeightConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double canvas_height = (double)parameter;
            int min = (int)values[0];
            int max = (int)values[1];

            double section_height = max - min;
            return 0;
        }

        public object[] ConvertBack(
            object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}