using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HCM.HMI.Safety.Operation.Converters
{
    using Janus.Rodeo.Windows.Library.Rd_Common;

    public class LayoutWidthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double canvas_width = (double)parameter;
            int min = values[0].ToInt();
            int max = values[1].ToInt();

            double section_width = max - min;
            return 0;
        }

        public object[] ConvertBack(
            object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
