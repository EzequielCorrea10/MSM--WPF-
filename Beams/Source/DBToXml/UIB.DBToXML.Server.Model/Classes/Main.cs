using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSM.DBToXML.Server.Model
{
    using Janus.Rodeo.Windows.Library.Rd_Log;
    using Janus.Rodeo.Windows.Library.UI.Common;

    using MSM.DBToXML.Server.Model.Controllers;
    using MSM.Utility.Common;
    using MSM.Utility.Configuration;

    /// <summary>
    /// Class to handle the DBTOXml
    /// </summary>
    public class Main : MainBase
    {
        #region handlers attributes
        /// <summary>
        /// handler of the traffic
        /// </summary>
        internal NetworkControl _network;
        #endregion

        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
            : base()
        { }
        #endregion

        #region protected methods
        /// <summary>
        /// Copy the args into the internal variable
        /// </summary>
        protected override void CopyArgs()
        { }

        /// <summary>
        /// Make the validations and Load the default data
        /// </summary>
        /// <remarks>Exception based validation</remarks>
        protected override void ValidationAndLoadParameter()
        { }

        /// <summary>
        /// Initialize the application
        /// </summary>
        protected override void DoInitialize()
        {
            this.LoadCatalogs();

            this.InitializeHandlers();
        }

        /// <summary>
        /// UnInitialize the application
        /// </summary>
        protected override void DoUnInitialize()
        {
            this.UnitializeHandlers();
        }
        #endregion

        #region private methods
        /// <summary>
        /// Load all catalogs of the system
        /// </summary>
        private void LoadCatalogs()
        {
            Handlers.DBAccess.LoadCatalogs();
        }

        /// <summary>
        /// Initialize Handlers
        /// </summary>
        private void InitializeHandlers()
        {
            this._network = new NetworkControl();
            this._network.OnCycleExecuted += OnCycleExecuted;
            this._network.Start();
        }

        /// <summary>
        /// Uninitialize Handlers
        /// </summary>
        private void UnitializeHandlers()
        {
            if (this._network != null)
            {
                try
                {
                    this._network.OnCycleExecuted -= OnCycleExecuted;
                }
                catch { }

                this._network.Stop();
                this._network.Dispose();
            }
            this._network = null;
        }
        #endregion

        #region private events
        /// <summary>
        /// OnCycleExecuted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCycleExecuted(object sender, OnCycleExecutedEventArgs e)
        {
            this.SendNotification(string.Format("Cycle executed"));
        }
        #endregion
    }
}
