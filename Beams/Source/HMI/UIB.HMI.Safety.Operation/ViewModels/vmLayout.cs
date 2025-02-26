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

    //using HSM.HMI.Safety.Operation.Enumerations;

    public class vmLayout : ModelViewBase
    {
        #region private attributes

        private EventWaitHandle _layoutElementSem;
        private readonly object _layoutElementLock;
        private List<object> _lstLayoutElements;

        private ObservableCollection<Beam> _beamsBedExit;
        private ObservableCollection<Beam> _beamsInQueue;
        private ObservableCollection<Beam> _beamsBedEntry;

        bool beamModified;
        private bool _beamInStraightener;
        private bool _beamInBedExit;
        private bool _beamInBedExitWest1;
        private bool _beamInBedEntry;


        private bool _general_layout;
        private List<string> _zones;
        private List<Beam> _beams;

        private Dictionary<string, object> _allMachine;
        private Dictionary<string, object> _machineSelected;
        private HSM_Zone_Machine[] _zone_machine;
       // private vmYard[] _yards;

        private Dictionary<string, object> _allEnableComponents;
        private Dictionary<string, object> _allEnableComponentsSelected;

        private int PosXEast;
        private int PosXWest;
        private int PosYWest;
        private int PosYEast;

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
        /// Initializes a new instance of the <see cref="vmLayout"/> class.
        /// </summary>
        /// <param name="zones"></param>
        /// <param name="requests"></param>
        /// <param name="machines"></param>
        /// <param name="maint"></param>
        /// <param name="locations"></param>
        public vmLayout()
            : base()
        {
            this._layoutElementSem = new AutoResetEvent(false);
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

        public bool BeamInStraightener
        {
            get { return this._beamInStraightener; }
            set
            {
                if (this._beamInStraightener != value)
                {
                    this._beamInStraightener = value;

                    OnPropertyChanged("BeamInStraightener");

                }
            }
        }

        public bool BeamNotInBedExit
        {
            get { return this._beamInBedExit; }
            set
            {
                if (this._beamInBedExit != value)
                {
                    this._beamInBedExit = value;

                    OnPropertyChanged("BeamNotInBedExit");

                }
            }
        }

        public bool BeamNotInBedExitWest1
        {
            get { return this._beamInBedExitWest1; }
            set
            {
                if (this._beamInBedExitWest1 != value)
                {
                    this._beamInBedExitWest1 = value;

                    OnPropertyChanged("BeamNotInBedExitWest1");

                }
            }
        }

        public bool BeamInBedEntry
        {
            get { return this._beamInBedEntry; }
            set
            {
                if (this._beamInBedEntry != value)
                {
                    this._beamInBedEntry = value;

                    OnPropertyChanged("BeamInBedEntry");

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
        public ObservableCollection<Beam> BeamsInQueue
        {
            get { return this._beamsInQueue; }
            set
            {
                if (this._beamsInQueue != value)
                {
                    this._beamsInQueue = value;
                    OnPropertyChanged(nameof(BeamsInQueue));
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
           _beamsInQueue = new ObservableCollection<Beam>();
           _beamsBedExit = new ObservableCollection<Beam>();
            _zones.Add("Straightener");
            _zones.Add("CollectingBedEntryWest");
            _zones.Add("CollectingBedExitQueueWest");
            _zones.Add("CollectingBedExitWest");
            _zones.Add("CollectingBedExitWest1");

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
            switch (beam.Zone)
            {
                case "Straightener":
                    beams = BeamsBedEntry.ToList();
                    break;

                case "CollectingBedEntryWest":
                    beams = BeamsBedEntry.ToList();
                    break;

                case "CollectingBedExitQueueWest":
                    beams = BeamsInQueue.ToList();
                    break;

                case "CollectingBedExitWest":
                    beams = BeamsBedExit.ToList();
                    break;
                case "CollectingBedExitWest1":
                    beams = BeamsBedExit.ToList();
                    break;
            }
            vmZoneDetail generalDetails = new vmZoneDetail(beam);
            ZoneDetail zoneDetail = new ZoneDetail(beam,beams);
            zoneDetail.ShowDialog();
        }

        private void BeamsInZone( List<string>zones)
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
                    if (!String.IsNullOrEmpty(beamsInZoneName[j])) { 
                    var beam = new Beam(beamsInZoneName[j], zones[i]);
                     beams.Add(beam);
                    }
                }
            }
            if(!this.Beams.SequenceEqual(beams))
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
                if (Beams.Count != _beamsBedExit.Count + _beamsInQueue.Count + _beamsBedEntry.Count || beamModified)
                {
                    _beamsBedEntry.Clear();
                    _beamsInQueue.Clear();
                    _beamsBedExit.Clear();

                    foreach (var beam in Beams)
                    {
                        switch (beam.Zone)
                        {
                            case "CollectingBedEntryWest":
                                    beam.PositionX = 100;
                                    beam.PositionY = 65;
                                    _beamsBedEntry.Add(beam);
                                    OnPropertyChanged(nameof(BeamsBedEntry));
                                break;

                            case "Straightener":
                                    beam.PositionX = 535;
                                    beam.PositionY = 65;
                                    _beamsBedEntry.Add(beam);
                                    OnPropertyChanged(nameof(BeamsBedEntry));
                                break;

                            case "CollectingBedExitQueueWest":
                                    if (_beamsInQueue.Count > 0)
                                    {
                                        beam.PositionX = _beamsInQueue.LastOrDefault().PositionX;
                                        beam.PositionY = _beamsInQueue.LastOrDefault().PositionY - 35;
                                    }
                                    else
                                    {
                                        beam.PositionX = 100;
                                        beam.PositionY = 430;
                                    }
                                    _beamsInQueue.Add(beam);
                                    OnPropertyChanged(nameof(BeamsInQueue));
                                break;

                            case "CollectingBedExitWest1":

                                    beam.PositionX = 100;
                                    _beamsBedExit.Add(beam);
                                    OnPropertyChanged(nameof(BeamsBedExit));
                                
                                break;

                            case "CollectingBedExitWest":

                                beam.PositionX = 100;
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
            int LayoutHeight = 180;
            int height_beams = 35;

            var space = LayoutHeight - _beamsBedExit.Count * height_beams;

            var result = space / (_beamsBedExit.Count + 1);

            for (int i = _beamsBedExit.Count - 1; i  >= 0; i--)
            {
                _beamsBedExit[i].PositionY = (625 - LayoutHeight) + (_beamsBedExit.Count - i) * (result+height_beams);
            }

        }

        void AdjustQueue()
        {
            var queueAlign = BeamsInQueue.Where(p => p.PositionY == 430 && p.PositionX == 100).Any();

            if (!queueAlign)
            {
                var last = BeamsInQueue.OrderByDescending(p => p.PositionY).ToList();

                for (int i = 0; i < last.Count; i++)
                {
                    if (i == 0)
                    {
                        last[i].PositionY = 430;
                    }
                    else
                    {
                        last[i].PositionY = last[i-1].PositionY-35;
                    }
                }
            }

        }

        private void CheckBeamInZone()
        {
            if(_beamsBedExit.Count > 0)
            {
                bool beaminBedExit = true;
                bool beaminBedExit1 = true;
                foreach (var beam in _beamsBedExit)
                {
                    switch (beam.Zone)
                    {
                        case "CollectingBedExitWest":
                            beaminBedExit = false;
                            break;
                        case "CollectingBedExitWest1":
                            beaminBedExit1 = false;
                            break;
                    }
                }
                BeamNotInBedExit = beaminBedExit;
                BeamNotInBedExitWest1 = beaminBedExit1;
            }
            else
            {
                BeamNotInBedExit = true;
                BeamNotInBedExitWest1 = true;
            }

            if (_beamsBedEntry.Count > 0)
            {
                foreach (var beam in _beamsBedEntry)
                {
                    switch (beam.Zone)
                    {
                        case "Straightener":
                            BeamInStraightener = true;
                            BeamInBedEntry = false;
                            break;
                        case "CollectingBedEntryWest":
                            BeamInBedEntry = true;
                            BeamInStraightener = false;
                            break;
                    }
                }
            }
            else
            {
                BeamInBedEntry = false;
                BeamInStraightener = false;
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
                                        BeamsInZone(Zones);

                                        PaintBeamsInLayout();

                                        BeamPosYAlign();

                                        AdjustQueue();

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