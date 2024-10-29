using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM.Utility.Common.Constants
{
    /// <summary>
    /// Constant of Message
    /// </summary>
    public class MsgConstant
    {
        /// <summary>
        /// Message Parameters
        /// </summary>
        public const int MSG_VERSION = 4000;

        public const int MSG_SOURCE_3RDPARTY = 0;
        public const int MSG_SOURCE_L3SERVER = 1;
        public const int MSG_SOURCE_TOSERVER = 2;
        public const int MSG_SOURCE_TRKSERVER = 3;
        public const int MSG_SOURCE_GENSERVER = 4;
        public const int MSG_SOURCE_TRKCLIENT = 5;
        public const int MSG_SOURCE_HMI = 6;
        public const int MSG_SOURCE_AGV_HMI = 7;
        public const int MSG_USER_NAME = 70;

        public const int MSG_COIL_NAME_LENGTH = 11;
        public const int MSG_LOCATION_LENGTH = 3;
        public const int MSG_CODE_NAME_LENGTH = 4;
        public const int MSG_EVENT_CODE_LENGTH = 4;
        public const int MSG_EVENT_VALUE_LENGTH = 100;
        public const int MSG_EVENT_APP_LENGTH = 100;
        public const int MSG_ALARM_TEXT_LENGTH = 62;


        public const int MSG_INGOT_ID_LENGTH = 20;
        public const int MSG_HEADER_SENDER = 5;
        public const int MSG_HEADER_RECEIVER = 5;
        public const int MSG_HEADER_TIMESTAMP = 14;

        //TO MSG CONSTANTS
        public const int MSG_TO_LOCATION_LENGTH = 20;
    }
}
