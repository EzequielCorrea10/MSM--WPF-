using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HCM.Utility.Common.Messages
{
    /// <summary>
    /// Configuration class of message to position.
    /// </summary>
    [Serializable()]
    public class MsgPosition
    {
        /// <summary>
        /// Gets name
        /// </summary>
        [XmlElement("NAME", IsNullable = true)]
        public string name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Yard
        /// </summary>
        [XmlElement("YARD_NAME", IsNullable = false)]
        public string yard_name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets X Position
        /// </summary>
        [XmlElement("POS_X", IsNullable = false)]
        public int pos_x
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Y Position
        /// </summary>
        [XmlElement("POS_Y", IsNullable = false)]
        public int pos_y
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Z Position
        /// </summary>
        [XmlElement("POS_Z", IsNullable = true)]
        public int? pos_z
        {
            get;
            set;
        }
    }
}