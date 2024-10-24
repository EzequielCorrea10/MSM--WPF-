using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSM.Utility.Common
{
    /// <summary>
    /// Constant of Socket
    /// </summary>
    public class SckConstant
    {
        /// <summary>
        /// Socket Parameters
        /// </summary>
        public const int SCK_MAX_QUEUES = 25;
        public const int SCK_MAX_THREADS = 50;
        public const int SCK_CONNECT_TIMEOUT = 5000;
        public const int SCK_RECEIVE_TIMEOUT = 5000;
        public const int SCK_SEND_TIMEOUT = 5000;
        public const int SCK_RECEIVE_BUFFER = 1024;
        public const int SCK_SEND_BUFFER = 1024;
        public const int SCK_TYPE_OF_SERVICE = 0x08;
    }
}
