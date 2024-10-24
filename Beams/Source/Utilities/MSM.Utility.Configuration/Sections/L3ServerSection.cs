using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MSM.Utility.Configuration
{
    /// <summary>
    /// Configuration class of L3 Server Section.
    /// </summary>
    [Serializable()]
    public class L3ServerSection
    {
        /// <summary>
        /// Gets RequestPort.
        /// </summary>
        [XmlElement("RequestPort", IsNullable = false)]
        public int RequestPort
        {
            get;
            set;
        }

        /// <summary>
        /// Gets RequestIPAddress.
        /// </summary>
        [XmlElement("RequestIPAddress", IsNullable = false)]
        public string RequestIPAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Gets RequestPort.
        /// </summary>
        [XmlElement("ReadQueuePath", IsNullable = false)]
        public string ReadQueuePath
        {
            get;
            set;
        }

        /// <summary>
        /// Gets RequestPort.
        /// </summary>
        [XmlElement("WriteQueuePath", IsNullable = false)]
        public string WriteQueuePath
        {
            get;
            set;
        }

        /// <summary>
        /// Gets RequestPort.
        /// </summary>
        [XmlElement("UserRequestName", IsNullable = false)]
        public string UserRequestName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets RequestLocalInterface.
        /// </summary>
        [XmlElement("RequestLocalInterface", IsNullable = true)]
        public string RequestLocalInterface
        {
            get;
            set;
        }

        /// <summary>
        /// Gets TimeoutToRetriesRequest.
        /// </summary>
        [XmlElement("TimeoutToRetriesRequest", IsNullable = false)]
        public long TimeoutToRetriesRequest
        {
            get;
            set;
        }

        /// <summary>
        /// Gets EventQueueName.
        /// </summary>
        [XmlElement("EventQueueName", IsNullable = false)]
        public string EventQueueName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets LocalEventQueueName.
        /// </summary>
        [XmlIgnore]
        public string LocalEventQueueName
        {
            get { return string.Format(@".\Private$\{0}", this.EventQueueName); }
        }

        /// <summary>
        /// Gets RemoteEventQueueName.
        /// </summary>
        [XmlIgnore]
        public string RemoteEventQueueName
        {
            get { return string.Format(@"FormatName:DIRECT=TCP:{0}\Private$\{1}", this.RequestIPAddress, this.EventQueueName); }
        }

        /// <summary>
        /// Gets L4GhostPrefix.
        /// </summary>
        [XmlElement("L4GhostPrefix", IsNullable = false)]
        public string L4GhostPrefix
        {
            get;
            set;
        }        

        /// <summary>
        /// Gets L4_Api.
        /// </summary>
        [XmlElement("L4_Api", typeof(L4ApiComm), IsNullable = false)]
        public L4ApiComm L4_Api
        {
            get;
            set;
        }

        /// <summary>
        /// Gets L4_DB.
        /// </summary>
        [XmlElement("L4_DB", typeof(L4DBComm), IsNullable = false)]
        public L4DBComm L4_DB
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Configuration class of L4
    /// </summary>
    [Serializable()]
    public class L4ApiComm
    {
        /// <summary>
        /// Gets path piece information.
        /// </summary>
        [XmlElement("PathGetPieceInformation", IsNullable = false)]
        public string PathGetPieceInformation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets TimeoutWebService is in milliseconds.
        /// </summary>
        [XmlElement("TimeoutWebService", IsNullable = false)]
        public int TimeoutWebService
        {
            get;
            set;
        }   
    }

    /// <summary>
    /// Configuration class of L4
    /// </summary>
    [Serializable()]
    public class L4DBComm
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
        /// Gets ReadCycleTime.
        /// </summary>
        [XmlElement("ReadCycleTime", IsNullable = false)]
        public int ReadCycleTime
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ReadLifeTime.
        /// </summary>
        [XmlElement("ReadLifeTime", IsNullable = false)]
        public int ReadLifeTime
        {
            get;
            set;
        }
    }
}