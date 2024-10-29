using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace HCM.HMI.Safety.Operation.Constants
{

    /// <summary>
    /// Constant of configuration
    /// </summary>
    /// 
    public class Configuration
    {
        /// <summary>
        /// Yard General
        /// </summary>     
        public const int GENERAL_LAYOUT_ID = 99;
        public const string MAX_LAYOUT = "MAX";
        public const string MIN_LAYOUT = "MIN";
        public static readonly string[] RAIL_ZONES = { "ZA93", "ZB93", "ZC93" };
        //public static readonly string[] RAIL_LOCATION_ZONES = { "MSS-A-Z93-001-001-1", "MSS-B-Z93-001-001-1", "MSS-C-Z93-001-001-1" };
    }


    /// <summary>
    /// Constant of rodeo
    /// </summary>
    /// 
    public class TagNames
    {
        /// <summary>
        /// EStop
        /// </summary>
        public const string GENERAL_ESTOP_OK = "{0}.General_EStop_OK";
        public const string PGL_ESTOP_OK = "{0}.PGL_EStop_OK";
        public const string GENERAL_RESET = "{0}.General_Reset";
    }

    /// <summary>
    /// Constant of configuration
    /// </summary>
    public class AlarmNames
    { }

    /// <summary>
    /// Constant of values
    /// </summary>
    public class TagValues
    {
        public const double ESTOP_OK = 1;
        public const double ESTOP_NOT_OK = 0;
        public const double GENERAL_RESET = 1;
    }

    /// <summary>
    /// Constant of Rodeo
    /// </summary>
    public class SetPoints
    {
        public const int GENERAL_RESET = 1;
    }
}