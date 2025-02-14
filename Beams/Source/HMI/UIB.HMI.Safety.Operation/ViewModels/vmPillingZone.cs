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
        private ObservableCollection<Beam> _pillingBeams;
        private ObservableCollection<Beam> _beamsBedEntry;

        private ObservableCollection<Beam> _beamPillingBedW1;
        private ObservableCollection<Beam> _beamPillingBedW2;
        private ObservableCollection<Beam> _beamPillingBedW3;
        private ObservableCollection<Beam> _beamPillingBedW4;

        private ObservableCollection<Beam> _beamPillingBedE1;
        private ObservableCollection<Beam> _beamPillingBedE2;
        private ObservableCollection<Beam> _beamPillingBedE3;
        private ObservableCollection<Beam> _beamPillingBedE4;

        private ObservableCollection<Beam> _beamPillingBedQueueE;
        private ObservableCollection<Beam> _beamPillingBedQueueW;

        private ObservableCollection<Beam> _beamQueueW;
        private ObservableCollection<Beam> _beamQueueE;

        bool beamModified;
        private bool _beamInPillingBedW1;
        private bool _beamInPillingBedW2;
        private bool _beamInPillingBedW3;
        private bool _beamInPillingBedW4;
        private bool _beamInPillingBedW5;
        private bool _beamInPillingBedE1;
        private bool _beamInPillingBedE2;
        private bool _beamInPillingBedE3;
        private bool _beamInPillingBedE4;
        private bool _beamInPillingBedE5;
        private bool _beamInPillingQueueW;
        private bool _beamInPillingQueueE;
        private bool _beamInPillingPreQueueE;
        private bool _beamInPillingPreQueueW;

        private bool _beamInCollectingBedE;
        private bool _beamInCollectingBedW;

        private int PosXEast = 775;
        private int PosXWest = 100;

        private int PosYW1 = 125;
        private int PosYW2 = 255;
        private int PosYW3 = 315;
        private int PosYW4 = 390;
        private int PosYWPreQ = 465;
        private int PosYWQ = 540;
        private int PosYW5 = 615;

        private int PosYE1 = 125;
        private int PosYE2 = 255;
        private int PosYE3 = 315;
        private int PosYE4 = 390;
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
        /// Initializes a new instance of the <see cref="vmPillingZone"/> class.
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

        public bool BeamInPillingBedW1
        {
            get { return this._beamInPillingBedW1; }
            set
            {
                if (this._beamInPillingBedW1 != value)
                {
                    this._beamInPillingBedW1 = value;

                    OnPropertyChanged("BeamInPillingBedW1");

                }
            }
        }

        public bool BeamInPillingBedW2
        {
            get { return this._beamInPillingBedW2; }
            set
            {
                if (this._beamInPillingBedW2 != value)
                {
                    this._beamInPillingBedW2 = value;

                    OnPropertyChanged("BeamInPillingBedW2");

                }
            }
        }

        public bool BeamInPillingBedW3
        {
            get { return this._beamInPillingBedW3; }
            set
            {
                if (this._beamInPillingBedW3 != value)
                {
                    this._beamInPillingBedW3 = value;

                    OnPropertyChanged("BeamInPillingBedW3");

                }
            }
        }

        public bool BeamInPillingBedW4
        {
            get { return this._beamInPillingBedW4; }
            set
            {
                if (this._beamInPillingBedW4 != value)
                {
                    this._beamInPillingBedW4 = value;

                    OnPropertyChanged("BeamInPillingBedW4");

                }
            }
        }


        public bool BeamInPillingBedW5
        {
            get { return this._beamInPillingBedW5; }
            set
            {
                if (this._beamInPillingBedW5 != value)
                {
                    this._beamInPillingBedW5 = value;

                    OnPropertyChanged("BeamInPillingBedW5");

                }
            }
        }


        public bool BeamInPillingPreQueueE
        {
            get { return this._beamInPillingPreQueueE; }
            set
            {
                if (this._beamInPillingPreQueueE != value)
                {
                    this._beamInPillingPreQueueE = value;

                    OnPropertyChanged("BeamInPillingPreQueueE");

                }
            }
        }

        public bool BeamInPillingQueueE
        {
            get { return this._beamInPillingQueueE; }
            set
            {
                if (this._beamInPillingQueueE != value)
                {
                    this._beamInPillingQueueE = value;

                    OnPropertyChanged("BeamInPillingQueueE");

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


        public bool BeamInPillingBedE1
        {
            get { return this._beamInPillingBedE1; }
            set
            {
                if (this._beamInPillingBedE1 != value)
                {
                    this._beamInPillingBedE1 = value;

                    OnPropertyChanged("BeamInPillingBedE1");

                }
            }
        }

        public bool BeamInPillingBedE2
        {
            get { return this._beamInPillingBedE2; }
            set
            {
                if (this._beamInPillingBedE2 != value)
                {
                    this._beamInPillingBedE2 = value;

                    OnPropertyChanged("BeamInPillingBedE2");

                }
            }
        }

        public bool BeamInPillingBedE3
        {
            get { return this._beamInPillingBedE3; }
            set
            {
                if (this._beamInPillingBedE3 != value)
                {
                    this._beamInPillingBedE3 = value;

                    OnPropertyChanged("BeamInPillingBedE3");

                }
            }
        }

        public bool BeamInPillingBedE4
        {
            get { return this._beamInPillingBedE4; }
            set
            {
                if (this._beamInPillingBedE4 != value)
                {
                    this._beamInPillingBedE4 = value;

                    OnPropertyChanged("BeamInPillingBedE4");

                }
            }
        }

        public bool BeamInPillingPreQueueW
        {
            get { return this._beamInPillingPreQueueW; }
            set
            {
                if (this._beamInPillingPreQueueW != value)
                {
                    this._beamInPillingPreQueueW = value;

                    OnPropertyChanged("BeamInPillingPreQueueW");

                }
            }
        }

        public bool BeamInPillingQueueW
        {
            get { return this._beamInPillingQueueW; }
            set
            {
                if (this._beamInPillingQueueW != value)
                {
                    this._beamInPillingQueueW = value;

                    OnPropertyChanged("BeamInPillingQueueW");

                }
            }
        }

        public bool BeamInPillingBedE5
        {
            get { return this._beamInPillingBedE5; }
            set
            {
                if (this._beamInPillingBedE5 != value)
                {
                    this._beamInPillingBedE5 = value;

                    OnPropertyChanged("BeamInPillingBedE5");

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


        public ObservableCollection<Beam> PillingBeams
        {
            get { return this._pillingBeams; }
            set
            {
                if (this._pillingBeams != value)
                {
                    this._pillingBeams = value;
                    OnPropertyChanged(nameof(PillingBeams));
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
        public void EndLoading()
        {
            RdTrace.Debug("Set Layout Element");

            this._layoutElementSem.Set();
        }
        #endregion

        #region private methods

        private void Main()
        {
            //Inicializo las zonas
            _zones = new List<string>();
            _beams = new List<Beam>();
            _beamsBedEntry = new ObservableCollection<Beam>();
            _pillingBeams = new ObservableCollection<Beam>();
            _beamsBedExit = new ObservableCollection<Beam>();
            _beamPillingBedW1 = new ObservableCollection<Beam>();
            _beamPillingBedW2 = new ObservableCollection<Beam>();
            _beamPillingBedW3 = new ObservableCollection<Beam>();
            _beamPillingBedW4 = new ObservableCollection<Beam>();
            _beamPillingBedE1 = new ObservableCollection<Beam>();
            _beamPillingBedE2 = new ObservableCollection<Beam>();
            _beamPillingBedE3 = new ObservableCollection<Beam>();
            _beamPillingBedE4 = new ObservableCollection<Beam>();
            _zones.Add("PillingBed1W");
            _zones.Add("PillingBed2W");
            _zones.Add("PillingBed3W");
            _zones.Add("PillingBed4W");
            _zones.Add("PillingBed1E");
            _zones.Add("PillingBed2E");
            _zones.Add("PillingBed3E");
            _zones.Add("PillingBed4E");
            _zones.Add("PillingBedQueueE");
            _zones.Add("PillingBedQueueW");
            _zones.Add("PillingBed5W");
            _zones.Add("PillingBed5E");
            _zones.Add("PillingBedPreQueueE");
            _zones.Add("PillingBedPreQueueW");


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
                case "PillingBed1E":
                case "PillingBed1W":
                case "PillingBed2E":
                case "PillingBed2W":
                    beams = BeamsBedEntry.ToList();
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
                if(beam.Zone != "PillingBed5W" && beam.Zone != "PillingBed5E") 
                    beams = PillingBeams.Where(x => x.Zone == beam.Zone).ToList();
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
                if (Beams.Count != _beamsBedExit.Count + _pillingBeams.Count + _beamsBedEntry.Count || beamModified)
                {
                    _beamsBedEntry.Clear();
                    _pillingBeams.Clear();
                    _beamsBedExit.Clear();

                    foreach (var beam in Beams)
                    {
                        switch (beam.Zone)
                        {
                            case "PillingBed1W":
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

                            case "PillingBed1E":
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

                            case "PillingBed2W":
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

                            case "PillingBed2E":
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

                            case "PillingBed3W":

                                beam.PositionX = PosXWest;
                                beam.PositionY = PosYW3;

                                _pillingBeams.Add(beam);

                                OnPropertyChanged(nameof(BeamsBedEntry));
                                break;

                            case "PillingBed3E":


                                beam.PositionX = PosXEast;
                                beam.PositionY = PosYE3;

                                _pillingBeams.Add(beam);

                                OnPropertyChanged(nameof(BeamsBedEntry));
                                break;

                            case "PillingBed4W":

                                beam.PositionX = PosXWest;
                                beam.PositionY = PosYW4;

                                _pillingBeams.Add(beam);

                                OnPropertyChanged(nameof(BeamsBedEntry));
                                break;

                            case "PillingBed4E":

                                beam.PositionX = PosXEast;
                                beam.PositionY = PosYE4;

                                _pillingBeams.Add(beam);
                                OnPropertyChanged(nameof(BeamsBedEntry));
                                break;
                            case "PillingBedPreQueueW":

                                beam.PositionX = PosXWest;
                                beam.PositionY = PosYWPreQ;


                                _pillingBeams.Add(beam);
                                OnPropertyChanged(nameof(BeamsBedEntry));
                                break;

                            case "PillingBedPreQueueE":

                                beam.PositionX = PosXEast;
                                beam.PositionY = PosYEPreQ;


                                _pillingBeams.Add(beam);

                                OnPropertyChanged(nameof(BeamsBedEntry));
                                break;
                            case "PillingBedQueueW":
                                beam.PositionX = PosXWest;
                                beam.PositionY = PosYWQ;


                                _pillingBeams.Add(beam);

                                OnPropertyChanged(nameof(BeamsBedEntry));
                                break;

                            case "PillingBedQueueE":

                                beam.PositionX = PosXEast;
                                beam.PositionY = PosYEQ;


                                _pillingBeams.Add(beam);

                                OnPropertyChanged(nameof(BeamsBedEntry));
                                break;

                            case "PillingBed5E":

                                beam.PositionX = PosXEast;
                                beam.PositionY = PosYE5;
                                _beamsBedExit.Add(beam);
                                OnPropertyChanged(nameof(BeamsBedEntry));
                                break;

                            case "PillingBed5W":

                                beam.PositionX = PosXEast;
                                beam.PositionY = PosYW5;
                                _beamsBedExit.Add(beam);
                                OnPropertyChanged(nameof(BeamsBedEntry));
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
            ObservableCollection<Beam> beamsAdjustE1 = new ObservableCollection<Beam>();
            ObservableCollection<Beam> beamsAdjustE2 = new ObservableCollection<Beam>();
            ObservableCollection<Beam> beamsAdjustW1 = new ObservableCollection<Beam>();
            ObservableCollection<Beam> beamsAdjustW2 = new ObservableCollection<Beam>();

            for (int i = 0; i < _beamsBedEntry.Count; i++)
            {
                switch (_beamsBedEntry[i].Zone)
                {
                    case "PillingBed1E":
                        beamsAdjustE1.Add(_beamsBedEntry[i]);
                        break;

                    case "PillingBed1W":
                        beamsAdjustW1.Add(_beamsBedEntry[i]);
                        break;
                    case "PillingBed2E":
                        beamsAdjustE2.Add(_beamsBedEntry[i]);
                        break;
                    case "PillingBed2W":
                        beamsAdjustW2.Add(_beamsBedEntry[i]);
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

        }

        //void AdjustQueue()
        //{
        //    var queueAlign = BeamsInQueue.Where(p => p.PositionY == 430 && p.PositionX == 535).Any();

        //    if (!queueAlign)
        //    {
        //        var last = BeamsInQueue.OrderByDescending(p => p.PositionY).ToList();

        //        for (int i = 0; i < last.Count; i++)
        //        {
        //            if (i == 0)
        //            {
        //                last[i].PositionY = 430;
        //            }
        //            else
        //            {
        //                last[i].PositionY = last[i - 1].PositionY - 35;
        //            }
        //        }
        //    }

        //}

        private void CheckBeamInZone()
        {
            if (_pillingBeams.Count > 0)
            {
                bool beaminE3 = false;
                bool beaminE4 = false;
                bool beaminW3 = false;
                bool beaminW4 = false;
                bool beaminPreQW = false;
                bool beaminPreQE = false;
                bool beaminQE = false;
                bool beaminQw = false;
                for (int i = 0; i < _pillingBeams.Count; i++)
                {
                    switch (_pillingBeams[i].Zone)
                    {

                        case "PillingBed3E":
                            beaminE3 = true;
                            break;

                        case "PillingBed4E":
                            beaminE4 = true;
                            break;

                        case "PillingBed3W":
                            beaminW3 = true;
                            break;

                        case "PillingBed4W":
                            beaminW4 = true;
                            break;
                        case "PillingBedPreQueueE":
                            beaminPreQE = true;
                            break;
                        case "PillingBedPreQueueW":
                            beaminPreQW = true;
                            break;
                        case "PillingBedQueueW":
                            beaminQw = true;
                            break;
                        case "PillingBedQueueE":
                            beaminQE = true;
                            break;
                    }
                }

                BeamInPillingBedE3 = beaminE3;
                BeamInPillingBedE4 = beaminE4;
                BeamInPillingBedW3 = beaminW3;
                BeamInPillingBedW4 = beaminW4;

                BeamInPillingQueueE = beaminQE;
                BeamInPillingPreQueueE = beaminPreQE;
                BeamInPillingPreQueueW = beaminPreQW;
                BeamInPillingQueueW = beaminQw;
            }
            else
            {
                BeamInPillingBedE2 = false;
                BeamInPillingBedE3 = false;
                BeamInPillingBedE4 = false;
                BeamInPillingBedW2 = false;
                BeamInPillingBedW3 = false;
                BeamInPillingBedW4 = false;
                BeamInPillingQueueE = false;
                BeamInPillingQueueW = false;
                BeamInPillingPreQueueE = false;
                BeamInPillingPreQueueW = false;
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
                        case "PillingBed1E":
                            beaminE1 = true;
                            break;

                        case "PillingBed1W":
                            beaminW1 = true;
                            break;
                        case "PillingBed2E":
                            beaminE2 = true;
                            break;
                        case "PillingBed2W":
                            beaminW2 = true;
                            break;
                    }
                }

                BeamInPillingBedE1 = beaminE1;
                BeamInPillingBedW1 = beaminW1;
                BeamInPillingBedW2 = beaminW2;
                BeamInPillingBedE2 = beaminE2;

            }
            else
            {
                BeamInPillingBedE1 = false;
                BeamInPillingBedW1 = false;
                BeamInPillingBedW2 = false;
                BeamInPillingBedE2 = false;
            }

            if (_beamsBedExit.Count > 0)
            {
                bool beaminE5 = false;
                bool beaminW5 = false;

                for (int i = 0; i < _beamsBedExit.Count; i++)
                {
                    switch (_beamsBedExit[i].Zone)
                    {
                        case "PillingBed5E":
                            beaminE5 = true;
                            break;

                        case "PillingBed5W":
                            beaminE5 = true;
                            break;
                    }
                }

                BeamInPillingBedE5 = beaminE5;
                BeamInPillingBedW5 = beaminW5;


            }
            else
            {
                BeamInPillingBedE5 = false;
                BeamInPillingBedW5 = false;
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