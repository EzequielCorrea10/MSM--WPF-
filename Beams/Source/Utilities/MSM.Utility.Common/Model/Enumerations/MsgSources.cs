using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM.Utility.Common.Enumerations
{
    using HSM.Utility.Common.Helpers;

    public class MsgSources : CustomEnum<MsgSources, string>
    {
        #region public enum
        /// <summary>
        /// Public enum
        /// </summary>
        public static readonly MsgSources ACQ_SRV = new MsgSources("ACQ_SRV");
        public static readonly MsgSources L3_SRV = new MsgSources("L3_SRV");
        public static readonly MsgSources TO_SRV = new MsgSources("TO_SRV");
        public static readonly MsgSources PLC = new MsgSources("PLC");
        public static readonly MsgSources TRK_SRV = new MsgSources("TRK_SRV");
        public static readonly MsgSources SAFETY_SRV = new MsgSources("SAFETY_SRV");
        public static readonly MsgSources RS_SRV = new MsgSources("RS_SRV");
        public static readonly MsgSources SYSTEM_SRV = new MsgSources("SYSTEM_SRV");
        public static readonly MsgSources DVR_SRV = new MsgSources("DVR_SRV");
        public static readonly MsgSources HMI = new MsgSources("HMI");
        #endregion

        #region public contract
        public MsgSources(string aValue)
            : base (aValue)
        { }
        #endregion
    }
}