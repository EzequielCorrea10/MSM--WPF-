using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MSM.Utility.Configuration
{
    /// <summary>
    /// Configuration class of Acq Server Section.
    /// </summary>
    [Serializable()]
    public class AcqServerSection
    {
        public AcqServerSection()
        { }

        /// <summary>
        /// Gets CHooks.
        /// </summary>
        [XmlArray("CHooks")]
        [XmlArrayItem("CHook", typeof(AcqMachineItem), IsNullable = false)]
        public AcqMachineItem[] CHooks
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Cranes.
        /// </summary>
        [XmlArray("Cranes")]
        [XmlArrayItem("Crane", typeof(AcqMachineItem), IsNullable = false)]
        public AcqMachineItem[] Cranes
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Configuration class of Machine information.
    /// </summary>
    [Serializable()]
    public class AcqMachineItem
    {
        /// <summary>
        /// Gets Name.
        /// </summary>
        [XmlAttribute("name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Timeout.
        /// </summary>
        [XmlElement("Timeout", IsNullable = false)]
        public int Timeout
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Bridge.
        /// </summary>
        [XmlElement("Bridge", typeof(AcqAntennaItem), IsNullable = true)]
        public AcqAntennaItem Bridge
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Trolley.
        /// </summary>
        [XmlElement("Trolley", typeof(AcqAntennaItem), IsNullable = true)]
        public AcqAntennaItem Trolley
        {
            get;
            set;
        }

        /// <summary>
        /// Gets STU.
        /// </summary>
        [XmlElement("STU", typeof(AcqSTUItem), IsNullable = true)]
        public AcqSTUItem STU
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Configuration class of Acquisition information.
    /// </summary>
    [Serializable()]
    public class AcqAntennaItem
    {
        /// <summary>
        /// Gets group.
        /// </summary>
        [XmlAttribute("group")]
        public int Group
        {
            get;
            set;
        }

        /// <summary>
        /// Gets IPAddress.
        /// </summary>
        [XmlAttribute("ipaddress")]
        public string IPAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Gets port.
        /// </summary>
        [XmlAttribute("port")]
        public int Port
        {
            get;
            set;
        }

        /// <summary>
        /// Gets factor.
        /// </summary>
        [XmlAttribute("factor")]
        public double Factor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets offset.
        /// </summary>
        [XmlAttribute("offset")]
        public double Offset
        {
            get;
            set;
        }

        /// <summary>
        /// Gets timeout.
        /// </summary>
        [XmlAttribute("timeout")]
        public int Timeout
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Configuration class of STU information.
    /// </summary>
    [Serializable()]
    public class AcqSTUItem
    {
        /// <summary>
        /// Gets IPAddress.
        /// </summary>
        [XmlAttribute("ipaddress")]
        public string IPAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Gets port.
        /// </summary>
        [XmlAttribute("port")]
        public int Port
        {
            get;
            set;
        }

        /// <summary>
        /// Gets channel.
        /// </summary>
        [XmlAttribute("channel")]
        public int Channel
        {
            get;
            set;
        }

        /// <summary>
        /// Gets factor.
        /// </summary>
        [XmlAttribute("factor")]
        public double Factor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets offset.
        /// </summary>
        [XmlAttribute("offset")]
        public double Offset
        {
            get;
            set;
        }

        /// <summary>
        /// Gets timeout.
        /// </summary>
        [XmlAttribute("timeout")]
        public int Timeout
        {
            get;
            set;
        }
    }
}