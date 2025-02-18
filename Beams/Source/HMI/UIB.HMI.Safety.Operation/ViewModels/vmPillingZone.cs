using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;


namespace HSM.HMI.Safety.Operation.ViewModels
{
    using Janus.Rodeo.Windows.Library.Rd_Log;
    using Janus.Rodeo.Windows.Library.Rd_Common;
    using Janus.Rodeo.Windows.Library.UI.Controls;
    using Janus.Rodeo.Windows.Library.UI.Controls.Helpers;
    using Janus.Rodeo.Windows.Library.UI.Controls.Widgets;
    using Janus.Rodeo.Windows.Library.UI.Common;

    using HSM.Database;
    using HSM.HMI.Safety.Operation.Enumerations;
    using HSM.HMI.Safety.Operation.Views;
    using HSM.Utility.Common;
    //using HSM.Database;
    using HSM.Utility.Configuration;
    using HSM.Utility.Common.Catalogs;
    using System.Windows;
    using HSM.HMI.Safety.Operation.Views.Windows;
    using System.Reflection;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Security.Policy;
    using System.Windows.Shell;
    using System.Windows.Documents;
    using System.Collections;

    //using HSM.HMI.Safety.Operation.Enumerations;

    public class vmPillingZone : ModelViewBase
    {
        #region private attributes

        private EventWaitHandle _layoutElementSem;
        private readonly object _layoutElementLock;
        private List<object> _lstLayoutElements;

        private ObservableCollection<Beam> _beamsBedExit;
        private ObservableCollection<Beam> _PilingBeams;
        private ObservableCollection<Beam> _beamsBedEntry;
        private ObservableCollection<Beam> _prePilingBeams;

        private ObservableCollection<Beam> _beamPilingBedW1;
        private ObservableCollection<Beam> _beamPilingBedW2;
        private ObservableCollection<Beam> _beamPilingBedW3;
        private ObservableCollection<Beam> _beamPilingBedW4;

        private ObservableCollection<Beam> _beamPilingBedE1;
        private ObservableCollection<Beam> _beamPilingBedE2;
        private ObservableCollection<Beam> _beamPilingBedE3;
        private ObservableCollection<Beam> _beamPilingBedE4;

        private ObservableCollection<Beam> _beamPilingBedQueueE;
        private ObservableCollection<Beam> _beamPilingBedQueueW;

        private ObservableCollection<Beam> _beamQueueW;
        private ObservableCollection<Beam> _beamQueueE;

        bool beamModified;
        private bool _beamInPilingBedW1;
        private bool _beamInPilingBedW2;
        private bool _beamInPilingBedW3;
        private bool _beamInPilingBedW4;
        private bool _beamInPilingBedW5;
        private bool _beamInPilingBed5W1;
        private bool _beamInPilingBed5W2;



        private bool _beamInPilingBedE1;
        private bool _beamInPilingBedE2;
        private bool _beamInPilingBedE3;
        private bool _beamInPilingBedE4;
        private bool _beamInPilingBedE5;
        private bool _beamInPilingQueueW;
        private bool _beamInPilingQueueE;
        private bool _beamInPilingPreQueueE;
        private bool _beamInPilingPreQueueW;

        private bool _beamInCollectingBedE;
        private bool _beamInCollectingBedW;

        private int PosXEast = 835;
        private int PosXWest = 90;

        private int PosYW1 = 125;
        private int PosYW2 = 255;
        private int PosYW3 = 340;
        private int PosYW4 = 415;
        private int PosYWPreQ = 465;
        private int PosYWQ = 540;
        private int PosYW5 = 615;

        private int PosYE1 = 125;
        private int PosYE2 = 255;
        private int PosYE3 = 340;
        private int PosYE4 = 415;
        private int PosYEPreQ = 465;
        private int PosYEQ = 540;
        private int PosYE5 = 615;

        private bool _beamInBedExit;
        private bool _beamInBedEntry;


        private bool _general_layout;
        private List<string> _zones;
        private List<Beam> _beams;
        private ObservableCollection<Beam> _beamsInZone;

        private Dictionary<string, object> _allMachine;
        private Dictionary<string, object> _machineSelected;
        private HSM_Zone_Machine[] _zone_machine;
        // private vmYard[] _yards;

        private Dictionary<string, object> _allEnableComponents;
        private Dictionary<string, object> _allEnableComponentsSelected;

        #endregion

        #region logical attributes
        /// <summary>
        /// use to lock the logical
        /// </summary>
        private readonly object _lockInstance = new object();

        /// <summary>
        /// use to lock the logical
        /// </summary>
        protected readonly object _lockTO = new object();

        /// <summary>
        /// nunning task
        /// </summary>
        private Task _runningTask;

        /// <summary>
        /// cancel task
        /// </summary>
        private CancellationTokenSource _cancelTask;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="vmPilingZone"/> class.
        /// </summary>
        /// <param name="zones"></param>
        /// <param name="requests"></param>
        /// <param name="machines"></param>
        /// <param name="maint"></param>
        /// <param name="locations"></param>
        public vmPillingZone()
            : base()
        {

            RdTrace.Debug("Begin Layout");
            this._CreateTemporaryZoneCommand = new RelayCommand(param => this.CreateTemporaryZoneExecute(param));
            this._ShowCommand = new RelayCommand(param => this.ShowExecute(param));
            this._SelectYardCommand = new RelayCommand(param => this.SelectYardExecute(param));
            this._FooCommand = new RelayCommand(param => this.SendExecute((Beam)param));
            Main();

        }
        #endregion

