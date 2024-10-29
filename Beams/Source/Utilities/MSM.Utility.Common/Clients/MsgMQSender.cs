using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;

namespace HSM.Utility.Common
{
    using Janus.Rodeo.Windows.Library.Rd_Log;
    using Janus.Rodeo.Windows.Library.Rd_Common;
    using System.IO;

    /// <summary>
    /// Sender of Message Queue
    /// </summary>
    public abstract class MsgMQSender
    {
        #region private attributes
        /// <summary>
        /// Used to Block the execution in Write and Read, only one at the time
        /// </summary>
        private Mutex mutex_sending_message = new Mutex();

        /// <summary>
        /// Get write queue name
        /// </summary>
        private string _write_queue_name;

        /// <summary>
        /// size of header
        /// </summary>
        private int sizeofHeader;

        /// <summary>
        /// source of the message
        /// </summary>
        private byte _source;

        /// <summary>
        /// type
        /// </summary>
        private Type _msg_type;

        /// <summary>
        /// _to_3rdparty
        /// </summary>
        private bool _to_3rdparty;
        #endregion

        #region public event
        /// <summary>
        /// Event when mq changed status
        /// </summary>
        //public event EventHandler<OnMQStatusChangedventArgs> OnStatusChanged;
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MsgMQSender"/> class.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="write_queue_name"></param>
        public MsgMQSender(byte source, string write_queue_name)
        {
            this._source = source;
            this._write_queue_name = write_queue_name;
            this._msg_type = typeof(byte[]);
            this._to_3rdparty = false;

            this.Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MsgMQSender"/> class.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="write_queue_name"></param>
        /// <param name="msg_type"></param>
        public MsgMQSender(byte source, string write_queue_name, Type msg_type)
        {
            this._source = source;
            this._write_queue_name = write_queue_name;
            this._msg_type = msg_type;
            this._to_3rdparty = true;

            this.Initialize();
        }

        public MsgMQSender()
        {
            this.Initialize();
        }
        #endregion

        #region private methods
        /// <summary>
        /// Initialize
        /// </summary>
        private void Initialize()
        {
            try
            {
                if (!MessageQueue.Exists(this._write_queue_name))
                {
                    MessageQueue queue = MessageQueue.Create(this._write_queue_name, false);

                    SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                    var acceveryone = everyone.Translate(typeof(NTAccount)) as NTAccount;
                    queue.SetPermissions(acceveryone.Value, MessageQueueAccessRights.FullControl, AccessControlEntryType.Allow);

                    SecurityIdentifier anonymous = new SecurityIdentifier(WellKnownSidType.AnonymousSid, null);
                    var accanonymous = anonymous.Translate(typeof(NTAccount)) as NTAccount;
                    queue.SetPermissions(accanonymous.Value, MessageQueueAccessRights.FullControl, AccessControlEntryType.Allow);
                }
            }
            catch (Exception ex)
            {
                if (this._write_queue_name.IndexOf("FormatName") < 0)
                {
                    RdTrace.Exception(ex);
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

        #region public methods
        /// <summary>
        /// Combine data in bytes
        /// </summary>
        /// <param name="header"></param>
        /// <param name="message"></param>
        protected byte[] CombineOnBytes<W, T>(W header, T message)
            where W : struct
            where T : struct
        {
            byte[] bufferHeader, bufferBody;

            bufferHeader = CommonFunctions.UnManageSerialize(header);
            bufferBody = CommonFunctions.UnManageSerialize(message);

            byte[] bufferRequest = new byte[bufferHeader.Length + bufferBody.Length];

            Buffer.BlockCopy(bufferHeader, 0, bufferRequest, 0, bufferHeader.Length);
            Buffer.BlockCopy(bufferBody, 0, bufferRequest, bufferHeader.Length, bufferBody.Length);

            return bufferRequest;
        }
        #endregion

        #region sending methods
        /// <summary>
        /// Send
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected bool Send(object message)
        {
            if (!this._to_3rdparty)
            {
                RdTrace.Debug("3rd Party -> Not implemented");
                return false;
            }
            else
            {
                RdTrace.Debug("I'm not a 3rd Party Writing {0}, MsgMQSender -> Send Commented");
                return this.SendRequest(message);
            }
        }

        /// <summary>
        /// Send request to the Server
        /// </summary>
        /// <param name="message"></param>
        private bool SendRequest(object message)
        {
            try
            {
                RdTrace.Debug("Entro a escribir en" + this._write_queue_name);

                mutex_sending_message.WaitOne();

                MessageQueue mqWrite = new MessageQueue(this._write_queue_name, QueueAccessMode.Send);

                if (mqWrite == null)
                {
                    RdTrace.Debug("MsgQueue {0} doesn't exist", this._write_queue_name);

                    //LaunchEvent<OnMQStatusChangedventArgs>(this.OnStatusChanged, new OnMQStatusChangedventArgs(DateTimeOffset.Now, this._write_queue_name, false, false));
                    return false;
                }

                mqWrite.Formatter = new BinaryMessageFormatter();

                if (!mqWrite.CanWrite)
                {
                    RdTrace.Debug("It is not able to write the message to queue {0}", this._write_queue_name);

                    //LaunchEvent<OnMQStatusChangedventArgs>(this.OnStatusChanged, new OnMQStatusChangedventArgs(DateTimeOffset.Now, this._write_queue_name, mqWrite.CanRead, mqWrite.CanWrite));
                    return false;
                }

                mqWrite.Send(message);
            }
            catch (Exception e)
            {
                RdTrace.Exception(e,"Fallo2");

                return false;
            }
            finally
            {
                mutex_sending_message.ReleaseMutex();
            }

            return true;
        }

        public bool SendResponse(string message)
        {
            try
            {
                mutex_sending_message.WaitOne();

                MessageQueue mqWrite = new MessageQueue(this._write_queue_name, QueueAccessMode.Send);
                if (mqWrite == null)
                {
                    RdTrace.Debug("MsgQueue {0} doesn't exist", this._write_queue_name);

                    //LaunchEvent<OnMQStatusChangedventArgs>(this.OnStatusChanged, new OnMQStatusChangedventArgs(DateTimeOffset.Now, this._write_queue_name, false, false));
                    return false;
                }

                //mqWrite.Formatter = new XmlMessageFormatter(new Type[] { this._msg_type });
                
                if (!mqWrite.CanWrite)
                {
                    RdTrace.Debug("It is not able to write the message to queue {0}", this._write_queue_name);

                    //LaunchEvent<OnMQStatusChangedventArgs>(this.OnStatusChanged, new OnMQStatusChangedventArgs(DateTimeOffset.Now, this._write_queue_name, mqWrite.CanRead, mqWrite.CanWrite));
                    return false;
                }

                Message _newQueue = new Message();
                Stream _tempStream = _newQueue.BodyStream;
                _tempStream.Write(ASCIIEncoding.ASCII.GetBytes(message), 0, message.Length);
                _newQueue.Formatter = new BinaryMessageFormatter();
                StreamReader reader = new StreamReader(_tempStream);

                mqWrite.Send(_newQueue);
                RdTrace.Debug("The message is -> " + message);
            }
            catch (Exception e)
            {
                RdTrace.Exception(e);

                return false;
            }
            finally
            {
                mutex_sending_message.ReleaseMutex();
            }

            return true;
        }

        public bool SimulateReceive(string message)
        {
            try
            {
                mutex_sending_message.WaitOne();

                this._write_queue_name = _write_queue_name.Replace("out", "in");

                MessageQueue mqWrite = new MessageQueue(this._write_queue_name, QueueAccessMode.Send);
                if (mqWrite == null)
                {
                    RdTrace.Debug("MsgQueue {0} doesn't exist", this._write_queue_name);

                    //LaunchEvent<OnMQStatusChangedventArgs>(this.OnStatusChanged, new OnMQStatusChangedventArgs(DateTimeOffset.Now, this._write_queue_name, false, false));
                    return false;
                }

                //mqWrite.Formatter = new XmlMessageFormatter(new Type[] { this._msg_type });
                
                if (!mqWrite.CanWrite)
                {
                    RdTrace.Debug("It is not able to write the message to queue {0}", this._write_queue_name);

                    //LaunchEvent<OnMQStatusChangedventArgs>(this.OnStatusChanged, new OnMQStatusChangedventArgs(DateTimeOffset.Now, this._write_queue_name, mqWrite.CanRead, mqWrite.CanWrite));
                    return false;
                }

                Message _newQueue = new Message();               
                Stream _tempStream = _newQueue.BodyStream;
                _tempStream.Write(ASCIIEncoding.ASCII.GetBytes(message), 0, message.Length);

                StreamReader reader = new StreamReader(_tempStream);

                mqWrite.Send(_newQueue);
                RdTrace.Debug("The message is -> " + message);
                RdTrace.Debug("We send this -> " + reader.ReadToEnd());
            }
            catch (Exception e)
            {
                RdTrace.Exception(e);

                return false;
            }
            finally
            {
                this._write_queue_name = _write_queue_name.Replace("in", "out");
                mutex_sending_message.ReleaseMutex();
            }

            return true;
        }
        #endregion
    }
}
