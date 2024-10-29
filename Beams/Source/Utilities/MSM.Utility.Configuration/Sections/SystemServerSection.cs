using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HSM.Utility.Configuration
{
    /// <summary>
    /// Configuration class of System Server Section.
    /// </summary>
    [Serializable()]
    public class SystemServerSection
    {
        /// <summary>
        /// Gets EventQueue.
        /// </summary>
        [XmlElement("EventQueue", typeof(SystemEventQueue), IsNullable = false)]
        public SystemEventQueue EventQueue
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Connectivity_timeout.
        /// </summary>
        [XmlElement("Connectivity_timeout", IsNullable = false)]
        public int Connectivity_timeout
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Server_inactivity_timeout.
        /// </summary>
        [XmlElement("Server_inactivity_timeout", IsNullable = false)]
        public int Server_inactivity_timeout
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Always_validate_login.
        /// </summary>
        [XmlElement("Always_validate_login", IsNullable = false)]
        public bool Always_validate_login
        {
            get;
            set;
        }

        /// <summary>
        /// Gets NICs.
        /// </summary>
        [XmlElement("NICs", typeof(SystemNICs), IsNullable = false)]
        public SystemNICs NICs
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Action_confirm_user.
        /// </summary>
        [XmlElement("Action_confirm_user", IsNullable = false)]
        public string Action_confirm_user
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Action_confirm_pass.
        /// </summary>
        [XmlElement("Action_confirm_pass", IsNullable = false)]
        public string Action_confirm_pass
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Configuration class of Event Queue
    /// </summary>
    [Serializable()]
    public class SystemEventQueue
    {
        /// <summary>
        /// Gets Host.
        /// </summary>
        [XmlElement("Host", IsNullable = true)]
        public string Host
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Name.
        /// </summary>
        [XmlElement("Name", IsNullable = true)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Username.
        /// </summary>
        [XmlElement("Username", IsNullable = true)]
        public string Username
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Password.
        /// </summary>
        [XmlElement("Password", IsNullable = true)]
        public string Password
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Configuration class of NICs
    /// </summary>
    [Serializable()]
    public class SystemNICs
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
