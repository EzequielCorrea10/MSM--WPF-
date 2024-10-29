using System;
using System.Xml.Serialization;

namespace HSM.Utility.Configuration
{
 
    /// <summary>
    /// Configuration class of TO Server Section.
    /// </summary>
    [Serializable()]
    public class RSServerSection
    {
        /// <summary>
        /// Gets RequestPort.
        /// </summary>
        [XmlElement("TimeProcess", IsNullable = false)]
        public int TimeProcess
        {
            get;
            set;
        }

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
        /// Gets RequestLocalInterface.
        /// </summary>
        [XmlElement("RequestLocalInterface", IsNullable = true)]
        public string RequestLocalInterface
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
        /// Gets DisableHouseKeeping.
        /// </summary>
        [XmlElement("DisableHouseKeeping", IsNullable = false)]
        public bool DisableHouseKeeping
        {
            get;
            set;
        }

        /// <summary>
        /// Gets AutomaticCancelJob.
        /// </summary>
        [XmlElement("AutomaticCancelJob", IsNullable = false)]
        public bool AutomaticCancelJob
        {
            get;
            set;
        }

        /// <summary>
        /// Gets SaveAutomaticJob.
        /// </summary>
        [XmlElement("SaveAutomaticJob", IsNullable = false)]
        public bool SaveAutomaticJob
        {
            get;
            set;
        }        

        /// <summary>
        /// Gets MaxAutomaticJobScheduled.
        /// </summary>
        [XmlElement("MaxAutomaticJobScheduled", IsNullable = false)]
        public int MaxAutomaticJobScheduled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets freezen_values.
        /// </summary>
        [XmlElement("freezen_values", IsNullable = false)]
        public bool freezen_values
        {
            get;
            set;
        }
    }
}