        #region Properties

        /// <summary>
        /// Lock Instance
        /// </summary>
        public object LockInstance
        {
            get { return _lockInstance; }
        }

        /// <summary>
        /// Indication the Machine is ThreadRunning
        /// </summary>
        public bool ThreadRunning
        {
            get
            {
                if (this._runningTask == null)
                {
                    return false;
                }
                return this._runningTask.Status == TaskStatus.Running || this._runningTask.Status == TaskStatus.WaitingToRun;
            }
        }

        public bool BeamInPilingBedW1
        {
            get { return this._beamInPilingBedW1; }
            set
            {
                if (this._beamInPilingBedW1 != value)
                {
                    this._beamInPilingBedW1 = value;

                    OnPropertyChanged("BeamInPilingBedW1");

                }
            }
        }

        public bool BeamInPilingBedW2
        {
            get { return this._beamInPilingBedW2; }
            set
            {
                if (this._beamInPilingBedW2 != value)
                {
                    this._beamInPilingBedW2 = value;

                    OnPropertyChanged("BeamInPilingBedW2");

                }
            }
        }

        public bool BeamInPilingBedW3
        {
            get { return this._beamInPilingBedW3; }
            set
            {
                if (this._beamInPilingBedW3 != value)
                {
                    this._beamInPilingBedW3 = value;

                    OnPropertyChanged("BeamInPilingBedW3");

                }
            }
        }

        public bool BeamInPilingBedW4
        {
            get { return this._beamInPilingBedW4; }
            set
            {
                if (this._beamInPilingBedW4 != value)
                {
                    this._beamInPilingBedW4 = value;

                    OnPropertyChanged("BeamInPilingBedW4");

                }
            }
        }


        public bool BeamNotInPilingBed5W
        {
            get { return this._beamInPilingBedW5; }
            set
            {
                if (this._beamInPilingBedW5 != value)
                {
                    this._beamInPilingBedW5 = value;

                    OnPropertyChanged("BeamNotInPilingBed5W");

                }
            }
        }

        public bool BeamNotInPilingBed5W1
        {
            get { return this._beamInPilingBed5W1; }
            set
            {
                if (this._beamInPilingBed5W1 != value)
                {
                    this._beamInPilingBed5W1 = value;

                    OnPropertyChanged("BeamNotInPilingBed5W1");

                }
            }
        }

        public bool BeamNotInPilingBed5W2
        {
            get { return this._beamInPilingBed5W2; }
            set
            {
                if (this._beamInPilingBed5W2 != value)
                {
                    this._beamInPilingBed5W2 = value;

                    OnPropertyChanged("BeamNotInPilingBed5W2");

                }
            }
        }

        public bool BeamInPilingPreQueueE
        {
            get { return this._beamInPilingPreQueueE; }
            set
            {
                if (this._beamInPilingPreQueueE != value)
                {
                    this._beamInPilingPreQueueE = value;

                    OnPropertyChanged("BeamInPilingPreQueueE");

                }
            }
        }

        public bool BeamInPilingQueueE
        {
            get { return this._beamInPilingQueueE; }
            set
            {
                if (this._beamInPilingQueueE != value)
                {
                    this._beamInPilingQueueE = value;

                    OnPropertyChanged("BeamInPilingQueueE");

                }
            }
        }

        public bool BeamInCollectingBedE
        {
            get { return this._beamInCollectingBedE; }
            set
            {
                if (this._beamInCollectingBedE != value)
                {
                    this._beamInCollectingBedE = value;

                    OnPropertyChanged("BeamInCollectingBedE");

                }
            }
        }


        public bool BeamInPilingBedE1
        {
            get { return this._beamInPilingBedE1; }
            set
            {
                if (this._beamInPilingBedE1 != value)
                {
                    this._beamInPilingBedE1 = value;

                    OnPropertyChanged("BeamInPilingBedE1");

                }
            }
        }

        public bool BeamInPilingBedE2
        {
            get { return this._beamInPilingBedE2; }
            set
            {
                if (this._beamInPilingBedE2 != value)
                {
                    this._beamInPilingBedE2 = value;

                    OnPropertyChanged("BeamInPilingBedE2");

                }
            }
        }

        public bool BeamInPilingBedE3
        {
            get { return this._beamInPilingBedE3; }
            set
            {
                if (this._beamInPilingBedE3 != value)
                {
                    this._beamInPilingBedE3 = value;

                    OnPropertyChanged("BeamInPilingBedE3");

                }
            }
        }

        public bool BeamInPilingBedE4
        {
            get { return this._beamInPilingBedE4; }
            set
            {
                if (this._beamInPilingBedE4 != value)
                {
                    this._beamInPilingBedE4 = value;

                    OnPropertyChanged("BeamInPilingBedE4");

                }
            }
        }

        public bool BeamInPilingPreQueueW
        {
            get { return this._beamInPilingPreQueueW; }
            set
            {
                if (this._beamInPilingPreQueueW != value)
                {
                    this._beamInPilingPreQueueW = value;

                    OnPropertyChanged("BeamInPilingPreQueueW");

                }
            }
        }

        public bool BeamInPilingQueueW
        {
            get { return this._beamInPilingQueueW; }
            set
            {
                if (this._beamInPilingQueueW != value)
                {
                    this._beamInPilingQueueW = value;

                    OnPropertyChanged("BeamInPilingQueueW");

                }
            }
        }

