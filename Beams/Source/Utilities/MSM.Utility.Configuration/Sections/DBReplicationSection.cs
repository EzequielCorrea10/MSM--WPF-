using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FGB.Utility.Configuration
{
    /// <summary>
    /// Configuration class of DB Request Section.
    /// </summary>
    [Serializable()]
    public class DBReplicationSection
    {
        /// <summary>
        /// Gets LocalConnectionString.
        /// </summary>
        [XmlElement("LocalConnectionString", IsNullable = false)]
        public string LocalConnectionString
        {
            get;
            set;
        }


        /// <summary>
        /// Gets LocalQueue.
        /// </summary>
        [XmlElement("LocalQueue", IsNullable = false)]
        public string LocalQueue
        {
            get;
            set;
        }

        /// <summary>
        /// Gets CfgDBTables.
        /// </summary>
        [XmlElement("CfgDBTables", IsNullable = false)]
        public string CfgDBTables
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ReplicationMsgFolder.
        /// </summary>
        [XmlElement("ReplicationMsgFolder", IsNullable = false)]
        public string ReplicationMsgFolder
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ReplicationErrFolder.
        /// </summary>
        [XmlElement("ReplicationErrFolder", IsNullable = false)]
        public string ReplicationErrFolder
        {
            get;
            set;
        }
    }
}