using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MSM.Utility.Configuration
{
    /// <summary>
    /// Configuration class of HMI Section.
    /// </summary>
    [Serializable()]
    public class HMISection
    {
        public HMISection()
        {
            this.Permissions = new HMIPermissions();
        }

        /// <summary>
        /// Gets safety_layout_inverted.
        /// </summary>
        [XmlAttribute("safety_layout_inverted")]
        public bool safety_layout_inverted
        {
            get;
            set;
        }

        /// <summary>
        /// Gets crane_operation_inverted.
        /// </summary>
        [XmlAttribute("crane_operation_inverted")]
        public bool crane_operation_inverted
        {
            get;
            set;
        }

        /// <summary>
        /// Gets rails_operation_inverted.
        /// </summary>
        [XmlAttribute("rails_operation_inverted")]
        public bool rails_operation_inverted
        {
            get;
            set;
        }

        /// <summary>
        /// Gets FFmpegDirectory.
        /// </summary>
        [XmlElement("FFmpegDirectory", IsNullable = false)]
        public string FFmpegDirectory
        {
            get;
            set;
        }

        /// <summary>
        /// Gets FFmpegFrameRate.
        /// </summary>
        [XmlElement("FFmpegFrameRate", IsNullable = false)]
        public double FFmpegFrameRate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Transport Operation arrival permit.
        /// </summary>
        [XmlElement("TransportOperationArrivalPermit", IsNullable = false)]
        public bool TransportOperationArrivalPermit
        {
            get;
            set;
        }

        /// <summary>
        /// Gets EnglishUnits.
        /// </summary>
        [XmlElement("EnglishUnits", IsNullable = false)]
        public bool EnglishUnits
        {
            get;
            set;
        }

        /// <summary>
        /// Gets KeyboardEnabled.
        /// </summary>
        [XmlElement("RCPSimulation", IsNullable = false)]
        public bool RCPSimulation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets KeyboardEnabled.
        /// </summary>
        [XmlElement("KeyboardEnabled", IsNullable = false)]
        public bool KeyboardEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets transport_order_layout.
        /// </summary>
        [XmlElement("transport_order_layout", typeof(HMILayout), IsNullable = true)]
        public HMILayout TOLayout
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Permission.
        /// </summary>
        [XmlElement("Permissions", typeof(HMIPermissions), IsNullable = true)]
        public HMIPermissions Permissions
        {
            get;
            set;
        }

        /// <summary>
        /// Gets RCP.
        /// </summary>
        [XmlElement("RCP", typeof(HMIExe), IsNullable = true)]
        public HMIExe RCP
        {
            get;
            set;
        }

        /// <summary>
        /// Gets RuleDesigner.
        /// </summary>
        [XmlElement("RuleDesigner", typeof(HMIExe), IsNullable = true)]
        public HMIExe RuleDesigner
        {
            get;
            set;
        }        

        /// <summary>
        /// Gets OperationCamera.
        /// </summary>
        [XmlElement("OperationCamera", typeof(HMIExe), IsNullable = true)]
        public HMIExe OperationCamera
        {
            get;
            set;
        }

        /// <summary>
        /// Gets OperationMachine.
        /// </summary>
        [XmlElement("OperationMachine", typeof(HMIExe), IsNullable = true)]
        public HMIExe OperationMachine
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ProcessManagement.
        /// </summary>
        [XmlElement("ProcessManagement", typeof(HMIExe), IsNullable = true)]
        public HMIExe ProcessManagement
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Reports.
        /// </summary>
        [XmlElement("Reports", typeof(HMIReports), IsNullable = true)]
        public HMIReports Reports
        {
            get;
            set;
        }

    }

    /// <summary>
    /// Configuration class of Layout
    /// </summary>
    [Serializable()]
    public class HMILayout
    {
        /// <summary>
        /// Gets min_x.
        /// </summary>
        [XmlElement("min_x", IsNullable = false)]
        public int min_x
        {
            get;
            set;
        }

        /// <summary>
        /// Gets max_x.
        /// </summary>
        [XmlElement("max_x", IsNullable = false)]
        public int max_x
        {
            get;
            set;
        }

        /// <summary>
        /// Gets min_y.
        /// </summary>
        [XmlElement("min_y", IsNullable = false)]
        public int min_y
        {
            get;
            set;
        }

        /// <summary>
        /// Gets max_y.
        /// </summary>
        [XmlElement("max_y", IsNullable = false)]
        public int max_y
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Configuration class of Permission
    /// </summary>
    [Serializable()]
    public class HMIPermissions
    {
        /// <summary>
        /// Gets EnableDisableMachine.
        /// </summary>
        [XmlElement("EnableDisableMachine", IsNullable = true)]
        public string EnableDisableMachine
        {
            get;
            set;
        }

        /// <summary>
        /// Gets OperationModeMachine.
        /// </summary>
        [XmlElement("OperationModeMachine", IsNullable = true)]
        public string OperationModeMachine
        {
            get;
            set;
        }

        /// <summary>
        /// Gets PauseMachine.
        /// </summary>
        [XmlElement("PauseMachine", IsNullable = true)]
        public string PauseMachine
        {
            get;
            set;
        }

        /// <summary>
        /// Gets SendHousekeeping.
        /// </summary>
        [XmlElement("SendHousekeeping", IsNullable = true)]
        public string SendHousekeeping
        {
            get;
            set;
        }

        /// <summary>
        /// Gets SendSwitchManual.
        /// </summary>
        [XmlElement("SendSwitchManual", IsNullable = true)]
        public string SendSwitchManual
        {
            get;
            set;
        }

        /// <summary>
        /// Gets SendParkingMachine.
        /// </summary>
        [XmlElement("SendParkingMachine", IsNullable = true)]
        public string SendParkingMachine
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ViewRCPDetails.
        /// </summary>
        [XmlElement("ViewRCPDetails", IsNullable = true)]
        public string ViewRCPDetails
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ViewOperationCamera.
        /// </summary>
        [XmlElement("ViewOperationCamera", IsNullable = true)]
        public string ViewOperationCamera
        {
            get;
            set;
        }

        /// <summary>
        /// Gets CreateJOB.
        /// </summary>
        [XmlElement("CreateJOB", IsNullable = true)]
        public string CreateJOB
        {
            get;
            set;
        }

        /// <summary>
        /// Gets CancelJOB.
        /// </summary>
        [XmlElement("CancelJOB", IsNullable = true)]
        public string CancelJOB
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ChangePriority.
        /// </summary>
        [XmlElement("ChangePriority", IsNullable = true)]
        public string ChangePriority
        {
            get;
            set;
        }

        /// <summary>
        /// Gets CreateTO.
        /// </summary>
        [XmlElement("CreateTO", IsNullable = true)]
        public string CreateTO
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ContinueTO.
        /// </summary>
        [XmlElement("ContinueTO", IsNullable = true)]
        public string ContinueTO
        {
            get;
            set;
        }

        /// <summary>
        /// Gets CancelTO.
        /// </summary>
        [XmlElement("CancelTO", IsNullable = true)]
        public string CancelTO
        {
            get;
            set;
        }

        /// <summary>
        /// Gets DisablePieces.
        /// </summary>
        [XmlElement("DisablePieces", IsNullable = true)]
        public string DisablePieces
        {
            get;
            set;
        }

        /// <summary>
        /// Gets RetentionIngots.
        /// </summary>
        [XmlElement("RetentionPieces", IsNullable = true)]
        public string RetentionPieces
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ScanIngots.
        /// </summary>
        [XmlElement("ScanPieces", IsNullable = true)]
        public string ScanPieces
        {
            get;
            set;
        }

        ///// <summary>
        ///// Gets ModifyRails.
        ///// </summary>
        //[XmlElement("ModifyRails", IsNullable = true)]
        //public string ModifyRails
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// Gets TestSiren.
        /// </summary>
        [XmlElement("TestSiren", IsNullable = true)]
        public string TestSiren
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ResetPLC.
        /// </summary>
        [XmlElement("ResetPLC", IsNullable = true)]
        public string ResetPLC
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ResetEncoders.
        /// </summary>
        [XmlElement("ResetEncoders", IsNullable = true)]
        public string ResetEncoders
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ResetVFDs.
        /// </summary>
        [XmlElement("ResetVFDs", IsNullable = true)]
        public string ResetVFDs
        {
            get;
            set;
        }

        /// <summary>
        /// Gets EnableRCPAntisway.
        /// </summary>
        [XmlElement("EnableRCPAntisway", IsNullable = true)]
        public string EnableRCPAntisway
        {
            get;
            set;
        }

        /// <summary>
        /// Gets EnableDisableLocation.
        /// </summary>
        [XmlElement("EnableDisableLocation", IsNullable = true)]
        public string EnableDisableLocation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets EnableDisableLocGroup.
        /// </summary>
        [XmlElement("EnableDisableLocGroup", IsNullable = true)]
        public string EnableDisableLocGroup
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets EnableDisableZone.
        /// </summary>
        [XmlElement("EnableDisableZone", IsNullable = true)]
        public string EnableDisableZone
        {
            get;
            set;
        }

        /// <summary>
        /// Gets EditTemporaryZone.
        /// </summary>
        [XmlElement("EditTemporaryZone", IsNullable = true)]
        public string EditTemporaryZone
        {
            get;
            set;
        }

        /// <summary>
        /// Gets BypassDevice.
        /// </summary>
        [XmlElement("BypassDevice", IsNullable = true)]
        public string BypassDevice
        {
            get;
            set;
        }

        /// <summary>
        /// Gets WriteSignalDevice.
        /// </summary>
        [XmlElement("WriteSignalDevice", IsNullable = true)]
        public string WriteSignalDevice
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ViewSettings.
        /// </summary>
        [XmlElement("ViewSettings", IsNullable = true)]
        public string ViewSettings
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ModifyPresets.
        /// </summary>
        [XmlElement("ModifyPresets", IsNullable = true)]
        public string ModifyPresets
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ViewUsers.
        /// </summary>
        [XmlElement("ViewUsers", IsNullable = true)]
        public string ViewUsers
        {
            get;
            set;
        }

        /// <summary>
        /// Gets EditUsers.
        /// </summary>
        [XmlElement("EditUsers", IsNullable = true)]
        public string EditUsers
        {
            get;
            set;
        }

        /// <summary>
        /// Gets EditRules.
        /// </summary>
        [XmlElement("EditRules", IsNullable = true)]
        public string EditRules
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ViewOptimization.
        /// </summary>
        [XmlElement("ViewOptimization", IsNullable = true)]
        public string ViewOptimization
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ForceLogin.
        /// </summary>
        [XmlElement("ForceLogin", IsNullable = true)]
        public string ForceLogin
        {
            get;
            set;
        }

        /// <summary>
        /// Gets CreateUsers.
        /// </summary>
        [XmlElement("CreateUsers", IsNullable = true)]
        public string CreateUsers
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Configuration class of Operation Camera
    /// </summary>
    [Serializable()]
    public class HMIExe
    {
        #region constant
        /// <summary>
        /// Operation.Machine
        /// </summary>
        public readonly string ingot_details_window = "INGOT_ID";
        public readonly string machine_limit_switch_window = "LS";
        public readonly string machine_single_line_window = "SLD";
        public readonly string machine_drives_window = "DRIVES";

        /// <summary>
        /// Operation.Camera
        /// </summary>
        public readonly string machine_camera_window = "CAMERA_CRANE";
        public readonly string popup_camera_window = "CAMERA_POPUP";
        public readonly string to_camera_window = "CAMERA_TO";
        public readonly string title_window = "TITLE";
        public readonly string start_time_window = "START_TIME";
        public readonly string end_time_window = "END_TIME";
        #endregion

        /// <summary>
        /// Gets Command.
        /// </summary>
        [XmlElement("Command", IsNullable = true)]
        public string Command
        {
            get;
            set;
        }

        /// <summary>
        /// Gets WorkingDirectory.
        /// </summary>
        [XmlElement("WorkingDirectory", IsNullable = true)]
        public string WorkingDirectory
        {
            get;
            set;
        }

        /// <summary>
        /// Gets args.
        /// </summary>
        [XmlElement("args", IsNullable = true)]
        public string args
        {
            get;
            set;
        }
        
        [XmlElement("piece_details_window", IsNullable = true)]
        public string piece_details_window
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Configuration class of Report.
    /// </summary>
    [Serializable()]
    public class HMIReports
    {
        public HMIReports()
        {

            this.JobScheduled = new ReportIngotItem();
            this.JobHistory = new ReportHistoryItem();
            this.TOHistory = new ReportHistoryItem();
            this.IngotInformation = new ReportIngotItem();
            this.FutureArrival = new ReportIngotItem();
            this.FutureDeparture = new ReportIngotItem();
            this.RecordingHistory = new ReportHistoryItem();
            this.IngotEvents = new ReportEventItem();
            this.MachineEvents = new ReportEventItem();
            this.ZoneEvents = new ReportEventItem();
            this.EventHistory = new ReportEventItem();
            this.MessageHistory = new ReportEventItem();
            this.AlarmHistory = new ReportRodeoItem();
            this.CommandHistory = new ReportRodeoItem();
            this.UserLogHistory = new ReportRodeoItem();
        }

        /// <summary>
        /// Gets FutureArrival.
        /// </summary>
        [XmlElement("JobScheduled", typeof(ReportIngotItem), IsNullable = false)]
        public ReportIngotItem JobScheduled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets JobHistory.
        /// </summary>
        [XmlElement("JobHistory", typeof(ReportHistoryItem), IsNullable = false)]
        public ReportHistoryItem JobHistory
        {
            get;
            set;
        }

        /// <summary>
        /// Gets TOHistory.
        /// </summary>
        [XmlElement("TOHistory", typeof(ReportHistoryItem), IsNullable = false)]
        public ReportHistoryItem TOHistory
        {
            get;
            set;
        }

        /// <summary>
        /// Gets Information.
        /// </summary>
        [XmlElement("IngotInformation", typeof(ReportIngotItem), IsNullable = false)]
        public ReportIngotItem IngotInformation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets FutureArrival.
        /// </summary>
        [XmlElement("FutureArrival", typeof(ReportIngotItem), IsNullable = false)]
        public ReportIngotItem FutureArrival
        {
            get;
            set;
        }

        /// <summary>
        /// Gets FutureDeparture.
        /// </summary>
        [XmlElement("FutureDeparture", typeof(ReportIngotItem), IsNullable = false)]
        public ReportIngotItem FutureDeparture
        {
            get;
            set;
        }

        /// <summary>
        /// Gets RecordingHistory.
        /// </summary>
        [XmlElement("RecordingHistory", typeof(ReportHistoryItem), IsNullable = false)]
        public ReportHistoryItem RecordingHistory
        {
            get;
            set;
        }

        /// <summary>
        /// Gets IngotEvents.
        /// </summary>
        [XmlElement("IngotEvents", typeof(ReportEventItem), IsNullable = true)]
        public ReportEventItem IngotEvents
        {
            get;
            set;
        }

        /// <summary>
        /// Gets MachineEvents.
        /// </summary>
        [XmlElement("MachineEvents", typeof(ReportEventItem), IsNullable = true)]
        public ReportEventItem MachineEvents
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ZoneEvents.
        /// </summary>
        [XmlElement("ZoneEvents", typeof(ReportEventItem), IsNullable = true)]
        public ReportEventItem ZoneEvents
        {
            get;
            set;
        }

        /// <summary>
        /// Gets EventHistory.
        /// </summary>
        [XmlElement("EventHistory", typeof(ReportEventItem), IsNullable = true)]
        public ReportEventItem EventHistory
        {
            get;
            set;
        }

        /// <summary>
        /// Gets MessageHistory.
        /// </summary>
        [XmlElement("MessageHistory", typeof(ReportEventItem), IsNullable = true)]
        public ReportEventItem MessageHistory
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ScanResultHistory.
        /// </summary>
        [XmlElement("ScanResultHistory", typeof(ReportEventItem), IsNullable = true)]
        public ReportEventItem ScanResultHistory
        {
            get;
            set;
        }

        /// <summary>
        /// Gets AEIMessageHistory.
        /// </summary>
        [XmlElement("AEIMessageHistory", typeof(ReportEventItem), IsNullable = true)]
        public ReportEventItem AEIMessageHistory
        {
            get;
            set;
        }

        /// <summary>
        /// Gets RailEvents.
        /// </summary>
        [XmlElement("RailEvents", typeof(ReportEventItem), IsNullable = true)]
        public ReportEventItem RailEvents
        {
            get;
            set;
        }

        /// <summary>
        /// Gets TruckEvents.
        /// </summary>
        [XmlElement("TruckEvents", typeof(ReportEventItem), IsNullable = true)]
        public ReportEventItem TruckEvents
        {
            get;
            set;
        }

        /// <summary>
        /// Gets AlarmHistory.
        /// </summary>
        [XmlElement("AlarmHistory", typeof(ReportRodeoItem), IsNullable = false)]
        public ReportRodeoItem AlarmHistory
        {
            get;
            set;
        }

        /// <summary>
        /// Gets CommandHistory.
        /// </summary>
        [XmlElement("CommandHistory", typeof(ReportRodeoItem), IsNullable = false)]
        public ReportRodeoItem CommandHistory
        {
            get;
            set;
        }

        /// <summary>
        /// Gets UserLogHistory.
        /// </summary>
        [XmlElement("UserLogHistory", typeof(ReportRodeoItem), IsNullable = false)]
        public ReportRodeoItem UserLogHistory
        {
            get;
            set;
        }

        /// <summary>
        /// Configuration class of Report History Item.
        /// </summary>
        [Serializable()]
        public class ReportHistoryItem
        {
            /// <summary>
            /// Gets fromDays.
            /// </summary>
            [XmlAttribute("fromDays")]
            public int FromDays
            {
                get;
                set;
            }

            /// <summary>
            /// Gets toDays.
            /// </summary>
            [XmlAttribute("toDays")]
            public int ToDays
            {
                get;
                set;
            }

            /// <summary>
            /// Gets refreshInterval.
            /// </summary>
            [XmlAttribute("refreshInterval")]
            public int RefreshInterval
            {
                get;
                set;
            }
        }

        /// <summary>
        /// Configuration class of Report Event Item.
        /// </summary>
        [Serializable()]
        public class ReportEventItem
        {
            /// <summary>
            /// Gets fromDays.
            /// </summary>
            [XmlAttribute("fromDays")]
            public int FromDays
            {
                get;
                set;
            }

            /// <summary>
            /// Gets toDays.
            /// </summary>
            [XmlAttribute("toDays")]
            public int ToDays
            {
                get;
                set;
            }

            /// <summary>
            /// Gets refreshInterval.
            /// </summary>
            [XmlAttribute("refreshInterval")]
            public int RefreshInterval
            {
                get;
                set;
            }
        }

        /// <summary>
        /// Configuration class of Report ingot Item.
        /// </summary>
        [Serializable()]
        public class ReportIngotItem
        {
            /// <summary>
            /// Gets refreshInterval.
            /// </summary>
            [XmlAttribute("refreshInterval")]
            public int RefreshInterval
            {
                get;
                set;
            }
        }

        /// <summary>
        /// Configuration class of Report Item.
        /// </summary>
        [Serializable()]
        public class ReportRodeoItem
        {
            /// <summary>
            /// Gets fromDays.
            /// </summary>
            [XmlAttribute("fromDays")]
            public int FromDays
            {
                get;
                set;
            }

            /// <summary>
            /// Gets toDays.
            /// </summary>
            [XmlAttribute("toDays")]
            public int ToDays
            {
                get;
                set;
            }

            /// <summary>
            /// Gets refreshInterval.
            /// </summary>
            [XmlAttribute("refreshInterval")]
            public int RefreshInterval
            {
                get;
                set;
            }
        }
    }
}
