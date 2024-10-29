using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace HSM.Utility.Configuration
{
    using Janus.Rodeo.Windows.Process.Rd_WatchDog;

    /// <summary>
    /// Configuration class of WD Server Section.
    /// </summary>
    [Serializable()]
    public class WDServerSection
    {
        /// <summary>
        /// Gets CycleTime.
        /// </summary>
        [XmlElement("CycleTime", IsNullable = false)]
        public int CycleTime
        {
            get;
            set;
        }

        /// <summary>
        /// Gets RedundancyEnabled.
        /// </summary>
        [XmlElement("RedundancyEnabled", IsNullable = false)]
        public bool RedundancyEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets PrimaryPort.
        /// </summary>
        [XmlElement("PrimaryPort", IsNullable = false)]
        public int PrimaryPort
        {
            get;
            set;
        }

        /// <summary>
        /// Gets SecondaryPort.
        /// </summary>
        [XmlElement("SecondaryPort", IsNullable = false)]
        public int SecondaryPort
        {
            get;
            set;
        }

        /// <summary>
        /// Gets PrimaryIPAddress.
        /// </summary>
        [XmlElement("PrimaryIPAddress", IsNullable = true)]
        public string PrimaryIPAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Gets SecondaryIPAddress.
        /// </summary>
        [XmlElement("SecondaryIPAddress", IsNullable = true)]
        public string SecondaryIPAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Gets CheckServerStatus.
        /// </summary>
        [XmlElement("CheckServerStatus", IsNullable = false)]
        public bool CheckServerStatus
        {
            get;
            set;
        }

        /// <summary>
        /// Gets UsePingToSwitch.
        /// </summary>
        [XmlElement("UsePingToSwitch", IsNullable = false)]
        public bool UsePingToSwitch
        {
            get;
            set;
        }        

        /// <summary>
        /// Gets Rodeo.
        /// </summary>
        [XmlElement("Rodeo", typeof(WDRodeo), IsNullable = false)]
        public WDRodeo Rodeo
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Processes.
        /// </summary>
        //[XmlElement("Processes", typeof(WDProcesses), IsNullable = false)]
        //public WDProcesses Processes
        //{
        //    get;
        //    set;
        //}

        [XmlArray("Processes")]
        [XmlArrayItem("Process", typeof(WDProcess), IsNullable = false)]
        public WDProcess[] Processes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets NICs.
        /// </summary>
        [XmlElement("NICs", typeof(WDNICs), IsNullable = false)]
        public WDNICs NICs
        {
            get;
            set;
        }

        /// <summary>
        /// Gets IPs.
        /// </summary>
        [XmlElement("IPs", typeof(WDIPs), IsNullable = false)]
        public WDIPs IPs
        {
            get;
            set;
        }

        /// <summary>
        /// Gets MASKs.
        /// </summary>
        [XmlElement("MASKs", typeof(WDOTHERs), IsNullable = false)]
        public WDOTHERs MASKs
        {
            get;
            set;
        }

        /// <summary>
        /// Gets GATEWAYs.
        /// </summary>
        [XmlElement("GATEWAYs", typeof(WDOTHERs), IsNullable = false)]
        public WDOTHERs GATEWAYs
        {
            get;
            set;
        }

        /// <summary>
        /// Gets DNSs.
        /// </summary>
        [XmlElement("DNSs", typeof(WDOTHERs), IsNullable = false)]
        public WDOTHERs DNSs
        {
            get;
            set;
        }

        #region private methods
        /// <summary>
        /// Get Heart beat from configuration
        /// </summary>
        /// <param name="executable"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public string GetHeartBeatByProcess(string executable, string args)
        {
            if (this.Processes != null && this.Processes.Length > 0)
            {
                for (int i = 0; i < this.Processes.Length; i++)
                {
                    if (this.Processes[i].Executable == executable)
                    {
                        if ((this.Processes[i].Args ?? string.Empty) == (args ?? string.Empty))
                        {
                            if (string.IsNullOrEmpty(this.Processes[i].HeartBeat))
                            {
                                break;
                            }
                            return string.Format(this.Processes[i].HeartBeat, Configurations.General.RodeoSector);
                        }
                    }
                }
            }

            return null;
        }
        #endregion
    }

    /// <summary>
    /// Configuration class of Rodeo
    /// </summary>
    [Serializable()]
    public class WDRodeo
    {
        /// <summary>
        /// Gets Master.
        /// </summary>
        [XmlElement("MasterFile", IsNullable = false)]
        public string Master
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Slave
        /// </summary>
        [XmlElement("SlaveFile", IsNullable = true)]
        public string Slave
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Configuration class of Processes
    /// </summary>
    //[Serializable()]
    //public class WDProcesses
    //{
    //    /// <summary>
    //    /// Gets L3.
    //    /// </summary>
    //    [XmlElement("L3Server", IsNullable = true)]
    //    public string L3
    //    {
    //        get;
    //        set;
    //    }

    //    /// <summary>
    //    /// Gets TO.
    //    /// </summary>
    //    [XmlElement("TOServer", IsNullable = true)]
    //    public string TO
    //    {
    //        get;
    //        set;
    //    }

    //    /// <summary>
    //    /// Gets Tracking.
    //    /// </summary>
    //    [XmlElement("TrackingServer", IsNullable = true)]
    //    public string Tracking
    //    {
    //        get;
    //        set;
    //    }

    //    /// <summary>
    //    /// Gets Safety.
    //    /// </summary>
    //    [XmlElement("SafetyServer", IsNullable = true)]
    //    public string Safety
    //    {
    //        get;
    //        set;
    //    }

    //    /// <summary>
    //    /// Gets PS.
    //    /// </summary>
    //    [XmlElement("RSServer", IsNullable = true)]
    //    public string RS
    //    {
    //        get;
    //        set;
    //    }

    //    /// <summary>
    //    /// Gets System.
    //    /// </summary>
    //    [XmlElement("SystemServer", IsNullable = true)]
    //    public string System
    //    {
    //        get;
    //        set;
    //    }

    //    /// <summary>
    //    /// Gets DBToXml.
    //    /// </summary>
    //    [XmlElement("DBToXmlServer", IsNullable = true)]
    //    public string DBToXml
    //    {
    //        get;
    //        set;
    //    }
        
    //    /// <summary>
    //    /// Gets RCP.
    //    /// </summary>
    //    [XmlElement("RCPService", IsNullable = true)]
    //    public string RCP
    //    {
    //        get;
    //        set;
    //    }

    //    /// <summary>
    //    /// Gets DVRServer.
    //    /// </summary>
    //    [XmlElement("DVRServer", IsNullable = true)]
    //    public string DVRServer
    //    {
    //        get;
    //        set;
    //    }

    //    /// <summary>
    //    /// Gets AcqServer.
    //    /// </summary>
    //    [XmlElement("AcqServer", IsNullable = true)]
    //    public string AcqServer
    //    {
    //        get;
    //        set;
    //    }
    //}

    /// <summary>
    /// Configuration class of Process information.
    /// </summary>
    [Serializable()]
    public class WDProcess
    {
        private string command;

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
        /// Gets HeartBeat.
        /// </summary>
        [XmlAttribute("hb")]
        public string HeartBeat
        {
            get;
            set;
        }

        /// <summary>
        /// Gets RunOnSlave.
        /// </summary>
        [XmlAttribute("slave")]
        public bool RunOnSlave
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Command.
        /// </summary>
        [XmlText]
        public string Command
        {
            get { return this.command; }
            set
            {
                this.command = value;

                string application = string.Empty;

                if (!string.IsNullOrEmpty(this.command))
                {
                    string[] argList = ProcessMonitor.extractParams(this.command);

                    if (argList.Length == 0)
                    {
                        application = string.Empty;

                        this.Args = string.Empty;
                    }
                    else
                    {
                        application = argList[0].Replace("\"", "");

                        this.Args = string.Join(" ", argList.Skip(1));
                    }
                }

                if (string.IsNullOrEmpty(application) || !File.Exists(application))
                {
                    this.Executable = string.Empty;
                    this.FullPath = string.Empty;
                    this.WorkingPath = string.Empty;
                }
                else
                {
                    FileInfo file = new FileInfo(application);

                    this.Executable = file.Name;
                    this.FullPath = file.FullName;
                    this.WorkingPath = file.DirectoryName;
                }
            }
        }

        /// <summary>
        /// Gets Args.
        /// </summary>
        [XmlIgnore]
        public string Args
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets Executable.
        /// </summary>
        [XmlIgnore]
        public string Executable
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets FullPath.
        /// </summary>
        [XmlIgnore]
        public string FullPath
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets WorkingPath.
        /// </summary>
        [XmlIgnore]
        public string WorkingPath
        {
            get;
            private set;
        }
    }

    /// <summary>
    /// Configuration class of NICs
    /// </summary>
    [Serializable()]
    public class WDNICs
    {
        /// <summary>
        /// Gets L1_NIC_1.
        /// </summary>
        [XmlElement("L1_NIC_1", IsNullable = true)]
        public string L1_NIC_1
        {
            get;
            set;
        }

        /// <summary>
        /// Gets L1_NIC_2.
        /// </summary>
        [XmlElement("L1_NIC_2", IsNullable = true)]
        public string L1_NIC_2
        {
            get;
            set;
        }

        /// <summary>
        /// Gets L2_NIC_1.
        /// </summary>
        [XmlElement("L2_NIC_1", IsNullable = true)]
        public string L2_NIC_1
        {
            get;
            set;
        }

        /// <summary>
        /// Gets L2_NIC_2.
        /// </summary>
        [XmlElement("L2_NIC_2", IsNullable = true)]
        public string L2_NIC_2
        {
            get;
            set;
        }

        /// <summary>
        /// Gets MGMT_NIC_1.
        /// </summary>
        [XmlElement("MGMT_NIC_1", IsNullable = true)]
        public string MGMT_NIC_1
        {
            get;
            set;
        }

        /// <summary>
        /// Gets MGMT_NIC_2.
        /// </summary>
        [XmlElement("MGMT_NIC_2", IsNullable = true)]
        public string MGMT_NIC_2
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Configuration class of IPs
    /// </summary>
    [Serializable()]
    public class WDIPs
    {
        /// <summary>
        /// Gets L1_IP_1.
        /// </summary>
        [XmlElement("L1_IP_1", IsNullable = true)]
        public string L1_IP_1
        {
            get;
            set;
        }

        /// <summary>
        /// Gets L1_IP_2.
        /// </summary>
        [XmlElement("L1_IP_2", IsNullable = true)]
        public string L1_IP_2
        {
            get;
            set;
        }

        /// <summary>
        /// Gets L2_IP_1.
        /// </summary>
        [XmlElement("L2_IP_1", IsNullable = true)]
        public string L2_IP_1
        {
            get;
            set;
        }

        /// <summary>
        /// Gets L2_IP_2.
        /// </summary>
        [XmlElement("L2_IP_2", IsNullable = true)]
        public string L2_IP_2
        {
            get;
            set;
        }

        /// <summary>
        /// Gets MGMT_IP_1.
        /// </summary>
        [XmlElement("MGMT_IP_1", IsNullable = true)]
        public string MGMT_IP_1
        {
            get;
            set;
        }

        /// <summary>
        /// Gets MGMT_IP_2.
        /// </summary>
        [XmlElement("MGMT_IP_2", IsNullable = true)]
        public string MGMT_IP_2
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Configuration class of OTHERs
    /// </summary>
    [Serializable()]
    public class WDOTHERs
    {
        /// <summary>
        /// Gets L1.
        /// </summary>
        [XmlElement("L1", IsNullable = true)]
        public string L1
        {
            get;
            set;
        }

        /// <summary>
        /// Gets L2.
        /// </summary>
        [XmlElement("L2", IsNullable = true)]
        public string L2
        {
            get;
            set;
        }

        /// <summary>
        /// Gets MGMT.
        /// </summary>
        [XmlElement("MGMT", IsNullable = true)]
        public string MGMT
        {
            get;
            set;
        }
    }
}