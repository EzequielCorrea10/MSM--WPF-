using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.IO;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MSM.Utility.Common
{
    using Janus.Rodeo.Windows.Library.Rd_Log;
    using Janus.Rodeo.Windows.Library.Rd_Common;
    using MSM.Utility.Common.Structures;
    using MSM.Utility.Common.Constants;

    /// <summary>
    /// Handler of Message Queue
    /// </summary>
    public abstract class MsgMQReceiver : IDisposable
    {
        #region private attributes
        /// <summary>
        /// use to lock the logical
        /// </summary>
        private readonly object lockInstance = new object();

        /// <summary>
        /// process task
        /// </summary>
        private Task _processTask;

        /// <summary>
        /// cancel task
        /// </summary>
        private CancellationTokenSource _cancelTask;

        /// <summary>
        /// Get read queue name
        /// </summary>
        private string _read_queue_name;

        /// <summary>
        /// size of header
        /// </summary>
        private int _sizeofHeader;

        /// <summary>
        /// source
        /// </summary>
        private byte _destination;

        /// <summary>
        /// type
        /// </summary>
        private Type _msg_type;
 
        #endregion

        #region public properties
        /// <summary>
        /// QUEUE_NAME
        /// </summary>
        public string QUEUE_NAME
        {
            get { return this._read_queue_name; }
        }
        #endregion

        #region public event
        /// <summary>
        /// Event when mq changed status
        /// </summary>
        //public event EventHandler<OnMQStatusChangedventArgs> OnStatusChanged;
        #endregion

        #region public attribute
        /// <summary>
        /// Get the indication if the thread is running
        /// </summary>
        public bool Running
        {
            get
            {
                if (this._processTask == null)
                {
                    return false;
                }
                return this._processTask.Status == TaskStatus.Running || this._processTask.Status == TaskStatus.WaitingToRun;
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MsgMQReceiver"/> class.
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="read_queue_name"></param>
        public MsgMQReceiver(byte destination, string read_queue_name)
        {
            this._destination = destination;
            this._read_queue_name = read_queue_name;
            this._msg_type = typeof(byte[]); 

            //this._sizeofHeader = Marshal.SizeOf(typeof(MsgHeader));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MsgMQReceiver"/> class.
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="read_queue_name"></param>
        /// <param name="msg_type"></param>
        public MsgMQReceiver(byte destination, string read_queue_name, Type msg_type)
        {
            this._destination = destination;
            this._read_queue_name = read_queue_name;
            this._msg_type = msg_type; 
        }
        #endregion

        #region public methods
        /// <summary>
        /// Start
        /// </summary>
        /// <returns></returns>
        public void Start()
        {
            lock (this.lockInstance)
            {
                if (!this.Running)
                {
                    this.ValidationFunctions();

                    _cancelTask = new CancellationTokenSource();

                    _processTask = new Task(() => DoProcess(_cancelTask.Token), _cancelTask.Token);
                    _processTask.ContinueWith(CloseProcess);
                    _processTask.Start();
                }
            }
        }

        /// <summary>
        /// StartAsync
        /// </summary>
        /// <returns></returns>
        public void StartAsync()
        {
            lock (this.lockInstance)
            {
                if (!this.Running)
                {
                    this.ValidationFunctions();

                    _cancelTask = new CancellationTokenSource();

                    _processTask = new Task(() => DoProcessAsync(_cancelTask.Token), _cancelTask.Token);
                    _processTask.ContinueWith(CloseProcessAsync);
                    _processTask.Start();
                }
            }
        }

        /// <summary>
        /// Stop
        /// </summary>
        /// <returns></returns>
        public void Stop()
        {
            lock (this.lockInstance)
            {
                if (this.Running && _cancelTask != null)
                {
                    _cancelTask.Cancel();
                }
            }
        }
        #endregion

        #region protected event
        /// <summary>
        /// Launch Event
        /// </summary>
        /// <param name="method"></param>
        /// <param name="arg"></param>
        protected void LaunchEvent<T>(EventHandler<T> method, T arg) where T : EventArgs
        {
            if (method != null)
            {
                method(this, arg);
            }
        }
        #endregion

        #region abstract methods
        /// <summary>
        /// Validate the functions where the data will be send to
        /// </summary>
        protected abstract void ValidationFunctions();

        /// <summary>
        /// process the message received and return a response
        /// </summary>
        /// <param name="source"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        protected abstract void ProcessMessage(byte source, byte[] message);
        #endregion

        #region task methods
        /// <summary>
        /// Activation Process
        /// </summary>
        /// <param name="token"></param>
        private void DoProcess(CancellationToken token)
        {
            MessageQueue mqRead = new MessageQueue(this._read_queue_name, QueueAccessMode.Receive);
            if (mqRead == null)
            {
                RdTrace.Debug("MsgQueue {0} doesn't exist", this._read_queue_name);

                //LaunchEvent<OnMQStatusChangedventArgs>(this.OnStatusChanged, new OnMQStatusChangedventArgs(DateTimeOffset.Now, this._read_queue_name, false, false));
                return;
            }
            //mqRead.Formatter = new XmlMessageFormatter(new Type[] { this._msg_type });
            mqRead.Formatter = new BinaryMessageFormatter();
            //mqRead.Peek();

            try
            {
                int count_failure = 0;
                bool _CanRead = false;
                TimeSpan timeSpan = new TimeSpan(0, 0, 10);

                while (true)
                {
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }

                    if (_CanRead == false)
                    {
                        if (count_failure >= 25)
                        {
                            try
                            {
                                mqRead.Close();
                            }
                            catch { }

                            mqRead = new MessageQueue(this._read_queue_name, QueueAccessMode.Receive);
                            if (mqRead == null)
                            {
                                RdTrace.Debug("MsgQueue {0} doesn't exist", this._read_queue_name);

                                //LaunchEvent<OnMQStatusChangedventArgs>(this.OnStatusChanged, new OnMQStatusChangedventArgs(DateTimeOffset.Now, this._read_queue_name, false, false));
                                return;
                            }
                            //mqRead.Formatter = new XmlMessageFormatter(new Type[] { this._msg_type });
                            mqRead.Formatter = new BinaryMessageFormatter();
                            //mqRead.Peek();

                            count_failure = 0;
                        }

                        if (mqRead.CanRead != _CanRead)
                        {
                            //LaunchEvent<OnMQStatusChangedventArgs>(this.OnStatusChanged, new OnMQStatusChangedventArgs(DateTimeOffset.Now, this._read_queue_name, mqRead.CanRead, mqRead.CanWrite));
                        }
                        _CanRead = mqRead.CanRead;

                        count_failure++;
                        Thread.Sleep(100);
                        continue;
                    }

                    try
                    {
                        Message msg = mqRead.Receive(timeSpan, MessageQueueTransactionType.Automatic);
                        if (msg == null || msg.MessageType != System.Messaging.MessageType.Normal)
                        {
                            continue;
                        }
 
                        if (msg.Body != null && msg.Body.GetType() == this._msg_type)
                        {
                            this.Receive((byte[])msg.Body);
                        }
                        else
                        {
                            RdTrace.Message("Error receiving data from read queue {0}", (msg.Body != null) ? msg.Body : string.Empty);
                        }
                        
                
                    }
                    catch (MessageQueueException ex)
                    {
                        if (ex.MessageQueueErrorCode != MessageQueueErrorCode.IOTimeout)
                        {
                            if (count_failure >= 50)
                            {
                                try
                                {
                                    mqRead.Close();
                                }
                                catch { }

                                mqRead = new MessageQueue(this._read_queue_name, QueueAccessMode.Receive);
                                if (mqRead == null)
                                {
                                    RdTrace.Debug("MsgQueue {0} doesn't exist", this._read_queue_name);

                                    //LaunchEvent<OnMQStatusChangedventArgs>(this.OnStatusChanged, new OnMQStatusChangedventArgs(DateTimeOffset.Now, this._read_queue_name, false, false));
                                    return;
                                }
                                //mqRead.Formatter = new XmlMessageFormatter(new Type[] { this._msg_type });
                                mqRead.Formatter = new BinaryMessageFormatter();
                                //mqRead.Peek();

                                count_failure = 0;
                            }

                            if (mqRead.CanRead != _CanRead)
                            {
                                //LaunchEvent<OnMQStatusChangedventArgs>(this.OnStatusChanged, new OnMQStatusChangedventArgs(DateTimeOffset.Now, this._read_queue_name, mqRead.CanRead, mqRead.CanWrite));
                            }
                            _CanRead = mqRead.CanRead;

                            count_failure++;
                            Thread.Sleep(100);
                        }
                        else
                        {
                            Thread.Sleep(500);
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
                try
                {
                    mqRead.Close();
                }
                catch { }
            }
        }

        /// <summary>
        /// Activation Process
        /// </summary>
        /// <param name="token"></param>
        private void DoProcessAsync(CancellationToken token)
        {
            //WrapMessageQueue mqRead = new WrapMessageQueue(this._read_queue_name, this._msg_type);

            //try
            //{
            //    TimeSpan timeSpan = new TimeSpan(0, 0, 2);

            //    while (true)
            //    {
            //        if (token.IsCancellationRequested)
            //        {
            //            break;
            //        }

            //        Message message;
            //        if (!mqRead.Receive(timeSpan, out message))
            //        {
            //            continue;
            //        }

            //        try
            //        {
                      
            //            this.Receive((byte[])message.Body);
                       
            //        }
            //        catch (Exception ex)
            //        {
            //            RdTrace.Exception(ex);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    RdTrace.Exception(ex);
            //}
            //finally
            //{
            //    try
            //    {
            //        mqRead.Close();
            //    }
            //    catch { }
            //}
        }

        /// <summary>
        /// Process the message sent by L3
        /// </summary>
        /// <param name="workerSocket"></param>
        private void Receive(byte[] request)
        {
            if (request.Length > this._sizeofHeader)
            {
                byte[] message = new byte[request.Length];
                Buffer.BlockCopy(request, 0, message, 0, message.Length);

                this.ProcessMessage(MsgConstant.MSG_SOURCE_3RDPARTY, message);
            }
        }

        ///// <summary>
        ///// Process the message sent by L3
        ///// </summary>
        ///// <param name="workerSocket"></param>
        //private void ReceiveWithHeader(byte[] request)
        //{
        //    if (request.Length > this._sizeofHeader)
        //    {
        //        MsgHeader headerResp = (MsgHeader)CommonFunctions.UnManageDeserialize(request, 0, typeof(MsgHeader));
        //        if (headerResp.version == MsgConstant.MSG_VERSION)
        //        {
        //            byte[] message = new byte[request.Length - this._sizeofHeader];
        //            Buffer.BlockCopy(request, this._sizeofHeader, message, 0, message.Length);

        //            this.ProcessMessage(headerResp.source, message);
        //        }
        //    }
        //}

        /// <summary>
        /// CloseProcess
        /// </summary>
        /// <param name="task"></param>
        private void CloseProcess(Task task)
        {
            try
            {
                Thread.Sleep(1000);

                if (!_cancelTask.IsCancellationRequested)
                {
                    _processTask = new Task(() => DoProcess(_cancelTask.Token), _cancelTask.Token);
                    _processTask.ContinueWith(CloseProcess);
                    _processTask.Start();
                }
            }
            catch (Exception ex)
            {
                RdTrace.Exception(ex);
            }
        }

        /// <summary>
        /// CloseProcess
        /// </summary>
        /// <param name="task"></param>
        private void CloseProcessAsync(Task task)
        {
            try
            {
                Thread.Sleep(1000);

                if (!_cancelTask.IsCancellationRequested)
                {
                    _processTask = new Task(() => DoProcessAsync(_cancelTask.Token), _cancelTask.Token);
                    _processTask.ContinueWith(CloseProcessAsync);
                    _processTask.Start();
                }
            }
            catch (Exception ex)
            {
                RdTrace.Exception(ex);
            }
        }
        #endregion

        #region Destructor
        /// <summary>
        /// Dispose a instance of the <see cref="MsgMQReceiver"/> class.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose a instance of the <see cref="MsgMQReceiver"/> class.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    lock (this.lockInstance)
                    {
                        if (this.Running)
                        {
                            this.Stop();
                        }
                    }

                    RdTrace.Message("MsgMQReceiver was disposed");
                }
            }
            catch (Exception ex)
            {
                RdTrace.Exception(ex);
            }
        }

        /// <summary>
        /// Dispose a instance of the <see cref="MsgMQReceiver"/> class.
        /// </summary>
        ~MsgMQReceiver()
        {
            Dispose(true);
        }
        #endregion
    }
}
