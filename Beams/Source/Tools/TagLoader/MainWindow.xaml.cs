using TagLoader.Clases;
using TagLoader.ViewModels;
//using CPL.Utility.Configuration;
//using CPL.Utility.Controls;
using Janus.Rodeo.Windows.Library.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TagLoader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : jWindowBase
    {
        public MainWindow()
            : base()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        #region Tags
        private void btnGetTags_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel vm = (MainViewModel)this.DataContext;
            vm.GetTags();
        }

        private void btnFilters_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel vm = (MainViewModel)this.DataContext;
            vm.GetTags();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel vm = (MainViewModel)this.DataContext;
            vm.UpdateTag();
        }

        private void btnUpdateAll_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel vm = (MainViewModel)this.DataContext;

            if (grdItems.SelectedItems.Count > 0)
            {
                foreach (var item in grdItems.SelectedItems)
                {
                    try
                    {
                        RodeoTag tag = (RodeoTag)item;
                        vm.UpdateTag(tag);
                    }
                    catch (Exception ex)
                    {

                    }
                }

                vm.GetTags();
                vm.ValueAsText = false;
            }
        }

        private void btnSendCommand_Click(object sender, RoutedEventArgs e)
        {
            //MainViewModel vm = (MainViewModel)this.DataContext;
            //if (vm.CurrentTag != null)
            //{
            //    winCommandSender win = new winCommandSender(vm.CurrentTag);
            //    win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //    win.ShowDialog();
            //}
        }

        private void btnCraneSimulator_Click(object sender, RoutedEventArgs e)
        {
            //winCrane win = new winCrane();
            //win.DataContext = new CraneViewModel();
            //win.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            //win.Show();
        }

        private void btnLocationSimulator_Click(object sender, RoutedEventArgs e)
        {
            //winLocation win = new winLocation();
            //win.DataContext = new LocationViewModel();
            //win.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            //win.Show();
        }

        private void btnHookSimulator_Click(object sender, RoutedEventArgs e)
        {
            //winHook win = new winHook();
            //win.DataContext = new HookViewModel();
            //win.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            //win.Show();
        }

        private void btnEnableAll_Click(object sender, RoutedEventArgs e)
        {
            //MainViewModel vm = (MainViewModel)this.DataContext;
            //vm.SetEnableAll();
        }

        private void btnEmergencyLoad(object sender, RoutedEventArgs e)
        {
            MainViewModel vm = (MainViewModel)this.DataContext;
            vm.EmergencyLoad();

            //if (!string.IsNullOrEmpty(msg))
            //{
            //    MessageBox.Show(msg ,"Emergency Load", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //else
            //{
            //    MessageBox.Show("No info available", "Emergency Load", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
        }

        #endregion

        #region Alarms
        private void btnGetAlarms_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel vm = (MainViewModel)this.DataContext;
            vm.GetAlarms();
        }

        private void btnUpdateAlarm_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel vm = (MainViewModel)this.DataContext;
            vm.UpdateAlarm();
        }

        private void btnLoadL2Alarms_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeactive_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel vm = (MainViewModel)this.DataContext;
            vm.DeactiveAlarm();
        }

        private void btnActive_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel vm = (MainViewModel)this.DataContext;
            vm.ActiveAlarm();
        }


        #endregion

        #region Users
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel vm = (MainViewModel)this.DataContext;
            vm.Login();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel vm = (MainViewModel)this.DataContext;
            vm.Logout();
        }

        private void btnGetAllSessions_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel vm = (MainViewModel)this.DataContext;
            vm.GetAllSessions();
        }

        #endregion

    }
}
