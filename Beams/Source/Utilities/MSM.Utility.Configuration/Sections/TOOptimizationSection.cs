using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HSM.Utility.Configuration
{
    /// <summary>
    /// Configuration class of TO Server Section.
    /// </summary>
    [Serializable()]
    public class TOOptimizationSection
    {
        /// <summary>
        /// Gets Path_Rules.
        /// </summary>
        [XmlElement("Path_Rules", IsNullable = false)]
        public string Path_Rules
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Current_Rule.
        /// </summary>
        [XmlElement("Current_Rule", IsNullable = false)]
        public string Current_Rule
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Path_Rules.
        /// </summary>
        [XmlElement("Path_CSV", IsNullable = false)]
        public string Path_CSV
        {
            get;
            set;
        }
    }
}
