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


namespace MSM.HMI.Safety.Operation.ViewModels
{
    using Janus.Rodeo.Windows.Library.Rd_Log;
    using Janus.Rodeo.Windows.Library.Rd_Common;
    using Janus.Rodeo.Windows.Library.UI.Controls;
    using Janus.Rodeo.Windows.Library.UI.Controls.Helpers;
    using Janus.Rodeo.Windows.Library.UI.Controls.Widgets;
    using Janus.Rodeo.Windows.Library.UI.Common;
    using RodeoTagWrapper;


    using MSM.Database;
    using MSM.HMI.Safety.Operation.Enumerations;
    using MSM.HMI.Safety.Operation.Views;
    using MSM.Utility.Common;
    //using MSM.Database;
    using MSM.Utility.Configuration;
    using MSM.Utility.Common.Catalogs;
    using System.Windows;
    using MSM.HMI.Safety.Operation.Views.Windows;
    using System.Reflection;
    using System.IO;

    //using MSM.HMI.Safety.Operation.Enumerations;

    public class vmLayout : ModelViewBase
    {
        #region private attributes
      //  private vmZoneSection[] _sections;
      // // private vmLocation[] _locations;
      ////  private vmPosition[] _positions;
      //  private vmFence[] _fences;
      //  private vmRequest[] _requests;
      //  private vmZone _fly_zone;
      // // private vmMachine[] _machines;
      //  //private vmMaint _maint;
      //  private vmZoneTemporaryDrawing _temporary_drawing;

        private EventWaitHandle _layoutElementSem;
        private readonly object _layoutElementLock;
        private ObservableCollection<object> _lstLayoutElements;

        private bool _first_line_visible;
        private bool _temporary_zone_visible;
        private bool _layer1_visible;
        private bool _layer2_visible;
        private bool _fence_visible;
        private bool _position_visible;
        private bool _transport_order_visible;
        private bool _machine_visible;
        private bool _requests_visible;
        private bool _general_layout;
        private string _zone_name;

        private Dictionary<string, object> _allMachine;
        private Dictionary<string, object> _machineSelected;
        private MSM_Zone_Machine[] _zone_machine;
       // private vmYard[] _yards;

        private Dictionary<string, object> _allEnableComponents;
        private Dictionary<string, object> _allEnableComponentsSelected;

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
        public vmLayout(CT_Yard[] yards)
            : base()
        {

            RdTrace.Debug("Begin Layout");
            this._first_line_visible = true;
            this._temporary_zone_visible = true;
            this._fence_visible = false;
            this._layer1_visible = false;
            this._layer2_visible = false;
            this._transport_order_visible = false;
            this._machine_visible = true;
            this._requests_visible = true;
            this._fence_visible = true;
            this._position_visible = true;
            this._CreateTemporaryZoneCommand = new RelayCommand(param => this.CreateTemporaryZoneExecute(param));
            this._ShowCommand = new RelayCommand(param => this.ShowExecute(param));
            this._EnableFeaturesCommand = new RelayCommand(param => this.EnableFeaturesExecute(param));
            this._SelectYardCommand = new RelayCommand(param => this.SelectYardExecute(param));
            this._FooCommand = new RelayCommand(param => this.SendExecute(param));
        }
        #endregion

        #region Properties
      

        public ObservableCollection<object> LayoutElements
        {
            get 
            {
                return this._lstLayoutElements; 
            }
        }


        public bool IsInverted
        {
            get { return Configurations.HMIs.safety_layout_inverted; }
        }

        public bool IsFirstLineVisible
        {
            get { return this._first_line_visible; }
            set
            {
                if (this._first_line_visible != value)
                {
                    this._first_line_visible = value;

                    OnPropertyChanged("IsFirstLineVisible");
                }
            }
        }

        public bool IsTemporaryZoneVisible
        {
            get { return this._temporary_zone_visible; }
            set
            {
                if (this._temporary_zone_visible != value)
                {
                    this._temporary_zone_visible = value;

                    OnPropertyChanged("IsTemporaryZoneVisible");
                }
            }
        }

        public string ZoneName
        {
            get { return this._zone_name; }
            set
            {
                if (this._zone_name != value)
                {
                    this._zone_name = value;

                   this.OnPropertyChanged("ZoneName");

                }
            }
        }

        public string Beams
        {
            get { return this._zone_name; }
            set
            {
                if (this._zone_name != value)
                {
                    this._zone_name = value;

                    this.OnPropertyChanged("ZoneName");

                }
            }
        }

