using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM.HMI.Safety.Operation.Enumerations
{
    /// <summary>
    /// Screen Pages
    /// </summary>
    public enum ScreenPages
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,

        /// <summary>
        /// Layout
        /// </summary>
        Collecting = 1,

        /// <summary>
        /// Zone
        /// </summary>
        Pilling = 2,

        /// <summary>
        /// Request
        /// </summary>
        Requests = 3,

        /// <summary>
        /// Interlocks
        /// </summary>
        Interlocks = 4,

        /// <summary>
        /// Alarms
        /// </summary>
        Alarms = 5,

        /// <summary>
        /// LayoutSemiAuto
        /// </summary>
        LayoutSemiAuto = 11,

        /// <summary>
        /// Position
        /// </summary>
        Position = 12,

        /// <summary>
        /// LayoutSemiAuto
        /// </summary>
        Target = 13,
    }
}