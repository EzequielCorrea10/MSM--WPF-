using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCM.Utility.Common.Constants
{
    /// <summary>
    /// Constant of configuration
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// Constants
        /// </summary>
        public const string SYSTEM_USERNAME = "SYSTEM";
        public const string LEVEL3_USERNAME = "L4";
        public const string STORAGE_NAME = "Storage";

        public const bool SYSTEM_ROUTE_Z_USED = false;

        public const short DEFAULT_LOCATION_TOLX = 500;
        public const short DEFAULT_LOCATION_TOLY = 500;
        public const short DEFAULT_LOCATION_TOLZ = 800;
        public const short DEFAULT_LOCATION_HEADING = 180;

        public const short DEFAULT_CRANE_Z_TRAVEL = 6500;
        public const short MIN_CRANE_Z_TRAVEL = 4000;

        public const short DEFAULT_CGRAB_HEADING = 180;
        public const short DEFAULT_SEMIGRAB_HEADING = 180;

        public const short SYSTEM_MIN_Z_ORDER = 1;
        public const short SYSTEM_MIN_LOCATION_ORDER = 1;
        public const short SYSTEM_MIN_MACHINE_POSITION_ORDER = 1;
        public const int SYSTEM_ABSOLUTE_MIN_X_POSITION = -6500;
        public const int SYSTEM_ABSOLUTE_MAX_X_POSITION = 270000;
        public const int SYSTEM_ABSOLUTE_MIN_Y_POSITION = 0;
        public const int SYSTEM_ABSOLUTE_MAX_Y_POSITION = 30000;
        public const int SYSTEM_MIN_Z_POSITION = 0;
        public const int SYSTEM_MAX_Z_POSITION = 10000;
        public const int SYSTEM_NULL_VALUE = -9999;

        /// <summary>
        /// Yards
        /// </summary>
        public const string Y_AUTOMATIC = "U01";
        public const string Y_SEMIAUTOMATIC = "U00";

        /// <summary>
        /// Event Type
        /// </summary>
        public const string ET_M_ENABLED = "Command Enabled";
        public const string ET_M_PAUSE = "Command Pause";
        public const string ET_M_RESET = "Command Reset";
        public const string ET_M_SWITCH_MANUAL_DELAY = "Command Switch Manual Delay";
        public const string ET_M_OPERATION_MODE = "Command Operation Mode";
        public const string ET_M_HOLD = "Command Hold";
        public const string ET_M_PARKING = "Command Parking";

        public const string ET_REQUEST_JOB = "Request Job";
        public const string ET_CANCEL_JOB = "Cancel Job";
        public const string ET_JOB_STATUS = "Job Status";
        public const string ET_REQUEST_PICKUP = "Request Pickup";
        public const string ET_CONTINUE_PICKUP = "Continue Pickup";
        public const string ET_CANCEL_PICKUP = "Cancel Pickup";
        public const string ET_FINISH_PICKUP = "Finish Pickup";
        public const string ET_REDIRECT_PICKUP = "Redirect Pickup";
        public const string ET_REQUEST_TRANPORT_ORDER = "Request Transport Order";
        public const string ET_CONTINUE_TRANSPORT_ORDER = "Continue Transport Order";
        public const string ET_CANCEL_TRANPORT_ORDER = "Cancel Transport Order";
        public const string ET_REDIRECT_TRANSPORT_ORDER = "Redirect Transport Order";
        public const string ET_REQUEST_MLPICKUP = "Request Manual Pickup";
        public const string ET_REQUEST_MLSTORAGE = "Request Manual Storage";
        public const string ET_REQUEST_HOUSEKEEPING = "Request Housekeeping";
        public const string ET_REQUEST_PARKING = "Request Parking";
        public const string ET_REQUEST_SWITCH_MANUAL = "Request Switch Manual";
        public const string ET_REQUEST_SCAN = "Request Scan";
        public const string ET_ZONE_UPDATED = "Zone Updated";
        public const string ET_S_DISABLE_REQUESTED = "L2 Disable Requested";
        public const string ET_S_ENABLE_REQUESTED = "L2 Enable Requested";
        public const string ET_S_DISABLE_AUTHORIZED = "L2 Disable Authorized";
        public const string ET_REQ_BYPASS = "Eq. Bypass";
        public const string ET_ZONE_STORAGE = "Zone Storage";
        public const string ET_PIECE_ATTR_UPDATE = "Piece Attr. Updated";
        public const string ET_PIECE_POSITION = "Piece Position";
        public const string ET_PIECE_DISABLE = "Piece Disabled";
        public const string ET_PIECE_RETENTION = "Piece Retention";
        public const string ET_GHOST_CREATED = "Ghost Piece";
        public const string ET_PIECE_RENAME = "Piece Rename";
        public const string ET_PIECE_REMOVE = "Piece Remove";
        public const string ET_MANAGE_USER = "Manage Users";
        public const string ET_LOG_USER = "Log Users";
        public const string ET_MODIFY_PRESET = "Modify Preset";
        public const string ET_LOCGROUP_STATUS = "Loc. Group Status";
        public const string ET_LOCATION_STATUS = "Location Status";
        public const string ET_PROXY_MANAGEMENT = "Proxy Management";
        public const string ET_L3_REQUEST_DATA = "L3 Request Data";
        public const string ET_L3_UPDATE_LOCATION = "L3 Update Location";

        public const string ET_LASER_CALIBRATION = "RCP Lasers Calibration";
        public const string ET_DXDY_CALIBRATION = "RCP DX/DY Calibration";
        public const string ET_SAVE_CALIBRATION = "RCP Save Configuration";

        public const string ET_RAIL_CAR_ENTRANCE = "Rail Entrance";
        public const string ET_RAIL_CAR_EXIT = "Rail Exit";
        public const string ET_RAIL_CORRECTED = "Rail Corrected";
        public const string ET_RAIL_SCAN_RESET = "Rail Scan Reset";
        public const string ET_TRUCK_ENTERED = "Truck Entered";
        public const string ET_TRUCK_CORRECTED = "Truck Corrected";
        public const string ET_TRUCK_CONFIRMED = "Truck Confirmed";
        public const string ET_TRUCK_EXIT = "Truck Exit";
    }

    /// <summary>
    /// Constant of Application
    /// </summary>
    public class Applications
    {
        public const int PORT_TO_DEFAULT = 5000;
        public const int PORT_L3_DEFAULT = 5010;
        public const int PORT_TRK_DEFAULT = 5020;
        public const int PORT_SAFETY_DEFAULT = 5030;
        public const int PORT_RS_DEFAULT = 5040;
        public const int PORT_DVR_DEFAULT = 5050;

        public const int INDEX_WD_SRV = 1;
        public const int INDEX_L3_SRV = 2;
        public const int INDEX_TO_SRV = 3;
        public const int INDEX_TRK_SRV = 4;
        public const int INDEX_SAFETY_SRV = 5;
        public const int INDEX_RS_SRV = 6;
        public const int INDEX_DBTOXML_SRV = 7;
        public const int INDEX_SYSTEM_SRV = 8;
        public const int INDEX_DVR_SRV = 1;
        public const int INDEX_ACQ_SRV = 2;

        //public const string HB_L3_SRV = "{0}.HB_L3_Server";
        //public const string HB_TO_SRV = "{0}.HB_TO_Server";
        //public const string HB_DVR_SRV = "{0}.HB_DVR_Server";
        //public const string HB_TRK_SRV = "{0}.HB_TRK_Server";
        //public const string HB_SAFETY_SRV = "{0}.HB_SAFETY_Server";
        //public const string HB_RS_SRV = "{0}.HB_RS_Server";
        //public const string HB_DBTOXML_SRV = "{0}.HB_DBTOXML_Server";
        //public const string HB_SYSTEM_SRV = "{0}.HB_SYSTEM_Server";
        //public const string HB_RCP_SRV = "{0}.HB_RCP_Server";
        //public const string HB_ACQ_SRV = "{0}.HB_Acq_Server";
        public const string HB_PRIMARY_WD_SRV = "{0}.HB_PRIMARY_WD_Server";
        public const string HB_SECONDARY_WD_SRV = "{0}.HB_SECONDARY_WD_Server";
    }

    /// <summary>
    /// Constant of Rodeo
    /// </summary>
    public class TagNames
    {
        public const string CRANE_NAME = "{0}.Crane_Name";
        public const string CRANE_LOCATION = "{0}.Crane_Location";
    }

    /// <summary>
    /// Constant of Rodeo
    /// </summary>
    public class TagValues
    {
        public const double CR_OK = 1;
        public const double CR_NOT_OK = 0;

        public const double CR_YES = 1;
        public const double CR_NO = 0;
    }

    /// <summary>
    /// Constant of Error Code
    /// </summary>
    public class ErrorCodeOffsets
    {
        public const int L3_SRV = -100;
        public const int TO_SRV = -200;
        public const int TRK_SRV = -300;
        public const int SAFETY_SRV = -400;
        public const int RS_SRV = -500;
        public const int DBTOXML_SRV = -600;
        public const int SYSTEM_SRV = -700;
        public const int DVR_SRV = -800;
    }
}