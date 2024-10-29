//using CPL.Database;
using TagLoader.Clases;
//using CPL.Utility.Common.Handlers;
//using CPL.Utility.Configuration;
using Janus.Rodeo.Windows.Library.Rd_Log;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSM.Database;
using HSM.Utility.Configuration;
using HSM.Utility.Common.Handlers;

namespace TagLoader.Handlers
{
    internal class DBAccess : DBAccessBase
    {
        #region private attributes
        /// <summary>
        /// parameters of configuration
        /// </summary>
        private Catalogs _catalogs;
        #endregion

        #region private static attributes
        /// <summary>
        /// Get the static instance of the class
        /// </summary>
        private static DBAccess instance;
        #endregion

        #region protected properties
        /// <summary>
        /// Gets the Instance of the Rodeo class
        /// </summary>
        private static DBAccess Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockInstance)
                    {
                        if (instance == null)
                        {
                            instance = new DBAccess();
                        }
                    }
                }
                return instance;
            }
        }
        #endregion

        #region public properties
        /// <summary>
        /// parameters of configuration
        /// </summary>
        public static Catalogs Catalogs
        {
            get { return Instance._catalogs; }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DBAccess"/> class.
        /// </summary>
        private DBAccess()
        {
            this._catalogs = new Catalogs();
        }
        #endregion

        #region access methods
        /// <summary>
        /// Load all the catalog required
        /// </summary>
        public static void LoadCatalogs()
        {
            Instance.LoadClientTypes();
            Instance.LoadClients();
        }

        #endregion

        #region private methods
        /// <summary>
        /// LoadClientTypes
        /// </summary>
        private void LoadClientTypes()
        {
            if (this._catalogs._client_types != null)
                this._catalogs._client_types.Clear();
            else
                this._catalogs._client_types = new Dictionary<int, Rodeo_Client_Type>();

            using (HSMDataContext DB = new HSMDataContext(Configurations.General.ConnectionString))
            {
                //DataLoadOptions dlo = new DataLoadOptions();
                //dlo.LoadWith<CPL_Pick_List>(p => p.CPL_Pick_List_Group);
                //DB.LoadOptions = dlo;
                DB.DeferredLoadingEnabled = false;

                foreach (Rodeo_Client_Type item in DB.Rodeo_Client_Types.Where(p => p.Active))
                {
                    Instance._catalogs._client_types[item.IdClientType] = item;
                }

                RdTrace.Debug("{0} Rows defined for Client types", this._catalogs._client_types.Count());
            }
        }

        /// <summary>
        /// LoadClients
        /// </summary>
        private void LoadClients()
        {
            if (this._catalogs._clients != null)
                this._catalogs._clients.Clear();
            else
                this._catalogs._clients = new Dictionary<int, Rodeo_Client>();

            using (HSMDataContext DB = new HSMDataContext(Configurations.General.ConnectionString))
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<Rodeo_Client>(p => p.Rodeo_Client_Type);
                DB.LoadOptions = dlo;
                DB.DeferredLoadingEnabled = false;

                foreach (Rodeo_Client item in DB.Rodeo_Clients.Where(p => p.Active))
                {
                    Instance._catalogs._clients[item.IdClient] = item;
                }

                RdTrace.Debug("{0} Rows defined for Clients", this._catalogs._clients.Count());
            }
        }

        #endregion
    }
}
