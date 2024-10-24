using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSM.DBToXML.Server.Model.Controllers
{
    using Janus.Rodeo.Windows.Library.Rd_Log;
    using Janus.Rodeo.Windows.Library.Rd_Common;

    using MSM.Utility.Common;
    using MSM.Utility.Common.Exceptions;
    using MSM.Utility.Configuration;
    using MSM.DBToXML.Server.Model.Enumerations;
    using MSM.Sys.Server.Common;

    /// <summary>
    /// Control of the Network
    /// </summary>
    internal class NetworkControl : IDisposable
    {
        #region logical attributes
        /// <summary>
        /// use to lock the logical
        /// </summary>
        private readonly object _lockInstance = new object();

        /// <summary>
        /// nunning task
        /// </summary>
        private Task _runningTask;

        /// <summary>
        /// cancel task
        /// </summary>
        private CancellationTokenSource _cancelTask;
        #endregion

        #region private attribute
        /// <summary>
        /// Last Error
        /// </summary>
        private ControlErrors _last_control_error;
        #endregion

        #region public properties
        /// <summary>
        /// Indication the Crane is Running
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
        #endregion

        #region public event
        /// <summary>
        /// Event when cycle has been executed
        /// </summary>
        public event EventHandler<OnCycleExecutedEventArgs> OnCycleExecuted;
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a Network
        /// </summary>
        public NetworkControl()
        { }
        #endregion

        #region public methods
        /// <summary>
        /// Start the Crane
        /// </summary>
        public ControlErrors Start()
        {
            if (!this.ThreadRunning)
            {
                lock (_lockInstance)
                {
                    if (!this.ThreadRunning)
                    {
                        try
                        {
                            if (this._cancelTask != null)
                            {
                                this._cancelTask.Cancel();
                            }
                            this._cancelTask = new CancellationTokenSource();

                            this._runningTask = new Task(() => DoProcess(this._cancelTask.Token), this._cancelTask.Token);
                            this._runningTask.Start();
                            Thread.Sleep(250);

                            this._last_control_error = ControlErrors.Success;
                        }
                        catch (ControlException<ControlErrors> ex)
                        {
                            this._last_control_error = ex.ErrorCode;
                            RdTrace.Exception(ex);
                        }
                        catch (Exception ex)
                        {
                            this._last_control_error = ControlErrors.Unknown;
                            RdTrace.Exception(ex);
                        }
                    }
                }
            }

            return this._last_control_error;
        }

        /// <summary>
        /// Start the Crane
        /// </summary>
        public ControlErrors Stop()
        {
            if (this.ThreadRunning)
            {
                lock (_lockInstance)
                {
                    if (this.ThreadRunning)
                    {
                        try
                        {
                            this._cancelTask.Cancel();

                            if (this._runningTask.Status == TaskStatus.Running)
                                this._runningTask.Wait();
                        }
                        catch (ControlException<ControlErrors> ex)
                        {
                            this._last_control_error = ex.ErrorCode;
                            RdTrace.Exception(ex);
                        }
                        catch (Exception ex)
                        {
                            this._last_control_error = ControlErrors.Unknown;
                            RdTrace.Exception(ex);
                        }
                    }
                }
            }

            return this._last_control_error;
        }
        #endregion

        #region process methods
        /// <summary>
        /// Activation Process
        /// </summary>
        /// <param name="token"></param>
        private void DoProcess(CancellationToken token)
        {
            try
            {
                double count = 900;
                while (true)
                {
                    if (count >= 900)
                    {
                        Handlers.DBAccess.GenerateAllTables();

                        Handlers.DBAccess.TransferAllTables(token);

                        if (this.OnCycleExecuted != null)
                        {
                            this.OnCycleExecuted(this, new OnCycleExecutedEventArgs(DateTimeOffset.Now));
                        }

                        count = 1;
                    }
                    count++;

                    Thread.Sleep(1000);

                    if (token.IsCancellationRequested)
                    {
                        break;
                    }
                }
            }
            catch (ControlException<ControlErrors> ex)
            {
                this._last_control_error = ex.ErrorCode;
                RdTrace.Exception(ex);
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

        #region Destructor
        /// <summary>
        /// Dispose a instance of the <see cref="NetworkControl"/> class.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose a instance of the <see cref="NetworkControl"/> class.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            try
            {
                this.Stop();
            }
            catch (Exception ex)
            {
                RdTrace.Exception(ex);
            }
        }

        /// <summary>
        /// Dispose a instance of the <see cref="NetworkControl"/> class.
        /// </summary>
        ~NetworkControl()
        {
            Dispose(false);
        }
        #endregion
    }
}
