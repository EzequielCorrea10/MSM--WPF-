using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HSM.HMI.Safety.Operation.ViewModels
{
    using Janus.Rodeo.Windows.Library.Rd_Common;
    using Janus.Rodeo.Windows.Library.UI.Controls;
    using Janus.Rodeo.Windows.Library.Rd_Log;

    using HSM.Utility.Configuration;
    using HSM.Utility.Common;
    using HSM.Utility.Common.Catalogs;
    using HSM.HMI.Safety.Operation.Enumerations;

    internal class vmMainCommon : ModelViewBase, IDisposable
    {
        #region private attributes
        private bool _can_close;
        private ScreenPages _activePage;
        private vmLayout _layout_controller;
        //private vmLayoutSemiAuto _layout_semiauto_controller;
        //private vmPositionList _position_controller;
        //private vmTargetDestination _target_controller;
        //private vmZoneList _zone_controller;
        //private vmRequestList _request_controller;
        //private vmInterlocks _interlock_controller;
        //private vmAlarms _alarm_controller;
        //private vmEStops _estop_controller;
        #endregion

        #region private tags
        //private vmMachine[] _machines;
        ////private vmMaint _maint;
        //private vmZone[] _zones;
        //private vmRequest[] _requests;
        //private vmLocation[] _locations;
        //private vmLocation[] _semi_locations;
        //private vmPosition[] _positions;
        //private vmZoneInterlocks[] _zone_interlocks;
        //private vmRequestInterlocks[] _request_interlocks;
        private CT_Yard[] _yards;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="vmMainCommon"/> class.
        /// </summary>
        public vmMainCommon(bool can_close)
            : base()
        {
            this._can_close = can_close;

            if (!this.IsDesignerContext())
            {
                this._yards = GetYards();

              //  this._target_controller = new vmTargetDestination(this.Machines.FirstOrDefault(m => m.Properties.Type.Reference == Tracking.Server.Common.Enumerations.MachineTypes.SemiCrane).Properties, this.Positions.Select(p => new vmPositionTarget(p)).ToList());

                this.cancelTask = new CancellationTokenSource();
                //this.runningTask = new Task(() => DoProcess(cancelTask.Token), cancelTask.Token);
            //    this.runningTask.Start();
            }
        }
        #endregion

        #region Properties
        public bool CanClose
        {
            get { return this._can_close; }
            set
            {
                if (this._can_close != value)
                {
                    this._can_close = value;

                    this.OnPropertyChanged("CanClose");
                }
            }
        }



        public ScreenPages ActivePage
        {
            get { return this._activePage = ScreenPages.Layout; }
            set
            {
                if (this._activePage != value)
                {
                    this._activePage = value;
                    this._activePage = ScreenPages.Layout;
                   // this.OnPropertyChanged("LayoutActive");

                    HSM.HMI.Safety.Operation.Properties.Settings.Default.SCREEN = (int)ScreenPages.Layout;
                    HSM.HMI.Safety.Operation.Properties.Settings.Default.Save();
                }
            }
        }

        public bool LayoutActive
        {
            get { return this._activePage == ScreenPages.Layout; }
            set
            {
                if (value)
                {
                    this.ActivePage = ScreenPages.Layout;
                }
            }
        }

        public vmLayout LayoutController
        {
            get
            {
                if (this._layout_controller == null)
                {
                    this._layout_controller = new vmLayout( this._yards);
                }
                return this._layout_controller;
            }
        }

        public bool LayoutSemiAutoActive
        {
            get { return this._activePage == ScreenPages.LayoutSemiAuto; }
            set
            {
                if (value)
                {
                    this.ActivePage = ScreenPages.LayoutSemiAuto;
                }
            }
        }

        //public vmLayoutSemiAuto LayoutSemiAutoController
        //{
        //    get 
        //    { 
        //        if (this._layout_semiauto_controller == null)
        //        {
        //            this._layout_semiauto_controller = new vmLayoutSemiAuto(this.Zones, this.Locations, this.Positions, this.Machines.Where(m=>m.Properties.Type.Reference == Tracking.Server.Common.Enumerations.MachineTypes.SemiCrane).ToArray(), this._yards);
        //        }
        //        return this._layout_semiauto_controller; 
        //    }
        //}

        public bool PositionActive
        {
            get { return this._activePage == ScreenPages.Position; }
            set
            {
                if (value)
                {
                    this.ActivePage = ScreenPages.Position;
                }
            }
        }

        //public vmPositionList PositionController
        //{
        //    get
        //    {
        //        if (this._position_controller == null)
        //        {
        //            this._position_controller = new vmPositionList(this.Positions.Where(p=>p.Properties.Reference == HSM.Safety.Server.Common.Enumerations.PositionTypes.Temporal).ToList());
        //        }
        //        return this._position_controller;
        //    }
        //}

        public bool TargetActive
        {
            get { return this._activePage == ScreenPages.Target; }
            set
            {
                if (value)
                {
                    this.ActivePage = ScreenPages.Target;
                }
            }
        }

        //public vmTargetDestination TargetController
        //{
        //    get
        //    {
        //        if (this._target_controller == null)
        //        {
        //            this._target_controller = new vmTargetDestination(this._machines.FirstOrDefault(m => m.Properties.Type.Reference == Tracking.Server.Common.Enumerations.MachineTypes.SemiCrane).Properties, this.Positions.Select(p => new vmPositionTarget(p)).ToList());
        //        }
        //        return this._target_controller;
        //    }
        //}

        //public vmTargetDestination TargetController
        //{
        //    get { return this._target_controller; }
        //    set
        //    {
        //        if (this._target_controller != value)
        //        {
        //            this._target_controller = value;

        //            this.OnPropertyChanged("TargetController");
        //        }
        //    }
        //}

        public bool ZoneActive
        {
            get { return this._activePage == ScreenPages.Zones; }
            set
            {
                if (value)
                {
                    this.ActivePage = ScreenPages.Zones;
                }
            }
        }

        //public vmZoneList ZoneController
        //{
        //    get
        //    {
        //        if (this._zone_controller == null)
        //        {
        //            this._zone_controller = new vmZoneList(this.Zones);
        //        }
        //        return this._zone_controller;
        //    }
        //}

        public bool RequestActive
        {
            get { return this._activePage == ScreenPages.Requests; }
            set
            {
                if (value)
                {
                    this.ActivePage = ScreenPages.Requests;
                }
            }
        }

        //public vmRequestList RequestController
        //{
        //    get 
        //    { 
        //        if (this._request_controller == null)
        //        {
        //            this._request_controller = new vmRequestList(this.Requests);
        //        }
        //        return this._request_controller; 
        //    }
        //}

        public bool InterlockActive
        {
            get { return this._activePage == ScreenPages.Interlocks; }
            set
            {
                if (value)
                {
                    this.ActivePage = ScreenPages.Interlocks;
                }
            }
        }

        //public vmInterlocks InterlockController
        //{
        //    get 
        //    { 
        //        if (this._interlock_controller == null)
        //        {
        //            this._zone_interlocks = this.Zones.Where(p => p.Interlocks != null).Select(p => p.Interlocks).ToArray();
        //            this._request_interlocks = this.Requests.Where(p => p.Interlocks != null).Select(p => p.Interlocks).ToArray();
        //            this._interlock_controller = new vmInterlocks(this._zone_interlocks, this._request_interlocks);
        //        }
        //        return this._interlock_controller; 
        //    }
        //}

        public bool AlarmActive
        {
            get { return this._activePage == ScreenPages.Alarms; }
            set
            {
                if (value)
                {
                    this.ActivePage = ScreenPages.Alarms;
                }
            }
        }

        //public vmAlarms AlarmController
        //{
        //    get 
        //    { 
        //        if (this._alarm_controller == null)
        //        {
        //            this._alarm_controller = new vmAlarms();
        //        }
        //        return this._alarm_controller; 
        //    }
        //}

        //public vmEStops EStopController
        //{
        //    get 
        //    { 
        //        if (this._estop_controller == null)
        //        {
        //            this._estop_controller = new vmEStops(this.Requests, this.Machines);
        //        }
        //        return this._estop_controller; 
        //    }
        //}
        #endregion

        #region private methods
        //public static vmMachine[] GetMachines()
        //{
        //    List<vmMachine> lstMachine = new List<vmMachine>();

        //    for (int i = 0; i < Handlers.DBAccess.Catalogs._machines.Length; i++)
        //    {
        //        if (Handlers.DBAccess.Catalogs._machines[i].Type.Reference == HSM.Tracking.Server.Common.Enumerations.MachineTypes.Crane || Handlers.DBAccess.Catalogs._machines[i].Type.Reference == HSM.Tracking.Server.Common.Enumerations.MachineTypes.SemiCrane)
        //        {
        //            vmCraneMachine operation = new vmCraneMachine(Handlers.DBAccess.Catalogs._machines[i]);
        //            lstMachine.Add(operation);
        //        }
        //    } 

        //    return lstMachine.ToArray();
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spareYard"></param>
        /// <returns></returns>
        public static CT_Yard[] GetYards()
        {
            List<CT_Yard> yards = new List<CT_Yard>(); 
            CT_Yard general_yard = new CT_Yard(99, "General", "General", 0, 0, 0, 0, 99);
            yards.Add(general_yard);
            return yards.ToArray();
        }

        #endregion

        #region Close command
        protected override bool CanCloseExecute(object parameter)
        {
            return this._can_close;
        }
        #endregion

        #region task logical
        private Task runningTask;
        private CancellationTokenSource cancelTask;

        //private void DoProcess(CancellationToken token)
        //{
        //    Thread.Sleep(100);

        //    try
        //    {
        //        int i;
        //        bool[,] status;
        //        while (true)
        //        {
        //            if (this._machines != null)
        //            {
        //                for (i = 0; i < this._machines.Length; i++)
        //                {
        //                    this._machines[i].DoProcess();
        //                }
        //            }

        //            if (this._zones != null)
        //            {
        //                for (i = 0; i < this._zones.Length; i++)
        //                {
        //                    this._zones[i].DoProcess();
        //                }
        //            }

        //            if (this._positions != null)
        //            {
        //                for (i = 0; i < this._positions.Length; i++)
        //                {
        //                    this._positions[i].DoProcess();
        //                }
        //            }

        //            if (this._requests != null)
        //            {
        //                for (i = 0; i < this._requests.Length; i++)
        //                {
        //                    this._requests[i].DoProcess();
        //                }
        //            }

        //            if (this._request_interlocks != null)
        //            {
        //                for (i = 0; i < this._request_interlocks.Length; i++)
        //                {
        //                    this._request_interlocks[i].DoProcess();
        //                }
        //            }

        //            if (this._locations != null)
        //            {
        //                for (int j = 0; j < this._yards.Length; j++)
        //                {
        //                    if (HSM.Tracking.Server.Common.Handlers.LocationHandler.GetAllStatuses(this._yards[j], out status))
        //                    {
        //                        for (i = 0; i < this._locations.Length; i++)
        //                        {
        //                            if (this._locations[i].Properties.Row != null && this._locations[i].Properties.Col != null && this._locations[i].Properties.Yard.PlcValue == this._yards[j].PlcValue)
        //                            {
        //                                this.Locations[i].Enabled = status[this._locations[i].Properties.Row.Value, this._locations[i].Properties.Col.Value];
        //                            }
        //                            foreach (var item in this._target_controller.AllPositions)
        //                            {
        //                                if(this.Locations[i].Properties.Description == item.Position.Alias)
        //                                {
        //                                    this.Locations[i].IsTarget = item.IsTarget;
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }

        //            if (this._estop_controller != null)
        //            {
        //                this._estop_controller.DoProcess();
        //            }

        //            this._target_controller.DoProcess();

        //            Thread.Sleep(500);

        //            if (token.IsCancellationRequested)
        //            {
        //                break;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        RdTrace.Exception(ex);
        //    }
        //    finally
        //    {
        //        if (!token.IsCancellationRequested)
        //        {
        //            this.runningTask = new Task(() => DoProcess(token), token);
        //            this.runningTask.Start();
        //        }
        //    }
        //}
        #endregion

        #region Destructor
        /// <summary>
        /// Dispose a instance of the <see cref="vmMainCommon"/> class.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose a instance of the <see cref="vmMainCommon"/> class.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (this.cancelTask != null)
                {
                    this.cancelTask.Cancel();
                }

                if (this.runningTask != null)
                {
                    this.runningTask.Wait(500);
                    this.runningTask = null;
                }

                if (this._layout_controller != null)
                {
                    this._layout_controller.EndLoading();
                }

                //if (this._alarm_controller != null)
                //{
                //    this._alarm_controller.Dispose();
                //}
            }
            catch (Exception ex)
            {
                RdTrace.Exception(ex);
            }
        }

        /// <summary>
        /// Dispose a instance of the <see cref="vmMainCommon"/> class.
        /// </summary>
        ~vmMainCommon()
        {
            Dispose(false);
        }
        #endregion
    }
}