        public bool BeamNotInPilingBed5E
        {
            get { return this._beamInPilingBedE5; }
            set
            {
                if (this._beamInPilingBedE5 != value)
                {
                    this._beamInPilingBedE5 = value;

                    OnPropertyChanged("BeamNotInPilingBed5E");

                }
            }
        }

        public bool BeamInCollectingBedW
        {
            get { return this._beamInCollectingBedW; }
            set
            {
                if (this._beamInCollectingBedW != value)
                {
                    this._beamInCollectingBedW = value;

                    OnPropertyChanged("BeamInCollectingBedW");

                }
            }
        }


        public List<string> Zones
        {
            get { return this._zones; }
            set
            {
                if (this._zones != value)
                {
                    this._zones = value;

                    this.OnPropertyChanged("Zones");

                }
            }
        }


        public ObservableCollection<Beam> PilingBeams
        {
            get { return this._PilingBeams; }
            set
            {
                if (this._PilingBeams != value)
                {
                    this._PilingBeams = value;
                    OnPropertyChanged(nameof(PilingBeams));
                }
            }
        }

        public ObservableCollection<Beam> PrePilingBeams
        {
            get { return this._prePilingBeams; }
            set
            {
                if (this._prePilingBeams != value)
                {
                    this._prePilingBeams = value;
                    OnPropertyChanged(nameof(PrePilingBeams));
                }
            }
        }

        public ObservableCollection<Beam> BeamsBedExit
        {
            get { return this._beamsBedExit; }
            set
            {
                if (this._beamsBedExit != value)
                {
                    this._beamsBedExit = value;
                    OnPropertyChanged(nameof(BeamsBedExit));
                }
            }
        }

        public ObservableCollection<Beam> BeamsBedEntry
        {
            get { return this._beamsBedEntry; }
            set
            {
                if (this._beamsBedEntry != value)
                {
                    this._beamsBedEntry = value;
                    OnPropertyChanged(nameof(BeamsBedEntry));
                }
            }
        }

        public List<Beam> Beams
        {
            get { return this._beams; }
            set
            {
                if (this._beams != value)
                {
                    this._beams = value;

                    this.OnPropertyChanged("Beams");

                }
            }
        }

        public ObservableCollection<Beam> BeamsInZone
        {
            get { return this._beamsInZone; }
            set
            {
                if (this._beamsInZone != value)
                {
                    this._beamsInZone = value;

                    this.OnPropertyChanged("BeamsInZone");

                }
            }
        }

        public bool GeneralLayout
        {
            get { return this._general_layout; }
            set
            {
                if (this._general_layout != value)
                {
                    this._general_layout = value;

                    OnPropertyChanged("GeneralLayout");
                }
            }
        }


        public Dictionary<string, object> AllMachine
        {
            get { return this._allMachine; }
            private set
            {
                if (this._allMachine != value)
                {
                    this._allMachine = value;

                    OnPropertyChanged("AllMachine");
                }
            }
        }


        public Dictionary<string, object> MachineSelected
        {
            get { return this._machineSelected; }
            set
            {
                if (this._machineSelected != value)
                {
                    this._machineSelected = value;

                    OnPropertyChanged("MachineSelected");
                }
            }
        }

        public Dictionary<string, object> AllEnableComponents
        {
            get { return this._allEnableComponents; }
            private set
            {
                if (this._allEnableComponents != value)
                {
                    this._allEnableComponents = value;

                    OnPropertyChanged("AllEnableComponents");
                }
            }
        }

        public Dictionary<string, object> AllEnableComponentsSelected
        {
            get { return this._allEnableComponentsSelected; }
            set
            {
                if (this._allEnableComponentsSelected != value)
                {
                    this._allEnableComponentsSelected = value;

                    OnPropertyChanged("AllEnableComponentsSelected");
                }
            }
        }


        public class CounterMessage : Window
        {
            public CounterMessage(string message)
            {
                this.Message = message;
            }

            public string Message
            {
                get;
                set;
            }
        }



        #endregion

        #region Create Zone command
        // public Func<vmZoneTemporaryDrawing, bool> CreateTemporaryZoneAction { get; set; }

        private ICommand _CreateTemporaryZoneCommand;
        public ICommand CreateTemporaryZoneCommand
        {
            get
            {
                return _CreateTemporaryZoneCommand;
            }
            set
            {
                _CreateTemporaryZoneCommand = value;

                OnPropertyChanged("CreateTemporaryZoneCommand");
            }
        }

        private void CreateTemporaryZoneExecute(object parameter)
        {
            try
            {
                //if (this.CreateTemporaryZoneAction != null)
                //{
                //    if (this._temporary_drawing.Enabled && this.CreateTemporaryZoneAction(this._temporary_drawing))
                //    {
                //        this._temporary_drawing.Clear();
                //    }
                //}
                //else
                //{
                //    this.ShowError("Design Screen", "alert", "Operation is not implemented");
                //}
            }
            catch (Exception ex)
            {
                RdTrace.Exception(ex);

                this.ShowError("Error", "error", string.Format("Unexpected error has ocurred.\nException: {0}", ex.Message));
            }
        }

        private ICommand _FooCommand;
        public ICommand FooCommand
        {
            get
            {
                return _FooCommand;
            }
            set
            {
                _FooCommand = value;

                OnPropertyChanged("FooCommand");
            }
        }
        #endregion

