using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HCM.Utility.Configuration
{
    /// <summary>
    /// Configuration class of TO Server Section.
    /// </summary>
    [Serializable()]
    public class TOServerSection
    {
        private TOInstance[] instances;

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
        [XmlArrayItem("Instance", typeof(TOInstance), IsNullable = false)]
        public TOInstance[] Instances
        {
            get { return this.instances; }
            set
            {
                this.instances = value;

                if (this.instances != null && this.instances.Length == 1 && this.instances[0].MachineGroup == "*")
                {
                    this.instances[0].AllMachineGroups = true;
                }
            }
        }

        /// <summary>
        /// Gets TimeoutToRetriesRequestedTO.
        /// </summary>
        [XmlElement("TimeoutToRetriesRequestedTO", IsNullable = false)]
        public long TimeoutToRetriesRequestedTO
        {
            get;
            set;
        }

        /// <summary>
        /// Gets CalculateInterferenceByTime.
        /// </summary>
        [XmlElement("CalculateInterferenceByTime", IsNullable = false)]
        public bool CalculateInterferenceByTime
        {
            get;
            set;
        }

        /// <summary>
        /// Gets AllowRetainTO.
        /// </summary>
        [XmlElement("AllowRetainTO", IsNullable = false)]
        public bool AllowRetainTO
        {
            get;
            set;
        }

        /// <summary>
        /// Gets WriteTOStepCompressed.
        /// </summary>
        [XmlElement("WriteTOStepCompressed", IsNullable = false)]
        public bool WriteTOStepCompressed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ReadTOStepCompressed.
        /// </summary>
        [XmlElement("ReadTOStepCompressed", IsNullable = false)]
        public bool ReadTOStepCompressed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets SimulateTransportOrder.
        /// </summary>
        [XmlElement("SimulateTransportOrder", IsNullable = false)]
        public bool SimulateTransportOrder
        {
            get;
            set;
        }

        /// <summary>
        /// Gets SHMMemory.
        /// </summary>
        [XmlElement("SHMMemory", typeof(TOMemory), IsNullable = false)]
        public TOMemory SHMMemory
        {
            get;
            set;
        }

        #region private methods
        /// <summary>
        /// GetInstanceByMachineGroup
        /// </summary>
        /// <param name="machine_group"></param>
        /// <returns></returns>
        public TOInstance GetInstanceByMachineGroup(string machine_group)
        {
            if (this.instances != null && this.instances.Length > 0)
            {
                if (this.instances.Length == 1 && this.instances[0].AllMachineGroups)
                {
                    return this.instances[0];
                }

                for (int i = 0; i < this.instances.Length; i++)
                {
                    if (this.instances[i].MachineGroup == machine_group)
                    {
                        return this.instances[i];
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// GetinstancesByReference
        /// </summary>
        /// <param name="reference"></param>
        /// <returns></returns>
        public TOInstance[] GetInstancesByReference(string reference)
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
    public class TOInstance
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
        /// Gets MachineGroup.
        /// </summary>
        [XmlAttribute("machinegroup")]
        public string MachineGroup
        {
            get;
            set;
        }

        /// <summary>
        /// Gets AllMachineGroups.
        /// </summary>
        [XmlIgnore]
        public bool AllMachineGroups
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
    /// Configuration class of Report.
    /// </summary>
    [Serializable()]
    public class TOMemory
    {
        /// <summary>
        /// Gets Name.
        /// </summary>
        [XmlElement("Name", IsNullable = false)]
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
        /// Gets Memory.
        /// </summary>
        [XmlElement("TAGS", typeof(TOMemoryTags), IsNullable = false)]
        public TOMemoryTags Memory
        {
            get;
            set;
        }

        /// <summary>
        /// Configuration class of Report Item.
        /// </summary>
        [Serializable()]
        [XmlType("TAGS")]
        public class TOMemoryTags
        {
            /// <summary>
            /// Gets max.
            /// </summary>
            [XmlAttribute("max")]
            public int max_tags
            {
                get;
                set;
            }

            /// <summary>
            /// Gets Cranes.
            /// </summary>
            [XmlElement("TAG", typeof(TOMemoryTag), IsNullable = false)]
            public TOMemoryTag[] Tags
            {
                get;
                set;
            }
        }

        /// <summary>
        /// Configuration class of Report Item.
        /// </summary>
        [Serializable()]
        public class TOMemoryTag
        {
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
            /// Gets index.
            /// </summary>
            [XmlAttribute("index")]
            public int index
            {
                get;
                set;
            }
        }
    }
}
