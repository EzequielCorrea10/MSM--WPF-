using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HSM.Utility.Configuration
{
    /// <summary>
    /// Configuration class of Catalog Section.
    /// </summary>
    [Serializable()]
    public class CatalogSection
    {
        /// <summary>
        /// Gets AlwaysDB.
        /// </summary>
        [XmlElement("AlwaysDB", IsNullable = false)]
        public bool AlwaysDB
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Troubleshooting.
        /// </summary>
        [XmlElement("Troubleshooting", IsNullable = false)]
        public string Troubleshooting
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Troubleshooting.
        /// </summary>
        [XmlElement("PathPDFReader", IsNullable = false)]
        public string PathPDFReader
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Folder.
        /// </summary>
        [XmlElement("Folder", IsNullable = false)]
        public string Folder
        {
            get;
            set;
        }
    }
}