        #region Show command
        private ICommand _ShowCommand;
        public ICommand ShowCommand
        {
            get
            {
                return _ShowCommand;
            }
            set
            {
                _ShowCommand = value;

                OnPropertyChanged("ShowCommand");
            }
        }

        private void ShowExecute(object parameter)
        {
            ShowZones();
        }
        #endregion

        #region Enable Features command
        private ICommand _EnableFeaturesCommand;
        public ICommand EnableFeaturesCommand
        {
            get
            {
                return _EnableFeaturesCommand;
            }
            set
            {
                _EnableFeaturesCommand = value;

                OnPropertyChanged("EnableFeaturesCommand");
            }
        }


        #endregion

        #region Select yard command
        private ICommand _SelectYardCommand;
        public ICommand SelectYardCommand
        {
            get
            {
                return _SelectYardCommand;
            }
            set
            {
                _SelectYardCommand = value;

                OnPropertyChanged("SelectYardCommand");
            }
        }

        private bool CanSendExecute(object parameter)
        {
            return true;
        }

        private void SelectYardExecute(object parameter)
        {
            try
            {
                //vmYard yardSelected = (vmYard)parameter;
                //if (yardSelected != null) 
                //{
                //    for (int i = 0; i < this.Yards.Length; i++)
                //    {
                //        if (this.Yards[i].Properties.Id == yardSelected.Properties.Id)
                //        {
                //            if(yardSelected.Properties.Id == HMI.Safety.Operation.Constants.Configuration.GENERAL_LAYOUT_ID)
                //            {
                //                this.GeneralLayout = true;
                //                this.Yards[i].Enabled = true;
                //            }
                //            else 
                //            {
                //                this.Yards[i].Enabled = true;
                //                this.GeneralLayout = false;
                //            }                            
                //        }
                //        else
                //        {
                //            this.Yards[i].Enabled = false;
                //        }
                //    }
                //}                
            }
            catch (Exception ex)
            {
                RdTrace.Exception(ex);

                this.ShowError("Error", "error", string.Format("Unexpected error has ocurred.\nException: {0}", ex.Message));
            }
        }
        #endregion


        #region public methods
        /// <summary>
        /// End Loading
        /// </summary>

        #endregion

        #region private methods

        private void Main()
        {
            //Inicializo las zonas
            _zones = new List<string>();
            _beams = new List<Beam>();
            _beamsBedEntry = new ObservableCollection<Beam>();
            _PilingBeams = new ObservableCollection<Beam>();
            _prePilingBeams = new ObservableCollection<Beam>();
            _beamsBedExit = new ObservableCollection<Beam>();

            _zones.Add("PilingBed1W");
            _zones.Add("PilingBed2W");
            _zones.Add("PilingBed3W");
            _zones.Add("PilingBed4W");
            _zones.Add("PilingBed1E");
            _zones.Add("PilingBed2E");
            _zones.Add("PilingBed3E");
            _zones.Add("PilingBed4E");
            _zones.Add("PilingBedQueueE");
            _zones.Add("PilingBedQueueW");
            _zones.Add("PilingBed5W");
            _zones.Add("PilingBed5W1");
            _zones.Add("PilingBed5W2");
            _zones.Add("PilingBed5E");
            _zones.Add("PilingBedPreQueueE");
            _zones.Add("PilingBedPreQueueW");


            this._cancelTask = new CancellationTokenSource();
            this._runningTask = new Task(() => DoProcess(this._cancelTask.Token), this._cancelTask.Token);
            this._runningTask.Start();
        }

