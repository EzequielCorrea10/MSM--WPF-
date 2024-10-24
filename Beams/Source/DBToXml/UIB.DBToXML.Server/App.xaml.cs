using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace MSM.DBToXML.Server
{
    using Janus.Rodeo.Windows.Library.Rd_Log;
    using Janus.Rodeo.Windows.Library.UI.Common;

    using MSM.Utility.Configuration;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region private methods
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            RodeoHandler.RodeoSector = Configurations.General.RodeoSector;
            RodeoHandler.ClientName = Configurations.General.ClientName;
            RodeoHandler.TestMode = Configurations.General.TestMode;

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        { }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                RdTrace.Exception(e.Exception);
            }
            catch { }

            // Prevent default unhandled exception processing
            e.Handled = true;
        }
        #endregion
    }
}
