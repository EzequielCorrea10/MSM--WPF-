using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HCM.Utility.Configuration
{
    using Janus.Rodeo.Windows.Library.Rd_Log;
    using Janus.Rodeo.Windows.Library.UI.Common.Helpers;

    /// <summary>
    /// class of manage the main configurations parameters
    /// </summary>
    public class Configurations
    {
        #region private attributes
        /// <summary>
        /// use to lock the logical
        /// </summary>
        private static readonly object lockInstance = new object();

        /// <summary>
        /// Get the static instance of the class
        /// </summary>
        private static Configurations instance;
        #endregion

        #region private attributes
        /// <summary>
        /// root of the configuration
        /// </summary>
        private RootSection root;
        #endregion

        #region private properties
        /// <summary>
        /// Gets the Instance of the configuration class
        /// </summary>
        private static Configurations Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockInstance)
                    {
                        if (instance == null)
                        {
                            instance = new Configurations();
                        }
                    }
                }
                return instance;
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Configurations"/> class.
        /// </summary>
        private Configurations()
        {
            bool designMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
            if (designMode)
            {
                using (Stream stream = this.GetType().Assembly.GetManifestResourceStream(typeof(Configurations).Namespace + ".Configurations.xml"))
                {
                    this.root = CfgReader.Xml.GetItem<RootSection>(stream);
                }
            }
            else
            {
                string path = "Configurations.xml";
                if (!File.Exists(path))
                {
                    string directory = System.AppDomain.CurrentDomain.BaseDirectory;
                    if (directory.EndsWith(@"\"))
                        path = string.Format("{0}{1}", directory, "Configurations.xml");
                    else
                        path = string.Format(@"{0}\{1}", directory, "Configurations.xml");
                }

                using (FileStream cfgfile = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    this.root = CfgReader.Xml.GetItem<RootSection>(cfgfile);
                }
            }
        }
        #endregion

        #region public configurations
        /// <summary>
        /// Get General Section
        /// </summary>
        public static GeneralSection General
        {
            get
            {
                return Instance.root.General;
            }
        }

        /// <summary>
        /// Get Catalog Section
        /// </summary>
        public static CatalogSection Catalogs
        {
            get
            {
                return Instance.root.Catalog;
            }
        }

        /// <summary>
        /// Get L3 Server Section
        /// </summary>
        public static L3ServerSection L3Server
        {
            get
            {
                return Instance.root.L3Server;
            }
        }

        /// <summary>
        /// Get TO Server Section
        /// </summary>
        public static TOServerSection TOServer
        {
            get
            {
                return Instance.root.TOServer;
            }
        }

        /// <summary>
        /// Get TO Optimization Section
        /// </summary>
        public static TOOptimizationSection TOOptimization
        {
            get
            {
                return Instance.root.TOOptimization;
            }
        }

        /// <summary>
        /// Get Tracking Server Section
        /// </summary>
        public static TRKServerSection TRKServer
        {
            get
            {
                return Instance.root.TRKServer;
            }
        }

        /// <summary>
        /// Get Safety Server Section
        /// </summary>
        public static SafetyServerSection SafetyServer
        {
            get
            {
                return Instance.root.SafetyServer;
            }
        }


        /// <summary>
        /// Get program scheduler Server Section
        /// </summary>
        public static RSServerSection RSServer
        {
            get
            {
                return Instance.root.RSServer;
            }
        }


        /// <summary>
        /// Get System Server Section
        /// </summary>
        public static SystemServerSection SystemServer
        {
            get
            {
                return Instance.root.SystemServer;
            }
        }

        /// <summary>
        /// Get DVR Server Section
        /// </summary>
        public static DVRServerSection DVRServer
        {
            get
            {
                return Instance.root.DVRServer;
            }
        }

        /// <summary>
        /// Get Acquisition Server Section
        /// </summary>
        public static AcqServerSection AcqServer
        {
            get
            {
                return Instance.root.AcqServer;
            }
        }

        /// <summary>
        /// Get WD Server Section
        /// </summary>
        public static WDServerSection WDServer
        {
            get
            {
                return Instance.root.WDServer;
            }
        }

        /// <summary>
        /// Get HMI Section
        /// </summary>
        public static HMISection HMIs
        {
            get
            {
                return Instance.root.HMIs;
            }
        }
        #endregion

    }
}
