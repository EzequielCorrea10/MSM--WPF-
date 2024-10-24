using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSM.Utility.Common.Enumerations
{
    /// <summary>
    /// Bypasses
    /// </summary>
    [Flags]
    public enum Bypasses : int
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,

        /// <summary>
        /// OuterDiameter
        /// </summary>
        OuterDiameter = 1 << 0,

        /// <summary>
        /// OuterDiameter
        /// </summary>
        Length = 1 << 0,

        /// <summary>
        /// Width
        /// </summary>
        Width = 1 << 1,

        /// <summary>
        /// Weight
        /// </summary>
        Weight = 1 << 2,

        /// <summary>
        /// Weight
        /// </summary>
        All = Length | Width | Weight
    }
}