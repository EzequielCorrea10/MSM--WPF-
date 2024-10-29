using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace HSM.HMI.Safety.Operation
{
    using Janus.Rodeo.Windows.Library.Rd_Log;
    using Janus.Rodeo.Windows.Library.UI.Common;

    using HSM.Utility.Configuration;
    using HSM.HMI.Safety.Operation.Enumerations;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region private methods
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                RodeoHandler.RodeoSector = Configurations.General.RodeoSector;
                RodeoHandler.ClientName = Configurations.General.ClientName;
                RodeoHandler.TestMode = Configurations.General.TestMode;

                ScreenPages activeScreen = (ScreenPages)Enum.Parse(typeof(ScreenPages), HSM.HMI.Safety.Operation.Properties.Settings.Default.SCREEN.ToString());


                DesktopWindow window = new DesktopWindow(true, activeScreen);
                window.Show();
            }
            catch (Exception ex)
            {
                RdTrace.Exception(ex);

                Environment.Exit(-1);
            }
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
