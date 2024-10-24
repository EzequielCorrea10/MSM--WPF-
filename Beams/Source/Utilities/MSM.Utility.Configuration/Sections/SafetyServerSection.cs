using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MSM.Utility.Configuration
{
    /// <summary>
    /// Configuration class of Safety Server Section.
    /// </summary>
    [Serializable()]
    public class SafetyServerSection
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
        /// Gets RequestLocalInterface.
        /// </summary>
        [XmlElement("RequestLocalInterface", IsNullable = true)]
        public string RequestLocalInterface
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ValidateSafetyBetweenYards.
        /// </summary>
        [XmlElement("ValidateSafetyBetweenYards", IsNullable = false)]
        public bool ValidateSafetyBetweenYards
        {
            get;
            set;
        }        
    }
}
