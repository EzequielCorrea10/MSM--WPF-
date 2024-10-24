using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSM.Utility.Common.Handlers
{
    using Janus.Rodeo.Windows.Library.Rd_Common;

    using MSM.Utility.Configuration;
    using MSM.Utility.Common.Enumerations;
    using MSM.Utility.Common.Structures;

    /// <summary>
    /// Class to handler the piece
    /// </summary>
    public class EngineeringUnitHandler
    {
        #region private static attributes
        /// <summary>
        /// use to lock the logical
        /// </summary>
        private static readonly object lockInstance = new object();

        /// <summary>
        /// Get the static instance of the class
        /// </summary>
        private static EngineeringUnitHandler instance;
        #endregion

        #region private properties
        /// <summary>
        /// Gets the Instance of the Rodeo class
        /// </summary>
        private static EngineeringUnitHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockInstance)
                    {
                        if (instance == null)
                        {
                            instance = new EngineeringUnitHandler();
                        }
                    }
                }
                return instance;
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EngineeringUnitHandler"/> class.
        /// </summary>
        private EngineeringUnitHandler()
        { }
        #endregion

        #region public methods
        /// <summary>
        /// GetDisplayPosition
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        public static string GetDisplayPosition(int[] positions)
        {
            if (Configurations.HMIs.EnglishUnits)
            {
                string[] result = new string[positions.Length];

                int feet;
                double inches;

                for (int i = 0; i < positions.Length; i++)
                {
                    feet = (int)((double)positions[i] / 304.8f);
                    inches = ((double)positions[i] - (double)feet * 304.8f) / 25.4f;

                    result[i] = string.Format("{0}'{1:0.#}\"", feet, inches);
                }

                return string.Format("({0})", string.Join(", ", result));
            }
            return string.Format("({0})", string.Join(", ", positions.Select(p => string.Format("{0:0.#} mm", p))));
        }

        /// <summary>
        /// Get Display Value by Unit
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static string GetDisplayPosition(double position)
        {
            if (Configurations.HMIs.EnglishUnits)
            {
                int feet;
                double inches;

                feet = (int)((double)position / 304.8f);
                inches = ((double)position - (double)feet * 304.8f) / 25.4f;

                return string.Format("{0}'{1:0.#}\"", feet, inches);

            }
            return string.Format("{0:0.#}", position);
        }

        /// <summary>
        /// GetDisplayPosition
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        public static string GetDisplayPosition(object[] positions)
        {
            if (Configurations.HMIs.EnglishUnits)
            {
                string[] result = new string[positions.Length];

                int feet;
                double inches;
                double dblValue;

                for (int i = 0; i < positions.Length; i++)
                {
                    if (positions[i] is short)
                    {
                        dblValue = (double)(short)positions[i];
                    }
                    else if (positions[i] is int)
                    {
                        dblValue = (double)(int)positions[i];
                    }
                    else if (positions[i] is float)
                    {
                        dblValue = (double)(float)positions[i];
                    }
                    else if (positions[i] is double)
                    {
                        dblValue = (double)positions[i];
                    }
                    else if (positions[i] is string)
                    {
                        if (!double.TryParse((string)positions[i], out dblValue))
                        {
                            result[i] = "-";
                            continue;
                        }
                    }
                    else
                    {
                        result[i] = "-";
                        continue;
                    }

                    feet = (int)(dblValue / 304.8f);
                    inches = (dblValue - (double)feet * 304.8f) / 25.4f;

                    result[i] = string.Format("{0}'{1:0.#}\"", feet, inches);
                }

                return string.Format("({0})", string.Join(", ", result));
            }
            return string.Format("({0})", string.Join(", ", positions.Select(p => string.Format("{0:0.#} mm", p))));
        }

        /// <summary>
        /// Get Display Value by Unit
        /// </summary>
        /// <param name="real_value"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static double GetDisplayValueByUnit(double real_value, EngineeringUnits unit)
        {
            if (Configurations.HMIs.EnglishUnits)
            {
                switch(unit)
                {
                    case EngineeringUnits.Millimeter:
                        return (real_value / 25.4f);
                    case EngineeringUnits.MillimeterPerSecond:
                        return (real_value / 25.4f);
                    case EngineeringUnits.Kilogram:
                        return (real_value * 2.20462);                    
                    default:
                        throw new NotImplementedException();
                }
            }
            return real_value;
        }

        
        /// <summary>
        /// Get Display Value by Unit
        /// </summary>
        /// <param name="real_value"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static double GetDisplayValueByUnit(double real_value, string unit)
        {
            switch (unit.ToLower())
            {
                case "mm":
                    return GetDisplayValueByUnit(real_value, EngineeringUnits.Millimeter);
                case "mm/s":
                    return GetDisplayValueByUnit(real_value, EngineeringUnits.MillimeterPerSecond);
                case "kg":
                    return GetDisplayValueByUnit(real_value, EngineeringUnits.Kilogram);
                default:
                    return real_value;
            }
        }

        /// <summary>
        /// Get Display Value by Unit
        /// </summary>
        /// <param name="real_value"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static double? GetDisplayValueByUnit(double? real_value, EngineeringUnits unit)
        {
            if (real_value == null)
            {
                return null;
            }

            return GetDisplayValueByUnit(real_value.Value, unit);
        }

        /// <summary>
        /// Get Display Value by Unit
        /// </summary>
        /// <param name="real_value"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static double? GetDisplayValueByUnit(double? real_value, string unit)
        {
            if (real_value == null)
            {
                return null;
            }

            return GetDisplayValueByUnit(real_value.Value, unit);
        }

        /// <summary>
        /// Get Real Value by Unit
        /// </summary>
        /// <param name="display_value"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static double GetRealValueByUnit(double display_value, EngineeringUnits unit)
        {
            if (Configurations.HMIs.EnglishUnits)
            {
                switch (unit)
                {
                    case EngineeringUnits.Millimeter:
                        return (display_value * 25.4f);
                    case EngineeringUnits.MillimeterPerSecond:
                        return (display_value * 25.4f);
                    case EngineeringUnits.Kilogram:
                        return (display_value * 0.453592);
                    default:
                        throw new NotImplementedException();
                }
            }
            return display_value;
        }

        /// <summary>
        /// Get Real Value
        /// </summary>
        /// <param name="display_value"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static double GetRealValueByUnit(double display_value, string unit)
        {
            switch (unit.ToLower())
            {
                case "mm":
                    return GetRealValueByUnit(display_value, EngineeringUnits.Millimeter);
                case "mm/s":
                    return GetRealValueByUnit(display_value, EngineeringUnits.MillimeterPerSecond);
                case "kg":
                    return GetRealValueByUnit(display_value, EngineeringUnits.Kilogram);
                default:
                    return display_value;
            }
        }

        /// <summary>
        /// Get Real Value
        /// </summary>
        /// <param name="display_value"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static double? GetRealValueByUnit(double? display_value, EngineeringUnits unit)
        {
            if (display_value == null)
            {
                return null;
            }

            return GetRealValueByUnit(display_value.Value, unit);
        }

        /// <summary>
        /// Get Real Value
        /// </summary>
        /// <param name="display_value"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static double? GetRealValueByUnit(double? display_value, string unit)
        {
            if (display_value == null)
            {
                return null;
            }

            return GetRealValueByUnit(display_value.Value, unit);
        }

        /// <summary>
        /// Get Display Unit
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static string GetDisplayUnit(EngineeringUnits unit)
        {
            if (Configurations.HMIs.EnglishUnits)
            {
                switch (unit)
                {
                    case EngineeringUnits.Millimeter:
                        return "inch";
                    case EngineeringUnits.Meter:
                        return "ft";
                    case EngineeringUnits.MillimeterToFeed:
                        return "ft";
                    case EngineeringUnits.MillimeterPerSecond:
                        return "inch/s";
                    case EngineeringUnits.Kilogram:
                        return "lb";
                    case EngineeringUnits.MillimeterToFInch:
                        return "ft/inch";
                    default:
                        throw new NotImplementedException();
                }
            }

            switch (unit)
            {
                case EngineeringUnits.Millimeter:
                    return "mm";
                case EngineeringUnits.Meter:
                    return "m";
                case EngineeringUnits.MillimeterPerSecond:
                    return "mm/s";
                case EngineeringUnits.MillimeterPerMinutes:
                    return "mm/s";
                case EngineeringUnits.Kilogram:
                    return "kg";
                case EngineeringUnits.MillimeterToFInch:
                    return "mm";
                case EngineeringUnits.MillimeterToFeed:
                    return "mm";
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Get Display Unit
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static string GetDisplayUnit(string unit)
        {
            switch (unit.ToLower())
            {
                case "mm":
                    return GetDisplayUnit(EngineeringUnits.Millimeter);
                case "mm/s":
                    return GetDisplayUnit(EngineeringUnits.MillimeterPerSecond);
                case "kg":
                    return GetDisplayUnit(EngineeringUnits.Kilogram);
                default:
                    return unit;
            }
        }
        #endregion
    }
}