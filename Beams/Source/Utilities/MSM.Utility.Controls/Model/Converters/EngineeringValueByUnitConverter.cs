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

    public class EngineeringValueByUnitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter != null)
            {
                if (parameter is EngineeringUnits)
                {
                    return GetEngineeringValueByUnit(value, (EngineeringUnits)parameter);
                }
                else if (parameter is string)
                {
                    return GetEngineeringValueByUnit(value, (string)parameter);
                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter != null)
            {
                if (parameter is EngineeringUnits)
                {
                    return SetEngineeringValueByUnit(value, (EngineeringUnits)parameter);
                }
                else if (parameter is string)
                {
                    return SetEngineeringValueByUnit(value, (string)parameter);
                }
            }

            return value;
        }

        public static object GetEngineeringValueByUnit(object value, EngineeringUnits unit)
        {
            if (unit == EngineeringUnits.MillimeterToFInch)
            {
                if (value is short)
                {
                    return EngineeringUnitHandler.GetDisplayPosition((double)(short)value);
                }
                else if (value is int)
                {
                    return EngineeringUnitHandler.GetDisplayPosition((double)(int)value);
                }
                else if (value is float)
                {
                    return EngineeringUnitHandler.GetDisplayPosition((double)(float)value);
                }
                else if (value is double)
                {
                    return EngineeringUnitHandler.GetDisplayPosition((double)value);
                }
                else if (value is string)
                {
                    double dblValue;
                    if (double.TryParse((string)value, out dblValue))
                    {
                        return EngineeringUnitHandler.GetDisplayPosition(dblValue);
                    }
                }
            }

            if (value is short)
            {
                return EngineeringUnitHandler.GetDisplayValueByUnit((double)(short)value, unit);
            }
            else if (value is int)
            {
                return EngineeringUnitHandler.GetDisplayValueByUnit((double)(int)value, unit);
            }
            else if (value is float)
            {
                return EngineeringUnitHandler.GetDisplayValueByUnit((double)(float)value, unit);
            }
            else if (value is double)
            {
                return EngineeringUnitHandler.GetDisplayValueByUnit((double)value, unit);
            }
            else if (value is string)
            {
                double dblValue;
                if (double.TryParse((string)value, out dblValue))
                {
                    return EngineeringUnitHandler.GetDisplayValueByUnit(dblValue, unit);
                }
            }

            return value;
        }

        public static object GetEngineeringValueByUnit(object value, string unit)
        {
            if (value is short)
            {
                return EngineeringUnitHandler.GetDisplayValueByUnit((double)(short)value, unit);
            }
            else if (value is int)
            {
                return EngineeringUnitHandler.GetDisplayValueByUnit((double)(int)value, unit);
            }
            else if (value is float)
            {
                return EngineeringUnitHandler.GetDisplayValueByUnit((double)(float)value, unit);
            }
            else if (value is double)
            {
                return EngineeringUnitHandler.GetDisplayValueByUnit((double)value, unit);
            }
            else if (value is string)
            {
                double dblValue;
                if (double.TryParse((string)value, out dblValue))
                {
                    return EngineeringUnitHandler.GetDisplayValueByUnit(dblValue, unit);
                }
            }

            return value;
        }

        public static object SetEngineeringValueByUnit(object value, EngineeringUnits unit)
        {
            if (value is short)
            {
                return (short)EngineeringUnitHandler.GetRealValueByUnit((double)(short)value, unit);
            }
            else if (value is int)
            {
                return (int)EngineeringUnitHandler.GetRealValueByUnit((double)(int)value, unit);
            }
            else if (value is float)
            {
                return (float)EngineeringUnitHandler.GetRealValueByUnit((double)(float)value, unit);
            }
            else if (value is double)
            {
                return (double)EngineeringUnitHandler.GetRealValueByUnit((double)value, unit);
            }
            else if (value is string)
            {
                double dblValue;
                if (double.TryParse((string)value, out dblValue))
                {
                    return EngineeringUnitHandler.GetRealValueByUnit(dblValue, unit);
                }
            }

            return value;
        }

        public static object SetEngineeringValueByUnit(object value, string unit)
        {
            if (value is short)
            {
                return (short)EngineeringUnitHandler.GetRealValueByUnit((double)(short)value, unit);
            }
            else if (value is int)
            {
                return (int)EngineeringUnitHandler.GetRealValueByUnit((double)(int)value, unit);
            }
            else if (value is float)
            {
                return (float)EngineeringUnitHandler.GetRealValueByUnit((double)(float)value, unit);
            }
            else if (value is double)
            {
                return (double)EngineeringUnitHandler.GetRealValueByUnit((double)value, unit);
            }
            else if (value is string)
            {
                double dblValue;
                if (double.TryParse((string)value, out dblValue))
                {
                    return EngineeringUnitHandler.GetRealValueByUnit(dblValue, unit);
                }
            }

            return value;
        }
    }
}