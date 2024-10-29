using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HSM.Utility.Configuration
{
    using HSM.Utility.Configuration.Enumerations;

    /// <summary>
    /// Configuration class of Tracking Server Section.
    /// </summary>
    [Serializable()]
    public class TRKServerSection
    {
        private TRKInstance[] instances;

        /// <summary>
        /// Gets RequestPort.
        /// </summary>
        //[XmlElement("RequestPort", IsNullable = false)]
        //public int RequestPort
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// Gets RequestIPAddress.
        /// </summary>
        //[XmlElement("RequestIPAddress", IsNullable = false)]
        //public string RequestIPAddress
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// Gets RequestLocalInterface.
        /// </summary>
        //[XmlElement("RequestLocalInterface", IsNullable = true)]
        //public string RequestLocalInterface
        //{
        //    get;
        //    set;
        //}

        [XmlArray("Instances")]
        [XmlArrayItem("Instance", typeof(TRKInstance), IsNullable = false)]
        public TRKInstance[] Instances
        {
            get { return this.instances; }
            set
            {
                this.instances = value;

                if (this.instances != null)
                {
                    if (this.instances.Length == 1 && this.instances[0].YardName == "*")
                    {
                        this.instances[0].All = true;
                        this.instances[0].Control = true;
                    }
                    else
                    {
                        TRKInstance instance_control = this.instances.FirstOrDefault(p => p.YardName == null || p.YardName == string.Empty);
                        if (instance_control != null)
                        {
                            instance_control.Control = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets RailDirection.
        /// </summary>
        [XmlElement("RailDirection", typeof(RailDirections), IsNullable = false)]
        public RailDirections RailDirection
        {
            get;
            set;
        }

        /// <summary>
        /// Gets RailDataIntegrityEnabled.
        /// </summary>
        [XmlElement("RailDataIntegrityEnabled", IsNullable = false)]
        public bool RailDataIntegrityEnabled
        {
            get;
            set;
        }        

        /// <summary>
        /// Gets RCPConsumer.
        /// </summary>
        [XmlElement("RCPConsumer", typeof(RCPConsumerSettings), IsNullable = false)]
        public RCPConsumerSettings RCPConsumer
        {
            get;
            set;
        }

        /// <summary>
        /// Gets AEIReaders.
        /// </summary>
        [XmlElement("AEIReaders", typeof(AEIReaderSettings), IsNullable = false)]
        public AEIReaderSettings AEIReaderConsumer
        {
            get;
            set;
        }

        #region private methods
        /// <summary>
        /// GetInstanceOfControl
        /// </summary>
        /// <param name="yard"></param>
        /// <returns></returns>
        public TRKInstance GetInstanceOfControl()
        {
            if (this.instances != null && this.instances.Length > 0)
            {
                if (this.instances.Length == 1 && this.instances[0].Control)
                {
                    return this.instances[0];
                }

                return this.instances.FirstOrDefault(p => p.Control);
            }

            return null;
        }

        /// <summary>
        /// GetinstancesByReference
        /// </summary>
        /// <param name="reference"></param>
        /// <returns></returns>
        public TRKInstance[] GetInstancesByReference(string reference)
        {
            if (this.instances != null && this.instances.Length > 0)
            {
                return this.instances.Where(p => p.Reference == reference).ToArray();
            }

            return null;
        }
        #endregion
    }

    /// <summary>
    /// Configuration class of Instance information.
    /// </summary>
    [Serializable()]
    public class TRKInstance
    {
        /// <summary>
        /// Gets Reference.
        /// </summary>
        [XmlAttribute("ref")]
        public string Reference
        {
            get;
            set;
        }

        /// <summary>
        /// Gets YardName.
        /// </summary>
        [XmlAttribute("yardname")]
        public string YardName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets AllYard.
        /// </summary>
        [XmlIgnore]
        public bool All
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets Control.
        /// </summary>
        [XmlIgnore]
        public bool Control
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets HeartBeat.
        /// </summary>
        [XmlAttribute("port")]
        public int Port
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
        /// Gets LocalInterface.
        /// </summary>
        [XmlAttribute("localinterface")]
        public string LocalInterface
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Configuration class of RCP Consumer Settings.
    /// </summary>
    [Serializable()]
    public class RCPConsumerSettings
    {
        /// <summary>
        /// Gets Port.
        /// </summary>
        [XmlElement("Port", IsNullable = false)]
        public int Port
        {
            get;
            set;
        }

        /// <summary>
        /// Gets IPAddress.
        /// </summary>
        [XmlElement("IPAddress", IsNullable = false)]
        public string IPAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Gets LocalInterface.
        /// </summary>
        [XmlElement("LocalInterface", IsNullable = true)]
        public string LocalInterface
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Configuration class of AEI Reader Consumer Settings.
    /// </summary>
    [Serializable()]
    public class AEIReaderSettings
    {
        /// <summary>
        /// Gets port.
        /// </summary>
        [XmlAttribute("port")]
        public int port
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ipaddress.
        /// </summary>
        [XmlAttribute("ipaddress")]
        public string ipaddress
        {
            get;
            set;
        }

        /// <summary>
        /// Gets AEI Reader.
        /// </summary>
        [XmlElement("AEIReader", typeof(AEIReader), IsNullable = false)]
        public AEIReader[] AEIReaders
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Configuration class of AEI Reader.
    /// </summary>
    [Serializable()]
    public class AEIReader
    {
        /// <summary>
        /// Gets number.
        /// </summary>
        [XmlAttribute("number")]
        public int number
        {
            get;
            set;
        }

        /// <summary>
        /// Gets name.
        /// </summary>
        [XmlAttribute("name")]
        public string name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets keepalive.
        /// </summary>
        [XmlAttribute("keepalive")]
        public int keepalive
        {
            get;
            set;
        }
    }
}