        public bool IsLayer1Visible
        {
            get { return this._layer1_visible; }
            set
            {
                if (this._layer1_visible != value)
                {
                    this._layer1_visible = value;

                    OnPropertyChanged("IsLayer1Visible");
                   
                }
            }
        }

        public bool IsLayer2Visible
        {
            get { return this._layer2_visible; }
            set
            {
                if (this._layer2_visible != value)
                {
                    this._layer2_visible = value;

                    OnPropertyChanged("IsLayer2Visible");                    
                }
            }
        }

        public bool IsFenceVisible
        {
            get { return this._fence_visible; }
            set
            {
                if (this._fence_visible != value)
                {
                    this._fence_visible = value;

                    OnPropertyChanged("IsFenceVisible");
                }
            }
        }

        public bool IsPositionVisible
        {
            get { return this._position_visible; }
            set
            {
                if (this._position_visible != value)
                {
                    this._position_visible = value;

                    OnPropertyChanged("IsPositionVisible");
                }
            }
        }

        public bool IsRequestVisible
        {
            get { return this._requests_visible; }
            set
            {
                if (this._requests_visible != value)
                {
                    this._requests_visible = value;

                    OnPropertyChanged("IsRequestVisible");
                }
            }
        }

        public bool IsTransportOrderVisible
        {
            get { return this._transport_order_visible; }
            set
            {
                if (this._transport_order_visible != value)
                {
                    this._transport_order_visible = value;

                    OnPropertyChanged("IsTransportOrderVisible");
                }
            }
        }

        public bool IsMachineVisible
        {
            get { return this._machine_visible; }
            set
            {
                if (this._machine_visible != value)
                {
                    this._machine_visible = value;

                    OnPropertyChanged("IsMachineVisible");
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

        private void EnableFeaturesExecute(object parameter)
        {
            if (this.AllEnableComponentsSelected.Count > 0)
            {
                var a = this.AllEnableComponentsSelected;

                foreach (var feature in this.AllEnableComponents)
                {

                    if (this.AllEnableComponentsSelected.ContainsKey(feature.Key))
                    {
                        switch (feature.Value)
                        {
                            case FeatureLayoutTypes.IsRequestVisible:
                                this.IsRequestVisible = true;
                                break;
                            case FeatureLayoutTypes.IsLayerVisible:
                                this.IsLayer1Visible = true;
                                break;
                            case FeatureLayoutTypes.IsFenceVisible:
                                this.IsFenceVisible = true;
                                break;
                            case FeatureLayoutTypes.IsPositionVisible:
                                this.IsPositionVisible = true;
                                break;
                        }
                    }
                    else
                    {
                        switch (feature.Value)
                        {
                            case FeatureLayoutTypes.IsRequestVisible:
                                this.IsRequestVisible = false;
                                break;
                            case FeatureLayoutTypes.IsLayerVisible:
                                this.IsLayer1Visible = false;
                                break;
                            case FeatureLayoutTypes.IsFenceVisible:
                                this.IsFenceVisible = false;
                                break;
                            case FeatureLayoutTypes.IsPositionVisible:
                                this.IsPositionVisible = false;
                                break;
                        }
                    }
                }
            }
            else 
            {
                this.IsRequestVisible = false;
                this.IsLayer1Visible = false;
                this.IsLayer2Visible = false;
                this.IsFenceVisible = false;
                this.IsPositionVisible = false;
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
                    //    foreach( MSM_Zone_Machine zoneMachine in this._zone_machine.Where(p => p.Rodeo_Machine_Group.Name == machine && p.CanBeAccessed))  
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



        /// <summary>
        /// Paint Layout Elements
        /// </summary>
        private async void PaintLayoutElement()
        {
            await Task.Run(() =>
            {
                try
                {
                    int indexLocation = 0;

                    RdTrace.Debug("Waiting Layout Element");

                    this._layoutElementSem.WaitOne();

                    RdTrace.Debug("Reset Layout Element");
                }
                catch (Exception ex)
                {
                    RdTrace.Exception(ex);
                }
            });
        }

        private void SendExecute(object parameter)
        {

            var test = RodeoTagWrapper.WriteTextTag("MSM.CBED_COLLECTINGBEDENTRYEAST_BEAMS", "test");
            var test2 = RodeoTagWrapper.ReadTextTag("MSM.CBED_COLLECTINGBEDENTRYEAST_BEAMS");

            ZoneName = parameter.ToString();
            Beams = parameter.ToString();
            vmZoneDetail generalDetail0s = new vmZoneDetail(parameter.ToString(), "test");

            ZoneDetail zoneDetail = new ZoneDetail(this);

            zoneDetail.ShowDialog();

        }


        #endregion

    }
}