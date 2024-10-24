using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace MSM.DBToXML.Server
{
    using Janus.Rodeo.Windows.Library.Rd_Log;
    using Janus.Rodeo.Windows.Library.UI.Common;
    using Janus.Rodeo.Windows.Library.UI.Controls;

    using MSM.Utility.Configuration;
    using MSM.Utility.Common;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : jWindowBase
    {
        #region private attributes
        private ModelViewServer controller;
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
            : base(Configurations.General.MinimizeTimeout)
        {
            InitializeComponent();

            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                //this.controller = new ModelViewServer(new MSM.DBToXML.Server.Model.Main(), string.Format(MSM.Utility.Common.Constants.Applications.HB_DBTOXML_SRV, Configurations.General.RodeoSector));
                this.controller = new ModelViewServer(new MSM.DBToXML.Server.Model.Main(), Configurations.WDServer.GetHeartBeatByProcess(Process.GetCurrentProcess().ProcessName + ".exe", null));

                this.Loaded += MainWindow_Loaded;
                this.Closing += MainWindow_Closing;
            }
        }
        #endregion

        #region private events
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.SetLocation(MSM.Utility.Common.Constants.Applications.INDEX_DBTOXML_SRV);
            this.DataContext = this.controller;

            if (Properties.Settings.Default.AutoStart)
            {
                this.controller.StartCommand.Execute(null);
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.controller.Dispose();

            Environment.Exit(0);
        }
        #endregion
    }
}
