using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MSM.HMI.Safety.Operation.Converters
{
    using MSM.HMI.Safety.Operation.ViewModels;
    using Janus.Rodeo.Windows.Library.Rd_Log;
    public class LayoutTopConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                double canvas_height = (double)parameter;

                int min = 0;
                if (values.Length == 1)
                {
                    min = (int)values[0];
                }
                else if (values.Length == 3)
                {
                  return null;
                }
                else
                {
                    return null;
                }

                return 0;            }
            catch (Exception ex)
            {
                RdTrace.Exception(ex);
                return null;

            }
        }

        public object[] ConvertBack(
            object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public static double GetRealPosition(double pixel, double canvas_height)
        {
            return 0;
        }
    }
}
