using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MSM.Utility.Common.Messages
{
    /// <summary>
    /// Configuration class of message to position & heading
    /// </summary>
    [Serializable()]
    public class MsgPositionAndHeading : MsgPosition
    {
        /// <summary>
        /// Gets Heading
        /// </summary>
        [XmlElement("HEADING_POSITION", IsNullable = false)]
        public short heading_position
        {
            get;
            set;
        }
    }
}