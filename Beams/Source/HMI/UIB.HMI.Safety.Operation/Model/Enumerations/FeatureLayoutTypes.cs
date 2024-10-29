using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCM.HMI.Safety.Operation.Enumerations
{
    /// <summary>
    /// Description Types
    /// </summary>
    public enum FeatureLayoutTypes
    {
        /// <summary>
        /// Request visible
        /// </summary>
        IsRequestVisible = 1,

        /// <summary>
        /// Layer visible
        /// </summary>
        IsLayerVisible = 2,

        /// <summary>
        /// Fences visible
        /// </summary>
        IsFenceVisible = 3,

        /// <summary>
        /// Positions visible
        /// </summary>
        IsPositionVisible = 4
    }
}