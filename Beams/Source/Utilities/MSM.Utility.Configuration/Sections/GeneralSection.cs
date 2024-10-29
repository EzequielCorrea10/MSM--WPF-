using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HSM.Utility.Configuration
{
    /// <summary>
    /// Configuration class of General Section.
    /// </summary>
    [Serializable()]
    public class GeneralSection
    {
        /// <summary>
        /// Gets ConnectionString.
        /// </summary>
        [XmlElement("ConnectionString", IsNullable = false)]
        public string ConnectionString
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ReplicationQueue.
        /// </summary>
        [XmlElement("ReplicationQueue", IsNullable = true)]
        public string ReplicationQueue
        {
            get;
            set;
        }

        /// <summary>
        /// Gets RodeoSector.
        /// </summary>
        [XmlElement("RodeoSector", IsNullable = false)]
        public string RodeoSector
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ClientName.
        /// </summary>
        [XmlElement("ClientName", IsNullable = false)]
        public string ClientName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets TestMode.
        /// </summary>
        [XmlElement("TestMode", IsNullable = false)]
        public bool TestMode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets TestUser.
        /// </summary>
        [XmlElement("TestUser", IsNullable = true)]
        public string TestUser
        {
            get;
            set;
        }

        /// <summary>
        /// Gets MinimizeTimeout.
        /// </summary>
        [XmlElement("MinimizeTimeout", IsNullable = false)]
        public int MinimizeTimeout
        {
            get;
            set;
        }
    }
}
