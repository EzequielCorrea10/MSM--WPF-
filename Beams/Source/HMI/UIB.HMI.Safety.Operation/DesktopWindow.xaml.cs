using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HCM.HMI.Safety.Operation
{
    using Janus.Rodeo.Windows.Library.Rd_Log;
    using Janus.Rodeo.Windows.Library.UI.Common;
    using Janus.Rodeo.Windows.Library.UI.Controls;

    using HCM.Utility.Configuration;
    using HCM.HMI.Safety.Operation.Enumerations;
    using HCM.HMI.Safety.Operation.Views;
    using HCM.HMI.Safety.Operation.ViewModels;
    using HCM.HMI.Safety.Operation.Views.Windows;

    /// <summary>
    /// Interaction logic for DesktopWindow.xaml
    /// </summary>
    public partial class DesktopWindow : jWindowBase
    {
        #region private attributes
        private vmMainDesktop controller;
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DesktopWindow"/> class.
        /// </summary>
        public DesktopWindow(bool can_close, ScreenPages page)
            : base()
        {
            InitializeComponent();

            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                this.controller = new vmMainDesktop(can_close);
                //this.controller.ActivePage = page;

                //this.Loaded += DesktopWindow_Loaded;
                //this.ContentRendered += DesktopWindow_ContentRendered;
                //this.Closing += DesktopWindow_Closing;

                this.DataContext = this.controller;
            }
        }

        public override void Exit()
        { }
        #endregion

        #region private events
        private void DesktopWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //this.controller.Children.Add(this.controller.LayoutController);
            //this.controller.Children.Add(this.controller.ZoneController);
            //this.controller.Children.Add(this.controller.RequestController);
            //this.controller.Children.Add(this.controller.InterlockController);
            //this.controller.Children.Add(this.controller.AlarmController);
            //this.controller.Children.Add(this.controller.EStopController);
            //this.controller.Children.Add(this.controller.PositionController);
            //this.controller.Children.Add(this.controller.TargetController);

            //foreach (vmMachine machine in this.controller.Machines)
            //{
            //    machine.TODetailsAction = new Action<vmMachine>(this.OpenTOWindow);
            //    this.controller.Children.Add(machine);
            //}

            //foreach (vmZone zone in this.controller.Zones)
            //{
            //    zone.ZoneDetailsAction = new Action<vmZone>(this.OpenZoneWindow);
            //    zone.EditZoneAction = new Action<vmZone>(this.OpenEditZoneWindow);

            //    this.controller.Children.Add(zone);

            //    if (zone.Interlocks != null)
            //    {
            //        zone.InterlocksAction = new Action<vmZoneInterlocks>(this.OpenZoneInterlockWindow);
            //        this.controller.Children.Add(zone.Interlocks);
            //    }
            //}

            //foreach (vmPosition position in this.controller.Positions)
            //{
            //    position.PositionDetailsAction = new Action<vmPosition>(this.OpenPositionWindow);
            //    position.EditPositionAction = new Action<vmPosition>(this.OpenEditPositionWindow);
            //    this.controller.Children.Add(position);
            //}

            //foreach (vmRequest request in this.controller.Requests)
            //{
            //    request.RequestDetailsAction = new Action<vmRequest>(this.OpenRequestWindow);
            //    this.controller.Children.Add(request);

            //    foreach (vmTypeSignals signal in request.TypeSignals)
            //    {
            //        this.controller.Children.Add(signal);
            //    }

            //    if (request.Interlocks != null)
            //    {
            //        request.InterlocksAction = new Action<vmRequestInterlocks>(this.OpenRequestInterlockWindow);
            //        this.controller.Children.Add(request.Interlocks);
            //    }
            //}

            //foreach (vmLocation location in this.controller.Locations)
            //{
            //    location.LocationDetailsAction = new Action<vmLocation>(this.OpenLocationWindow);
            //    this.controller.Children.Add(location);
            //}

            //this.controller.LayoutController.CreateTemporaryZoneAction = new Func<vmZoneTemporaryDrawing, bool>(this.OpenCreateTemporaryZoneWindow);
            //this.controller.EStopController.EquipmentEStopAction = new Action(this.OpenEquipmentEStopWindow);
            //this.controller.EStopController.PanelsEStopAction = new Action(this.OpenPanelsEStopWindow);
            //this.controller.EStopController.FailuresEStopAction = new Action(this.OpenFailuresEStopWindow);
            //this.controller.EStopController.EstopGroupsAction = new Action(this.OpenEStopGroupsWindow);
        }

        //private void DesktopWindow_ContentRendered(object sender, EventArgs e)
        //{
        //    if (tabLayout.IsSelected)
        //    {
        //        this.controller.LayoutController.EndLoading();
        //    }
        //    else
        //    {
        //        this.tabControl.SelectionChanged += TabControl_SelectionChanged;
        //    }
        //}

        //private void DesktopWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    this.controller.Dispose();

        //    Environment.Exit(0);
        //}

        //private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (tabLayout.IsSelected)
        //    {
        //        try
        //        {
        //            this.controller.LayoutController.EndLoading();

        //            this.tabControl.SelectionChanged -= TabControl_SelectionChanged;
        //        }
        //        catch { }
        //    }
        //}
        #endregion

        #region private methods
        //private void OpenTOWindow(vmMachine crane)
        //{
        //    winTOViewer toViewer = new winTOViewer(crane);
        //    toViewer.Owner = this;
        //    toViewer.ShowDialog();
        //}

        //private void OpenZoneWindow(vmZone zone)
        //{
        //    if (zone.Properties.Type == HCM.Safety.Server.Common.Enumerations.ZoneTypes.Permanent ||
        //        zone.Properties.Type == HCM.Safety.Server.Common.Enumerations.ZoneTypes.Fly)
        //    {
        //        winPZoneDetails zoneDetail = new winPZoneDetails(zone);
        //        zoneDetail.Owner = this;
        //        zoneDetail.Focus();
        //        zoneDetail.ShowDialog();
        //    }
        //    else if (zone.Properties.Type == HCM.Safety.Server.Common.Enumerations.ZoneTypes.Dead)
        //    {
        //        winDZoneDetails zoneDetail = new winDZoneDetails(zone);
        //        zoneDetail.Owner = this;
        //        zoneDetail.ShowDialog();
        //    }
        //    else if (zone.Properties.Type == HCM.Safety.Server.Common.Enumerations.ZoneTypes.Temporary)
        //    {
        //        winTZoneDetails zoneDetail = new winTZoneDetails(zone);
        //        zoneDetail.Owner = this;
        //        zoneDetail.ShowDialog();
        //    }
        //}

        //private void OpenEditZoneWindow(vmZone zone)
        //{
        //    winEditZone editZone = new winEditZone(zone, this.controller.Machines);
        //    editZone.Owner = this;
        //    editZone.ShowDialog();
        //}

        //private void OpenPositionWindow(vmPosition position)
        //{
        //    winPositionDetails editPos = new winPositionDetails(position);
        //    editPos.Owner = this;
        //    editPos.ShowDialog();
        //}

        //private void OpenEditPositionWindow(vmPosition position)
        //{

        //    winEditPosition editPos = new winEditPosition(position, this.controller.Machines.Where(m=>m.Properties.Type.Reference == Tracking.Server.Common.Enumerations.MachineTypes.SemiCrane).ToList());
        //    editPos.Owner = this;
        //    editPos.ShowDialog();
        //}

        //private void OpenZoneInterlockWindow(vmZoneInterlocks interlocks)
        //{
        //    winZoneInterlocks zoneInterlock = new winZoneInterlocks(interlocks);
        //    zoneInterlock.Owner = this;
        //    zoneInterlock.ShowDialog();
        //}

        //private void OpenRequestWindow(vmRequest request)
        //{
        //    winRequestDetails requestDetail = new winRequestDetails(request);
        //    requestDetail.Owner = this;
        //    requestDetail.ShowDialog();
        //}

        //private void OpenRequestInterlockWindow(vmRequestInterlocks interlocks)
        //{
        //    winRequestInterlocks requestInterlock = new winRequestInterlocks(interlocks);
        //    requestInterlock.Owner = this;
        //    requestInterlock.ShowDialog();
        //}

        //private void OpenLocationWindow(vmLocation location)
        //{
        //    winLocationDetails locationDetail = new winLocationDetails(location);
        //    locationDetail.Owner = this;
        //    locationDetail.ShowDialog();
        //}

        //private bool OpenCreateTemporaryZoneWindow(vmZoneTemporaryDrawing temporary_drawing)
        //{
        //    bool result = false;
        //    winEditZone editZone = new winEditZone(temporary_drawing, this.controller.Zones, this.controller.Machines);
        //    editZone.Owner = this;
        //    editZone.Closed += ((s, ev) =>
        //    {
        //        if (((Window)s).DialogResult.HasValue)
        //        {
        //            result = ((Window)s).DialogResult.Value;
        //        }
        //    });
        //    editZone.ShowDialog();
        //    return result;
        //}

        //private void OpenEquipmentEStopWindow()
        //{
        //    winEStopDetails generalDetails = new winEStopDetails(this.controller.EStopController);
        //    generalDetails.Owner = this;
        //    generalDetails.ShowDialog();
        //}

        //private void OpenPanelsEStopWindow()
        //{
        //    winPanelsDetails generalDetails = new winPanelsDetails(this.controller.EStopController);
        //    generalDetails.Owner = this;
        //    generalDetails.ShowDialog();
        //}

        //private void OpenFailuresEStopWindow()
        //{
        //    winFailuresDetails generalDetails = new winFailuresDetails(this.controller.EStopController);
        //    generalDetails.Owner = this;
        //    generalDetails.ShowDialog();
        //}
        #endregion
    }
}
