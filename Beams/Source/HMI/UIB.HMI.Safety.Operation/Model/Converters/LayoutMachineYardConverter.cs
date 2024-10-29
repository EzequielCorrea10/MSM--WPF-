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
    using Janus.Rodeo.Windows.Library.Rd_Common;
    public class LayoutMachineYardConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int result = 0;
            //int layout = 664;

           // HSM.Tracking.Server.Common.Catalogs.CT_Machine machine = (HSM.Tracking.Server.Common.Catalogs.CT_Machine)value;

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
