using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace HCM.Utility.Common
{
    /// <summary>
    /// Structures of the Header between Server
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    [Serializable]
    public struct MsgHeader
    {
        /// <summary>
        /// version
        /// </summary>
        public int version;

        /// <summary>
        /// source
        /// </summary>
        public byte source;
    }
}
