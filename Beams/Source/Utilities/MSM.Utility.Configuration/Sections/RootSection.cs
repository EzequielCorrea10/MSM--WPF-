using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MSM.Utility.Configuration
{
    /// <summary>
    /// Configuration class of Root Section.
    /// </summary>
    [XmlRoot("MSM", Namespace = "", IsNullable = false)]
    public class RootSection
    {
        /// <summary>
        /// Gets General.
        /// </summary>
        [XmlElement("General", typeof(GeneralSection), IsNullable = false)]
        public GeneralSection General
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Catalog.
        /// </summary>
        [XmlElement("Catalogs", typeof(CatalogSection), IsNullable = false)]
        public CatalogSection Catalog
        {
            get;
            set;
        }

        /// <summary>
        /// Gets L3Server.
        /// </summary>
        [XmlElement("L3Server", typeof(L3ServerSection), IsNullable = true)]
        public L3ServerSection L3Server
        {
            get;
            set;
        }

        /// <summary>
        /// Gets TOServer.
        /// </summary>
        [XmlElement("TOServer", typeof(TOServerSection), IsNullable = true)]
        public TOServerSection TOServer
        {
            get;
            set;
        }

        /// <summary>
        /// Gets TOOptimization.
        /// </summary>
        [XmlElement("TOOptimization", typeof(TOOptimizationSection), IsNullable = true)]
        public TOOptimizationSection TOOptimization
        {
            get;
            set;
        }

        /// <summary>
        /// Gets TRKServer.
        /// </summary>
        [XmlElement("TrackingServer", typeof(TRKServerSection), IsNullable = true)]
        public TRKServerSection TRKServer
        {
            get;
            set;
        }

        /// <summary>
        /// Gets SafetyServer.
        /// </summary>
        [XmlElement("SafetyServer", typeof(SafetyServerSection), IsNullable = true)]
        public SafetyServerSection SafetyServer
        {
            get;
            set;
        }

        /// <summary>
        /// Gets RSServer.
        /// </summary>
        [XmlElement("RSServer", typeof(RSServerSection), IsNullable = true)]
        public RSServerSection RSServer
        {
            get;
            set;
        }

        /// <summary>
        /// Gets SystemServer.
        /// </summary>
        [XmlElement("SystemServer", typeof(SystemServerSection), IsNullable = true)]
        public SystemServerSection SystemServer
        {
            get;
            set;
        }

        /// <summary>
        /// Gets DVRServer.
        /// </summary>
        [XmlElement("DVRServer", typeof(DVRServerSection), IsNullable = true)]
        public DVRServerSection DVRServer
        {
            get;
            set;
        }

        /// <summary>
        /// Gets AcqServer.
        /// </summary>
        [XmlElement("AcqServer", typeof(AcqServerSection), IsNullable = true)]
        public AcqServerSection AcqServer
        {
            get;
            set;
        }

        /// <summary>
        /// Gets WDServer.
        /// </summary>
        [XmlElement("WDServer", typeof(WDServerSection), IsNullable = true)]
        public WDServerSection WDServer
        {
            get;
            set;
        }

        /// <summary>
        /// Gets HMIs.
        /// </summary>
        [XmlElement("HMIs", typeof(HMISection), IsNullable = true)]
        public HMISection HMIs
        {
            get;
            set;
        }
    }
}
