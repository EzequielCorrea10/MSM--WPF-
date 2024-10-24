using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSM.Utility.Common.Handlers
{
    using MSM.Utility.Configuration;
    using MSM.Utility.Common.Enumerations;
    using MSM.Utility.Common.Structures;
    using Janus.Rodeo.Windows.Library.Rd_Common;
    using System.Security.Permissions;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Class to handler the piece
    /// </summary>
    public class TagHelper
    {
        #region private static attributes        
        #endregion

        #region private properties
        /// <summary>
        /// Gets the Instance of the Rodeo class
        /// </summary>

        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TagHelper"/> class.
        /// </summary>
        private TagHelper()
        { }
        #endregion

        #region public methods
        /// <summary>
        /// GetDisplayPosition
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        public static bool GetStatusByDrive(int bitValue, long valueTag, int plc_value)
        {
            long mask = (long)(1 << bitValue);
            int value = (valueTag & mask) != 0 ? 1 : 0;

            return (value == plc_value);
        }        
        #endregion
    }
}