        /// <summary>
        /// Show Zones
        /// </summary>
        /// <param name="showError"></param>
        private void ShowZones()
        {
            try
            {
                if (this.MachineSelected.Count == this.AllMachine.Count)
                {
                    //foreach (vmZoneSection zone in this.Sections)
                    //{
                    //    zone.VisibleByMachine = true;
                    //}
                }
                else
                {
                    //List<int> lstZonesActives = new List<int>(); 
                    //foreach (string machine in this.MachineSelected.Select(oA => ((Tracking.Server.Common.Catalogs.CT_Machine)oA.Value).Group).ToList())
                    //{
                    //    foreach( HSM_Zone_Machine zoneMachine in this._zone_machine.Where(p => p.Rodeo_Machine_Group.Name == machine && p.CanBeAccessed))  
                    //    {
                    //        lstZonesActives.Add(zoneMachine.IdZone);                        
                    //    }
                    //}
                    //int[] lstZones = lstZonesActives.Distinct().ToArray();

                    //foreach (vmZoneSection zone in this.Sections)
                    //{
                    //    if (lstZones.Any(p=> p == zone.Zone.Properties.Id))
                    //    {
                    //        zone.VisibleByMachine = true;
                    //    }
                    //    else
                    //    {
                    //        zone.VisibleByMachine = false;
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                RdTrace.Exception(ex);
                this.ShowError("Error", "error", string.Format("Unexpected error has ocurred.\nException: {0}", ex.Message));
            }
        }


        private void SendExecute(Beam beam)
        {
            List<Beam> beams = new List<Beam>();
            bool showListBeams = false;
            switch (beam.Zone)
            {
                case "PilingBed1E":
                case "PilingBed1W":
                case "PilingBed2E":
                case "PilingBed2W":
                    beams = BeamsBedEntry.ToList();
                    showListBeams = false;
                    break;
                case "PilingBed3E":
                case "PilingBed3W":
                case "PilingBed4E":
                case "PilingBed4W":
                    beams = PrePilingBeams.ToList();
                    showListBeams = false;
                    break;
                default:
                    showListBeams = true;
                    break;
            }
            if (!showListBeams)
            {
                vmZoneDetail generalDetails = new vmZoneDetail(beam);
                ZoneDetail zoneDetail = new ZoneDetail(beam, beams);
                zoneDetail.ShowDialog();
            }
            else
            {
                if(beam.Zone != "PilingBed5W" && beam.Zone != "PilingBed5E" && beam.Zone != "PilingBed5W1" && beam.Zone != "PilingBed5W2") 
                    beams = PilingBeams.Where(x => x.Zone == beam.Zone).ToList();
                else
                    beams = BeamsBedExit.Where(x => x.Zone == beam.Zone).ToList();

                BeamsInZone = new ObservableCollection<Beam>(beams);
                BeamList zoneDetail = new BeamList(beam, beams);
                zoneDetail.ShowDialog();
            }

        }

        private void BeamsInZones(List<string> zones)
        {
            List<Beam> beams = new List<Beam>();
            for (int i = 0; i < zones.Count; i++)
            {
                string zoneBeam;
                if (!RodeoHandler.Tag.GetText(string.Format("HSM." + zones[i], Configurations.General.RodeoSector), out zoneBeam))
                {
                    throw new Exception("Error");
                }
                string[] beamsInZoneName = zoneBeam.Split(',');

                for (int j = 0; j < beamsInZoneName.Length; j++)
                {
                    if (!String.IsNullOrEmpty(beamsInZoneName[j]))
                    {
                        var beam = new Beam(beamsInZoneName[j], zones[i]);
                        beams.Add(beam);
                    }
                }
            }
            if (!this.Beams.SequenceEqual(beams))
            {
                beamModified = true;
                Beams.Clear();
                Beams = beams;
            }
            else
            {
                beamModified = false;
            }

        }

        private void PaintBeamsInLayout()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (Beams.Count != _beamsBedExit.Count + _PilingBeams.Count + _beamsBedEntry.Count + _prePilingBeams.Count || beamModified)
                {
                    _beamsBedEntry.Clear();
                    _PilingBeams.Clear();
                    _prePilingBeams.Clear();
                    _beamsBedExit.Clear();

                    foreach (var beam in Beams)
                    {
                        switch (beam.Zone)
                        {
                            case "PilingBed1W":
                                if (_beamsBedEntry.Count > 0 && _beamsBedEntry.Where(x => x.PositionX == PosXWest && x.PositionY == PosYW1).Any())
                                {
                                    beam.PositionX = PosXWest;
                                    beam.PositionY = _beamsBedEntry.Where(x => x.PositionX == PosXWest && x.PositionY <= PosYW1).OrderBy(x => x.PositionY).FirstOrDefault().PositionY - 25;
                                }
                                else
                                {
                                    beam.PositionX = PosXWest;
                                    beam.PositionY = PosYW1;
                                }
                                _beamsBedEntry.Add(beam);

                                OnPropertyChanged(nameof(BeamsBedEntry));
                                break;

                            case "PilingBed1E":
                                if (_beamsBedEntry.Count > 0 && _beamsBedEntry.Where(x => x.PositionX == PosXEast && x.PositionY == PosYE1).Any())
                                {
                                    beam.PositionX = PosXEast;
                                    beam.PositionY = _beamsBedEntry.Where(x => x.PositionX == PosXEast && x.PositionY <= PosYE1).OrderBy(x => x.PositionY).FirstOrDefault().PositionY - 25;
                                }
                                else
                                {
                                    beam.PositionX = PosXEast;
                                    beam.PositionY = PosYE1;
                                }
                                _beamsBedEntry.Add(beam);

                                OnPropertyChanged(nameof(BeamsBedEntry));
                                break;

                            case "PilingBed2W":
                                if (_beamsBedEntry.Count > 0 && _beamsBedEntry.Where(x => x.PositionX == PosXWest && x.PositionY == PosYW2).Any())
                                {
                                    beam.PositionX = PosXWest;
                                    beam.PositionY = _beamsBedEntry.Where(x => x.PositionX == PosXWest && (x.PositionY <= PosYW2 && x.PositionY > PosYW1)).OrderBy(x => x.PositionY).FirstOrDefault().PositionY - 25;
                                }
                                else
                                {
                                    beam.PositionX = PosXWest;
                                    beam.PositionY = PosYW2;
                                }
                                _beamsBedEntry.Add(beam);

                                OnPropertyChanged(nameof(BeamsBedEntry));
                                break;

                            case "PilingBed2E":
                                if (_beamsBedEntry.Count > 0 && _beamsBedEntry.Where(x => x.PositionX == PosXEast && x.PositionY == PosYE2).Any())
                                {
                                    beam.PositionX = PosXEast;
                                    beam.PositionY = _beamsBedEntry.Where(x => x.PositionX == PosXEast && (x.PositionY <= PosYE2 && x.PositionY > PosYE1)).OrderBy(x => x.PositionY).FirstOrDefault().PositionY - 25;
                                }
                                else
                                {
                                    beam.PositionX = PosXEast;
                                    beam.PositionY = PosYE2;
                                }
                                _beamsBedEntry.Add(beam);

                                OnPropertyChanged(nameof(BeamsBedEntry));
                                break;

                            case "PilingBed3W":

                                if (_prePilingBeams.Count > 0 && _prePilingBeams.Where(x => x.PositionX == PosXWest && x.PositionY == PosYW3).Any())
                                {
                                    beam.PositionX = PosXWest;
                                    beam.PositionY = _prePilingBeams.Where(x => x.PositionX == PosXWest && (x.PositionY <= PosYW3 && x.PositionY > PosYW2)).OrderBy(x => x.PositionY).FirstOrDefault().PositionY - 25;
                                }
                                else
                                {
                                    beam.PositionX = PosXWest;
                                    beam.PositionY = PosYW3;
                                }

                                _prePilingBeams.Add(beam);

                                OnPropertyChanged(nameof(PrePilingBeams));
                                break;

                            case "PilingBed3E":

                                if (_prePilingBeams.Count > 0 && _prePilingBeams.Where(x => x.PositionX == PosXEast && x.PositionY == PosYE3).Any())
                                {
                                    beam.PositionX = PosXEast;
                                    beam.PositionY = _prePilingBeams.Where(x => x.PositionX == PosXEast && (x.PositionY <= PosYE3 && x.PositionY > PosYE2)).OrderBy(x => x.PositionY).FirstOrDefault().PositionY - 25;
                                }
                                else
                                {
                                    beam.PositionX = PosXEast;
                                    beam.PositionY = PosYE3;
                                }
                                _prePilingBeams.Add(beam);

                                OnPropertyChanged(nameof(PrePilingBeams));
                                break;

                            case "PilingBed4W":

                                if (_prePilingBeams.Count > 0 && _prePilingBeams.Where(x => x.PositionX == PosXWest && x.PositionY == PosYW4).Any())
                                {
                                    beam.PositionX = PosXWest;
                                    beam.PositionY = _prePilingBeams.Where(x => x.PositionX == PosXWest && (x.PositionY <= PosYW4 && x.PositionY > PosYW3)).OrderBy(x => x.PositionY).FirstOrDefault().PositionY - 25;
                                }
                                else
                                {
                                    beam.PositionX = PosXWest;
                                    beam.PositionY = PosYW4;
                                }

                                _prePilingBeams.Add(beam);

                                OnPropertyChanged(nameof(PrePilingBeams));
                                break;

                            case "PilingBed4E":
                                if (_prePilingBeams.Count > 0 && _prePilingBeams.Where(x => x.PositionX == PosXEast && x.PositionY == PosYE4).Any())
                                {
                                    beam.PositionX = PosXEast;
                                    beam.PositionY = _prePilingBeams.Where(x => x.PositionX == PosXEast && (x.PositionY <= PosYE4 && x.PositionY > PosYE3)).OrderBy(x => x.PositionY).FirstOrDefault().PositionY - 25;
                                }
                                else
                                {
                                    beam.PositionX = PosXEast;
                                    beam.PositionY = PosYE4;
                                }

                                _prePilingBeams.Add(beam);
                                OnPropertyChanged(nameof(PrePilingBeams));
                                break;
                            case "PilingBedPreQueueW":

                                beam.PositionX = PosXWest;
                                beam.PositionY = PosYWPreQ;


                                _PilingBeams.Add(beam);
                                OnPropertyChanged(nameof(PilingBeams));
                                break;

                            case "PilingBedPreQueueE":

                                beam.PositionX = PosXEast;
                                beam.PositionY = PosYEPreQ;


                                _PilingBeams.Add(beam);

                                OnPropertyChanged(nameof(PilingBeams));
                                break;
                            case "PilingBedQueueW":
                                beam.PositionX = PosXWest;
                                beam.PositionY = PosYWQ;

                                _PilingBeams.Add(beam);

                                OnPropertyChanged(nameof(PilingBeams));
                                break;

                            case "PilingBedQueueE":

                                beam.PositionX = PosXEast;
                                beam.PositionY = PosYEQ;


                                _PilingBeams.Add(beam);

                                OnPropertyChanged(nameof(PilingBeams));
                                break;

                            case "PilingBed5E":

                                beam.PositionX = PosXEast;
                                beam.PositionY = PosYE5;
                                _beamsBedExit.Add(beam);
                                OnPropertyChanged(nameof(BeamsBedExit));
                                break;

                            case "PilingBed5W":

                                beam.PositionX = PosXWest;
                                beam.PositionY = PosYW5;
                                _beamsBedExit.Add(beam);
                                OnPropertyChanged(nameof(BeamsBedExit));
                                break;

                            case "PilingBed5W1":

                                beam.PositionX = PosXWest;
                                beam.PositionY = PosYW5;
                                _beamsBedExit.Add(beam);
                                OnPropertyChanged(nameof(BeamsBedExit));
                                break;

                            case "PilingBed5W2":

                                beam.PositionX = PosXEast;
                                beam.PositionY = PosYE5;
                                _beamsBedExit.Add(beam);
                                OnPropertyChanged(nameof(BeamsBedExit));
                                break;
                        }
                    }
                }
            });
        }

        void BeamPosYAlign()
        {
            int LayoutHeight = 100;
            int height_beams = 15;

            int LayoutHeightMin = 60;

            ObservableCollection<Beam> beamsAdjustE1 = new ObservableCollection<Beam>();
            ObservableCollection<Beam> beamsAdjustE2 = new ObservableCollection<Beam>();
            ObservableCollection<Beam> beamsAdjustE3 = new ObservableCollection<Beam>();
            ObservableCollection<Beam> beamsAdjustE4 = new ObservableCollection<Beam>();
            ObservableCollection<Beam> beamsAdjustW1 = new ObservableCollection<Beam>();
            ObservableCollection<Beam> beamsAdjustW2 = new ObservableCollection<Beam>();
            ObservableCollection<Beam> beamsAdjustW3 = new ObservableCollection<Beam>();
            ObservableCollection<Beam> beamsAdjustW4 = new ObservableCollection<Beam>();

            for (int i = 0; i < _beamsBedEntry.Count; i++)
            {
                switch (_beamsBedEntry[i].Zone)
                {
                    case "PilingBed1E":
                        beamsAdjustE1.Add(_beamsBedEntry[i]);
                        break;

                    case "PilingBed1W":
                        beamsAdjustW1.Add(_beamsBedEntry[i]);
                        break;
                    case "PilingBed2E":
                        beamsAdjustE2.Add(_beamsBedEntry[i]);
                        break;
                    case "PilingBed2W":
                        beamsAdjustW2.Add(_beamsBedEntry[i]);
                        break;
                }
            }

            for (int i = 0; i < _prePilingBeams.Count; i++)
            {
                switch (_prePilingBeams[i].Zone)
                {
                    case "PilingBed3E":
                        beamsAdjustE3.Add(_prePilingBeams[i]);
                        break;

                    case "PilingBed3W":
                        beamsAdjustW3.Add(_prePilingBeams[i]);
                        break;
                    case "PilingBed4E":
                        beamsAdjustE4.Add(_prePilingBeams[i]);
                        break;
                    case "PilingBed4W":
                        beamsAdjustW4.Add(_prePilingBeams[i]);
                        break;
                }
            }


            if (beamsAdjustE1.Count() > 0)
            {
                var space = LayoutHeight - beamsAdjustE1.Count * height_beams;

                var result = space / (beamsAdjustE1.Count + 1);

                for (int i = beamsAdjustE1.Count - 1; i >= 0; i--)
                {
                    beamsAdjustE1[i].PositionY = (PosYE1 - LayoutHeight) + (beamsAdjustE1.Count - i) * (result + height_beams);
                }
            }

            if (beamsAdjustE2.Count() > 0)
            {
                var space = LayoutHeight - beamsAdjustE2.Count * height_beams;

                var result = space / (beamsAdjustE2.Count + 1);

                for (int i = beamsAdjustE2.Count - 1; i >= 0; i--)
                {
                    beamsAdjustE2[i].PositionY = (PosYE2 - LayoutHeight) + (beamsAdjustE2.Count - i) * (result + height_beams);
                }
            }

            if (beamsAdjustW1.Count() > 0)
            {
                var space = LayoutHeight - beamsAdjustW1.Count * height_beams;

                var result = space / (beamsAdjustW1.Count + 1);

                for (int i = beamsAdjustW1.Count - 1; i >= 0; i--)
                {
                    beamsAdjustW1[i].PositionY = (PosYW1 - LayoutHeight) + (beamsAdjustW1.Count - i) * (result + height_beams);
                }
            }

            if (beamsAdjustW2.Count() > 0)
            {
                var space = LayoutHeight - beamsAdjustW2.Count * height_beams;

                var result = space / (beamsAdjustW2.Count + 1);

                for (int i = beamsAdjustW2.Count - 1; i >= 0; i--)
                {
                    beamsAdjustW2[i].PositionY = (PosYW2 - LayoutHeight) + (beamsAdjustW2.Count - i) * (result + height_beams);
                }
            }

            if (beamsAdjustW3.Count() > 0)
            {
                var space = LayoutHeightMin - beamsAdjustW3.Count * height_beams;

                var result = space / (beamsAdjustW3.Count + 1);

                for (int i = beamsAdjustW3.Count - 1; i >= 0; i--)
                {
                    beamsAdjustW3[i].PositionY = (PosYW3 - LayoutHeightMin) + (beamsAdjustW3.Count - i) * (result + height_beams);
                }
            }

            if (beamsAdjustW4.Count() > 0)
            {
                var space = LayoutHeightMin - beamsAdjustW4.Count * height_beams;

                var result = space / (beamsAdjustW4.Count + 1);

                for (int i = beamsAdjustW4.Count - 1; i >= 0; i--)
                {
                    beamsAdjustW4[i].PositionY = (PosYW4 - LayoutHeightMin) + (beamsAdjustW4.Count - i) * (result + height_beams);
                }
            }

            if (beamsAdjustE3.Count() > 0)
            {
                var space = LayoutHeightMin - beamsAdjustE3.Count * height_beams;

                var result = space / (beamsAdjustE3.Count + 1);

                for (int i = beamsAdjustE3.Count - 1; i >= 0; i--)
                {
                    beamsAdjustE3[i].PositionY = (PosYE3 - LayoutHeightMin) + (beamsAdjustE3.Count - i) * (result + height_beams);
                }
            }

            if (beamsAdjustE4.Count() > 0)
            {
                var space = LayoutHeightMin - beamsAdjustE4.Count * height_beams;

                var result = space / (beamsAdjustE4.Count + 1);

                for (int i = beamsAdjustE4.Count - 1; i >= 0; i--)
                {
                    beamsAdjustE4[i].PositionY = (PosYE4 - LayoutHeightMin) + (beamsAdjustE4.Count - i) * (result + height_beams);
                }
            }

        }


        private void CheckBeamInZone()
        {
            if (_prePilingBeams.Count > 0)
            {
                bool beaminE3 = false;
                bool beaminE4 = false;
                bool beaminW3 = false;
                bool beaminW4 = false;
                for (int i = 0; i < _prePilingBeams.Count; i++)
                {
                    switch (_prePilingBeams[i].Zone)
                    {
                        case "PilingBed3E":
                            beaminE3 = true;
                            break;

                        case "PilingBed4E":
                            beaminE4 = true;
                            break;

                        case "PilingBed3W":
                            beaminW3 = true;
                            break;

                        case "PilingBed4W":
                            beaminW4 = true;
                            break;
                    }
                }
                BeamInPilingBedE3 = beaminE3;
                BeamInPilingBedE4 = beaminE4;
                BeamInPilingBedW3 = beaminW3;
                BeamInPilingBedW4 = beaminW4;
            }
            else
            {
                BeamInPilingBedE3 = false;
                BeamInPilingBedE4 = false;
                BeamInPilingBedW3 = false;
                BeamInPilingBedW4 = false;
            }
            if (_PilingBeams.Count > 0)
            {
                bool beaminPreQW = false;
                bool beaminPreQE = false;
                bool beaminQE = false;
                bool beaminQw = false;
                for (int i = 0; i < _PilingBeams.Count; i++)
                {
                    switch (_PilingBeams[i].Zone)
                    {
                        case "PilingBedPreQueueE":
                            beaminPreQE = true;
                            break;
                        case "PilingBedPreQueueW":
                            beaminPreQW = true;
                            break;
                        case "PilingBedQueueW":
                            beaminQw = true;
                            break;
                        case "PilingBedQueueE":
                            beaminQE = true;
                            break;
                    }
                }

                BeamInPilingQueueE = beaminQE;
                BeamInPilingPreQueueE = beaminPreQE;
                BeamInPilingPreQueueW = beaminPreQW;
                BeamInPilingQueueW = beaminQw;
            }
            else
            {
                BeamInPilingQueueE = false;
                BeamInPilingQueueW = false;
                BeamInPilingPreQueueE = false;
                BeamInPilingPreQueueW = false;
            }


            if (_beamsBedEntry.Count > 0)
            {
                bool beaminE1 = false;
                bool beaminW1 = false;
                bool beaminE2 = false;
                bool beaminW2 = false;

                for (int i = 0; i < _beamsBedEntry.Count; i++)
                {
                    switch (_beamsBedEntry[i].Zone)
                    {
                        case "PilingBed1E":
                            beaminE1 = true;
                            break;

                        case "PilingBed1W":
                            beaminW1 = true;
                            break;
                        case "PilingBed2E":
                            beaminE2 = true;
                            break;
                        case "PilingBed2W":
                            beaminW2 = true;
                            break;
                    }
                }

                BeamInPilingBedE1 = beaminE1;
                BeamInPilingBedW1 = beaminW1;
                BeamInPilingBedW2 = beaminW2;
                BeamInPilingBedE2 = beaminE2;

            }
            else
            {
                BeamInPilingBedE1 = false;
                BeamInPilingBedW1 = false;
                BeamInPilingBedW2 = false;
                BeamInPilingBedE2 = false;
            }

            if (_beamsBedExit.Count > 0)
            {
                bool beaminE5 = true;
                bool beaminW5 = true;
                bool beamin5W1 = true;
                bool beamin5W2 = true;

                for (int i = 0; i < _beamsBedExit.Count; i++)
                {
                    switch (_beamsBedExit[i].Zone)
                    {
                        case "PilingBed5E":
                            beaminE5 = false;
                            break;

                        case "PilingBed5W":
                            beaminW5 = false;
                            break;
                        case "PilingBed5W1":
                            beamin5W1 = false;
                            break;

                        case "PilingBed5W2":
                            beamin5W2 = false;
                            break;
                    }
                }

                BeamNotInPilingBed5E = beaminE5;
                BeamNotInPilingBed5W = beaminW5;
                BeamNotInPilingBed5W1 = beamin5W1;
                BeamNotInPilingBed5W2 = beamin5W2;
            }
            else
            {
                BeamNotInPilingBed5E = true;
                BeamNotInPilingBed5W = true;
                BeamNotInPilingBed5W1 = true;
                BeamNotInPilingBed5W2 = true;
            }

        }

        private void DoProcess(CancellationToken token)
        {
            try
            {
                if (this.ThreadRunning)
                {
                    lock (this._lockInstance)
                    {
                        if (this.ThreadRunning)
                        {
                            bool cancelled = false;

                            try
                            {
                                while (true)
                                {
                                    lock (this._lockTO)
                                    {
                                        //Carga la lista con los Beams cargados en los tags
                                        BeamsInZones(Zones);

                                        PaintBeamsInLayout();

                                        BeamPosYAlign();

                                        //AdjustQueue();

                                        CheckBeamInZone();
                                    }

                                    Thread.Sleep(2500);

                                    if (token.IsCancellationRequested)
                                    {
                                        break;
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                                RdTrace.Exception(ex);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RdTrace.Exception(ex);
            }

            finally
            {
                if (!token.IsCancellationRequested)
                {
                    this._runningTask = new Task(() => DoProcess(token), token);
                    this._runningTask.Start();
                }
            }
        }


        #endregion

    }
}