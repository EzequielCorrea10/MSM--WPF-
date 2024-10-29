using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HCM.Utility.Configuration
{
    /// <summary>
    /// Configuration class of DVR Server Section.
    /// </summary>
    [Serializable()]
    public class DVRServerSection
    {
        public DVRServerSection()
        { }

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
        /// Gets Machines.
        /// </summary>
        [XmlArray("Machines")]
        [XmlArrayItem("Machine", typeof(DVRMachineItem), IsNullable = false)]
        public DVRMachineItem[] Machines
        {
            get;
            set;
        }

        /// <summary>
        /// Gets CameraSettings.
        /// </summary>
        [XmlElement("CameraSettings", typeof(CameraSetting), IsNullable = false)]
        public CameraSetting CameraSettings
        {
            get;
            set;
        }

        /// <summary>
        /// Gets TimeVideoDays.
        /// </summary>
        [XmlElement("TimeVideoDays", IsNullable = false)]
        public int TimeVideoDays
        {
            get;
            set;
        }

        /// <summary>
        /// Gets TimeVideoMs.
        /// </summary>
        [XmlElement("TimeVideoMs", IsNullable = false)]
        public int TimeVideoMs
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Configuration class of Machine information.
    /// </summary>
    [Serializable()]
    public class DVRMachineItem
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
        /// Gets DefaultOperationCamera.
        /// </summary>
        [XmlElement("DefaultOperationCamera", IsNullable = true)]
        public string DefaultOperationCamera
        {
            get;
            set;
        }

        [XmlArray("OperationCameras")]
        [XmlArrayItem("OperationCamera", typeof(DVRCameraItem), IsNullable = false)]
        public DVRCameraItem[] OperationCameras
        {
            get;
            set;
        }

        ///// <summary>
        ///// Gets Operation Cameras.
        ///// </summary>
        //[XmlElement("OperationCamera", typeof(DVRCameraItem), IsNullable = false)]
        //public DVRCameraItem OperationCamera
        //{
        //    get;
        //    set;
        //}
    }

    /// <summary>
    /// Configuration class of Camera information.
    /// </summary>
    [Serializable()]
    public class DVRCameraItem
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
        /// Gets Folder.
        /// </summary>
        [XmlAttribute("folder")]
        public string Folder
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
        /// Gets PTZEnabled.
        /// </summary>
        [XmlAttribute("PTZEnabled")]
        public bool PTZEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets username.
        /// </summary>
        [XmlAttribute("username")]
        public string Username
        {
            get;
            set;
        }

        /// <summary>
        /// Gets password.
        /// </summary>
        [XmlAttribute("password")]
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ProxyRTSP.
        /// </summary>
        [XmlElement("ProxyRTSP", typeof(DVRProxyItem), IsNullable = true)]
        public DVRProxyItem ProxyRTSP
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Configuration class of Proxy information.
    /// </summary>
    [Serializable()]
    public class DVRProxyItem
    {
        /// <summary>
        /// Gets ondemand.
        /// </summary>
        [XmlAttribute("ondemand")]
        public bool OnDemand
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
        /// Gets username.
        /// </summary>
        [XmlAttribute("username")]
        public string Username
        {
            get;
            set;
        }

        /// <summary>
        /// Gets password.
        /// </summary>
        [XmlAttribute("password")]
        public string Password
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Configuration class of Camera Settings.
    /// </summary>
    [Serializable()]
    public class CameraSetting
    {
        /// <summary>
        /// Gets StorageFolder.
        /// </summary>
        [XmlElement("StorageFolder", IsNullable = false)]
        public string StorageFolder
        {
            get;
            set;
        }

        /// <summary>
        /// Gets SharingVideoFolder.
        /// </summary>
        [XmlElement("SharingVideoFolder", IsNullable = false)]
        public string SharingVideoFolder
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Username.
        /// </summary>
        [XmlElement("Username", IsNullable = false)]
        public string _Username
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Password.
        /// </summary>
        [XmlElement("Password", IsNullable = false)]
        public string _Password
        {
            get;
            set;
        }

        /// <summary>
        /// Gets VirtualInput.
        /// </summary>
        [XmlElement("VirtualInput", IsNullable = false)]
        public int VirtualInput
        {
            get;
            set;
        }
    }
}