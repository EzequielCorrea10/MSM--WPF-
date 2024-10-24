using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

namespace MSM.DBToXML.Server.Model.Handlers
{
    using Janus.Rodeo.Windows.Library.Rd_Log;
    using Janus.Rodeo.Windows.Library.Rd_Common;
    using Janus.Rodeo.Windows.Library.UI.Common;
    using Janus.Rodeo.Windows.Library.UI.Common.Helpers;

    using MSM.Database;
    using MSM.DBToXML.Server.Model.Structures;
    using MSM.DBToXML.Server.Model.Enumerations;
    using MSM.Utility.Common.Handlers;
    using MSM.Utility.Configuration;

    /// <summary>
    /// Class to exchange information with database
    /// </summary>
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
            this._catalogs = new Structures.Catalogs();
        }
        #endregion

        #region access methods
        /// <summary>
        /// Load all the catalog required
        /// </summary>
        public static void LoadCatalogs()
        {
            Instance._catalogs._clients = MSM.Sys.Server.Common.Handlers.DBAccess.GetClients(false).ToArray();
            Instance._catalogs._dict_clients = Instance._catalogs._clients.ToDictionary(p => p.Name, p => p);
        }

        /// <summary>
        /// Generate All tables
        /// </summary>
        public static void GenerateAllTables()
        {
            GenerateXML<MSM_Drive_Process>();
            GenerateXML<MSM_Drive_Control>();
            GenerateXML<MSM_Drive_Failure>();
            GenerateXML<MSM_Drive_Statuse>();
            GenerateXML<MSM_Drive_Type>();
            GenerateXML<MSM_Ground_EStop_Failure>();
            GenerateXML<MSM_Ground_EStop_Group>();
            GenerateXML<MSM_Ground_EStop_Interface>();
            GenerateXML<MSM_Ground_EStop_Panel>();
            GenerateXML<MSM_Ground_EStop_Request>();
            GenerateXML<MSM_HoldOn_Reason>();
            GenerateXML<MSM_Job_Type_Route>();
            GenerateXML<MSM_Job_Type>();
            GenerateXML<MSM_Location_Group>();
            GenerateXML<MSM_Location_Range>();
            GenerateXML<MSM_Machine_Drive>();
            GenerateXML<MSM_Machine_Event_Type>();
            GenerateXML<MSM_Machine_Exit_Location>();
            GenerateXML<MSM_Machine_Exit_Zone>();
            GenerateXML<MSM_Machine_Failure>();
            GenerateXML<MSM_Machine_Interlock>();
            GenerateXML<MSM_Message_Type>();
            GenerateXML<MSM_Pick_List_Groups>();
            GenerateXML<MSM_Pick_List_Groups_All>();
            GenerateXML<MSM_Pick_Lists>();
            GenerateXML<MSM_Pick_Lists_All>();
            GenerateXML<MSM_Piece_Event_Type>();
            //GenerateXML<MSM_Piece_Next_Step>();
            GenerateXML<MSM_PLC_Module>();
            GenerateXML<MSM_PLC_Rack>();
            GenerateXML<MSM_PLC>();
            GenerateXML<MSM_PLC_IO>();
            GenerateXML<MSM_PLC_VIO>();
            GenerateXML<MSM_Request_Interlock>();
            GenerateXML<MSM_Request_Signal>();
            GenerateXML<MSM_Request_Transport_Dependency>();
            GenerateXML<MSM_Request_Type_Signal>();
            GenerateXML<MSM_Request_Type>();
            GenerateXML<MSM_Request>();
            GenerateXML<MSM_Setting_Value>();
            GenerateXML<MSM_RCP_ErrorCode>();
            GenerateXML<MSM_RCP_Flag>();
            GenerateXML<MSM_RCP_OperationMode>();
            GenerateXML<MSM_RCP_Config>();
            GenerateXML<MSM_Troubleshooting_File>();
            GenerateXML<MSM_Troubleshooting_Reference>();
            GenerateXML<MSM_Zone_Dependency>();
            GenerateXML<MSM_Zone_Event_Type>();
            GenerateXML<MSM_Zone_Fence>();
            GenerateXML<MSM_Zone_Interlock>();
            GenerateXML<MSM_Zone_Machine>();
            GenerateXML<MSM_Zone_Section>();
            GenerateXML<MSM_Zone_Type>();
            GenerateXML<MSM_Zone>();
            GenerateXML<MSM_File>();
            GenerateXML<MSM_File_Type>();
            GenerateXML<Rodeo_Client_Credential>();
            GenerateXML<Rodeo_Client_Type>();
            GenerateXML<Rodeo_Client>();
            GenerateXML<Rodeo_Event_Type>();
            GenerateXML<Rodeo_Location_Type>();
            GenerateXML<Rodeo_Location>();
            GenerateXML<Rodeo_Position>();
            GenerateXML<Rodeo_Machine_Group>();
            GenerateXML<Rodeo_Machine_Statuse>();
            GenerateXML<Rodeo_Machine_Type_Position>();
            GenerateXML<Rodeo_Machine_Type>();
            GenerateXML<Rodeo_Machine>();
            GenerateXML<Rodeo_Network_Component_Alarm>();
            GenerateXML<Rodeo_Network_Component_Type>();
            GenerateXML<Rodeo_Network_Component>();
            GenerateXML<Rodeo_Network>();
            GenerateXML<Rodeo_Piece_Statuse>();
            GenerateXML<Rodeo_Piece_Type>();
            GenerateXML<Rodeo_Piece_Alloy>();
            GenerateXML<Rodeo_Piece_Alloy_Family>();
            GenerateXML<Rodeo_Piece_Type>();
            GenerateXML<Rodeo_Setting_Group_Machine_Type>();
            GenerateXML<Rodeo_Setting_Group>();
            GenerateXML<Rodeo_Setting_Tag>();
            GenerateXML<Rodeo_TO_Action>();
            GenerateXML<Rodeo_TO_Direction>();
            GenerateXML<Rodeo_TO_ErrorCode>();
            GenerateXML<Rodeo_TO_Piece>();
            //GenerateXML<Rodeo_TO_Route_Step>();
            //GenerateXML<Rodeo_TO_Route>();
            GenerateXML<Rodeo_TO_Statuse>();
            GenerateXML<Rodeo_TO_Step_ErrorCode>();
            GenerateXML<Rodeo_TO_Type>();
            GenerateXML<Rodeo_Yard>();
            GenerateXML<MSM_Bridge_WorkMode>();
            GenerateXML<MSM_Trolley_WorkMode>();
            GenerateXML<MSM_Hoist_WorkMode>();
            GenerateXML<MSM_Grab_WorkMode>();
        }

        /// <summary>
        /// Transfer All tables
        /// </summary>
        public static void TransferAllTables(CancellationToken token)
        {
            IPHostEntry currentHost = Dns.GetHostEntry(Dns.GetHostName());

            MSM.Sys.Server.Common.Catalogs.CT_Client[] clients = Instance._catalogs._clients;

            for (int i = 0; i < clients.Length; i++)
            {
                if (string.IsNullOrEmpty(clients[i].Type.AppPath))
                {
                    continue;
                }

                if (string.IsNullOrEmpty(clients[i].OSUser) || string.IsNullOrEmpty(clients[i].IPAddress))
                {
                    continue;
                }

                string path = string.Format("{0}{1}", clients[i].IPAddress, clients[i].Type.AppPath);

                if (clients[i].Type.Reference == MSM.Sys.Server.Common.Enumerations.ClientTypes.Web)
                {
                    continue;
                }

                string password = CommonFunctions.DecryptPassword(clients[i].OSPassword);

                if (clients[i].Type.Reference == MSM.Sys.Server.Common.Enumerations.ClientTypes.Server)
                {
                    bool found = false;
                    foreach (var ip in currentHost.AddressList)
                    {
                        if (ip.AddressFamily == AddressFamily.InterNetwork && ip.ToString() == clients[i].IPAddress)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        XmlDatabase.TransferXml(Configurations.Catalogs.Folder, clients[i].OSUser, password, path);
                    }
                }
                else
                {
                    XmlDatabase.TransferXml(Configurations.Catalogs.Folder, clients[i].OSUser, password, path);
                }

                if (token.IsCancellationRequested)
                {
                    break;
                }
            }
        }
        #endregion

        #region private methods
        /// <summary>
        /// List all the tables to be created
        /// </summary>
        private static void GenerateXML<T>() where T : class
        {
            using (MSMDataContext DB = new MSMDataContext(Configurations.General.ConnectionString))
            {
                List<T> lstElements = DB.GetTable<T>().ToList();

                if (!XmlDatabase.GenerateXML<T>(lstElements, Configurations.Catalogs.Folder))
                {
                    RdTrace.Debug("Error generating {0} table", typeof(T).Name);
                }
            }
        }
        #endregion
    }
}
