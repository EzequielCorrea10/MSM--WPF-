using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace HCM.Utility.Server.Common
{
    using Janus.Rodeo.Windows.Library.Rd_Log;
    using Janus.Rodeo.Windows.Library.Rd_Common;
    using HCM.Utility.Common;
    using HCM.Utility.Common.Constants;

    /// <summary>
    /// Handler of Message
    /// </summary>
    public abstract class MsgSckReceiver : IDisposable
    {
        #region private attributes
        /// <summary>
        /// use to lock the logical
        /// </summary>
        private readonly object lockInstance = new object();

        /// <summary>
        /// Get the socket
        /// </summary>
        private Socket _socket;

        /// <summary>
        /// Get the endPoint
        /// </summary>
        private IPEndPoint _endPoint;

        /// <summary>
        /// Get the Port of the connection.
        /// </summary>
        private int _port;

        /// <summary>
        /// Get the Local Interface Address to be used in the connection. if it's empty IPAdress.Any will be used
        /// </summary>
        private string _localInterface;

        /// <summary>
        /// connectTimeout
        /// </summary>
        private int _connectTimeout;

        /// <summary>
        /// Get the MaxQueue to listen
        /// </summary>
        private int _maxQueues;

        /// <summary>
        /// Get the MaxThreads of Functions executing at the same time
        /// </summary>
        private int _maxThreads;

        /// <summary>
        /// get the number of threads running at the same time
        /// </summary>
        private int _countThreads;

        /// <summary>
        /// size of header
        /// </summary>
        private int _sizeOfHeader;
        
        /// <summary>
        /// source
        /// </summary>
        private byte _source;
        #endregion

        #region public attribute
        /// <summary>
        /// Get the Port where the app will be listen from
        /// </summary>
        public int Port
        {
            get { return this._port; }
            set
            {
                if (!this.Connected)
                {
                    this._port = value;
                }
            }
        }

        /// <summary>
        /// Get the Local Interface Address to be used in the connection. if it's empty IPAdress.Any will be used
        /// </summary>
        public string LocalInterface
        {
            get { return this._localInterface; }
            set
            {
                if (!this.Connected)
                {
                    this._localInterface = value;
                }
            }
        }

        /// <summary>
        /// Connection Timeout
        /// </summary>
        public int ConnectTimeout
        {
            get { return this._connectTimeout; }
            set 
            {
                if (!this.Connected)
                {
                    this._connectTimeout = value;
                }
            }
        }

        /// <summary>
        /// Get the MaxQueue to listen
        /// </summary>
        public int MaxQueues
        {
            get { return this._maxQueues; }
            set
            {
                if (!this.Connected)
                {
                    this._maxQueues = value;
                }
            }
        }

        /// <summary>
        /// Get the MaxThreads of Functions executing at the same time
        /// </summary>
        public int MaxThreads
        {
            get { return this._maxThreads; }
            set
            {
                if (!this.Connected)
                {
                    this._maxThreads = value;
                }
            }
        }
        
        /// <summary>
        /// Get the indication if the main socket is connected
        /// </summary>
        public bool Connected
        {
            get
            {
                if (this._socket == null)
                {
                    return false;
                }
                return this._socket.IsBound;
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MsgSckReceiver"/> class.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="port"></param>
        /// <param name="local_interface"></param>
        public MsgSckReceiver(byte source, int port, string local_interface)
            : this(source, port, local_interface, SckConstant.SCK_MAX_QUEUES, SckConstant.SCK_MAX_THREADS)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MsgSckReceiver"/> class.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="port"></param>
        /// <param name="local_interface"></param>
        /// <param name="max_queues"></param>
        /// <param name="max_threads"></param>
        public MsgSckReceiver(byte source, int port, string local_interface, int max_queues, int max_threads)
        {
            this._source = source;
            this._port = port;
            this._localInterface = local_interface;
            this._maxQueues = max_queues;
            this._maxThreads = max_threads;

            this._sizeOfHeader = Marshal.SizeOf(typeof(MsgHeader));
            this._connectTimeout = SckConstant.SCK_CONNECT_TIMEOUT;
        }
        #endregion

        #region public methods
        /// <summary>
        /// Start Listen
        /// </summary>
        /// <returns></returns>
        public void StartListen()
        {
            lock (this.lockInstance)
            {
                if (!this.Connected)
                {
                    this.ValidationFunctions();

                    this.ValidationConnection();

                    this.OpenSocket();
                }
            }
        }

        /// <summary>
        /// Stop Listen
        /// </summary>
        /// <returns></returns>
        public void StopListen()
        {
            lock (this.lockInstance)
            {
                if (this.Connected)
                {
                    this.CloseSocket(ref this._socket);
                }
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
        protected abstract byte[] ProcessMessage(byte source, byte[] message);
        #endregion

        #region private method
        /// <summary>
        /// Validate the parameters of connection
        /// </summary>
        private void ValidationConnection()
        {
            if (this._port <= 0)
            {
                throw new Exception("[ERROR] You MUST specify a port number in which listen");
            }

            if (!string.IsNullOrEmpty(this._localInterface))
            {
                if (!NetworkFunctions.IsIPAddress(this._localInterface))
                {
                    throw new Exception(string.Format("[ERROR]: You must provide a Local Interface={0} with correct format", this._localInterface));
                }
            }
        }

        /// <summary>
        /// Start Connection
        /// </summary>
        private void OpenSocket()
        {
            this._countThreads = 0;
            
            this._endPoint = new IPEndPoint(string.IsNullOrEmpty(this._localInterface)
                                                ? IPAddress.Any
                                                : IPAddress.Parse(this._localInterface),
                                           this._port);

            this._socket = this.GetSocket();

            this._socket.Bind(this._endPoint);
            this._socket.Listen(this._maxQueues);
            this._socket.BeginAccept(new AsyncCallback(OnClientConnect), null);
        }

        /// <summary>
        /// GetSocket
        /// </summary>
        /// <returns></returns>
        private Socket GetSocket()
        {
            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.Blocking = true;

            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, SckConstant.SCK_RECEIVE_TIMEOUT);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, SckConstant.SCK_SEND_TIMEOUT);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer, SckConstant.SCK_RECEIVE_BUFFER);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendBuffer, SckConstant.SCK_RECEIVE_BUFFER);
            sck.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.TypeOfService, SckConstant.SCK_TYPE_OF_SERVICE);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, 0);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Linger, new LingerOption(true, 0));
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.OutOfBandInline, 1);
            sck.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, false);

            return sck;
        }

        /// <summary>
        /// close the Socket
        /// </summary>
        /// <param name="workerSocket">
        /// workerSocket
        /// </param>
        private void CloseSocket(ref Socket workerSocket)
        {
            try
            {
                workerSocket.Close();
                workerSocket.Dispose();
            }
            catch { }

            workerSocket = null;
        }
        #endregion

        #region call event
        /// <summary>
        /// Function to get the request of Client to connect
        /// </summary>
        /// <param name="asyn">
        /// asyn
        /// </param>
        private void OnClientConnect(IAsyncResult asyn)
        {
            Socket workerSocket;

            try
            {
                // Here we complete/end the BeginAccept() asynchronous call
                // by calling EndAccept() - which returns the reference to
                // a new Socket object
                workerSocket = this._socket.EndAccept(asyn);
            }
            catch (ObjectDisposedException e)
            {
                RdTrace.Exception(e, "socket with port {0}", this._port);
                return;
            }
            catch (SocketException e)
            {
                RdTrace.Exception(e, "socket with port {0}", this._port);
                return;
            }
            catch (Exception e)
            {
                RdTrace.Exception(e, "socket with port {0}", this._port);
                return;
            }
            finally
            {
                try
                {
                    // Since the main Socket is now free, it can go back and wait for
                    // other clients who are attempting to connect
                    this._socket.BeginAccept(new AsyncCallback(OnClientConnect), null);
                }
                catch {
                }
            }

            try
            {
                lock (this.lockInstance)
                {
                    this._countThreads++;

                    if (this._countThreads >= this._maxThreads)
                    {
                        //Getting just the IP
                        string remoteIP = ((System.Net.IPEndPoint)(workerSocket.RemoteEndPoint)).Address.ToString();

                        RdTrace.Debug("Remote IP={0} cannot allowed to access because the maxThread is reached={1}", remoteIP, this._countThreads);

                        return;
                    }
                }

                workerSocket.ReceiveBufferSize = this._socket.ReceiveBufferSize;
                workerSocket.SendBufferSize = this._socket.SendBufferSize;
                if (this._socket.ReceiveTimeout > 0)
                {
                    workerSocket.ReceiveTimeout = this._socket.ReceiveTimeout;
                }
                if (this._socket.SendTimeout > 0)
                {
                    workerSocket.SendTimeout = this._socket.SendTimeout;
                }

                this.Receive(ref workerSocket);
            }
            catch (Exception e)
            {
                RdTrace.Exception(e, "socket with port {0}", this._port);
            }
            finally
            {
                lock (this.lockInstance)
                {
                    this._countThreads--;
                }

                this.CloseSocket(ref workerSocket);
            }
        }

        /// <summary>
        /// Receive the message sent by Client
        /// </summary>
        /// <param name="workerSocket"></param>
        private void Receive(ref Socket workerSocket)
        {
            int bytesRec = 0, bytesSend = 0;
            byte[] bufferRec = new byte[SckConstant.SCK_RECEIVE_BUFFER];
            byte[] bufferSend = new byte[SckConstant.SCK_SEND_BUFFER];

            try
            {
                do
                {
                    bytesRec = workerSocket.Receive(bufferRec, 0, bufferRec.Length, SocketFlags.None);
                    if (bytesRec <= 0)
                    {
                        //Getting just the IP
                        string remoteIP = ((System.Net.IPEndPoint)(workerSocket.RemoteEndPoint)).Address.ToString();

                        RdTrace.Debug("Remote IP={0}, error receiving", remoteIP);
                        break;
                    }

                    if (bytesRec > this._sizeOfHeader)
                    {
                        MsgHeader headerResp = (MsgHeader)CommonFunctions.UnManageDeserialize(bufferRec, 0, typeof(MsgHeader));
                        if (headerResp.version == MsgConstant.MSG_VERSION)
                        {
                            byte[] message = new byte[bufferRec.Length - this._sizeOfHeader];
                            Buffer.BlockCopy(bufferRec, this._sizeOfHeader, message, 0, message.Length);

                            bufferSend = this.ProcessMessage(headerResp.source, message);

                            MsgHeader headerReq = new MsgHeader();
                            headerReq.version = MsgConstant.MSG_VERSION;
                            headerReq.source = this._source;

                            byte[] bufferHeader = CommonFunctions.UnManageSerialize(headerReq);
                            byte[] bufferResponse = new byte[bufferHeader.Length + bufferSend.Length];

                            Buffer.BlockCopy(bufferHeader, 0, bufferResponse, 0, bufferHeader.Length);
                            Buffer.BlockCopy(bufferSend, 0, bufferResponse, bufferHeader.Length, bufferSend.Length);

                            bytesSend = workerSocket.Send(bufferResponse, SocketFlags.None);
                            if (bytesSend != bufferResponse.Length)
                            {
                                //Getting just the IP
                                string remoteIP = ((System.Net.IPEndPoint)(workerSocket.RemoteEndPoint)).Address.ToString();

                                RdTrace.Debug("Remote IP={0}, error sending, butes sent {1}, confirmed {2}, bytes: {3}", remoteIP, bufferResponse.Length, bytesSend, string.Join(":", bufferResponse));
                                break;
                            }
                        }
                    }
                } while (bytesRec > 0 && bytesSend > 0);
            }
            catch (SocketException e)
            {
                if (e.SocketErrorCode == System.Net.Sockets.SocketError.TimedOut)
                { }
                else if (e.SocketErrorCode != System.Net.Sockets.SocketError.ConnectionReset)
                {
                    RdTrace.Exception(e);
                }
            }
            catch (Exception e)
            {
                RdTrace.Exception(e);
            }
        }
        #endregion

        #region Destructor
        /// <summary>
        /// Dispose a instance of the <see cref="MsgSckReceiver"/> class.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose a instance of the <see cref="MsgSckReceiver"/> class.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    lock (this.lockInstance)
                    {
                        if (this.Connected)
                        {
                            CloseSocket(ref this._socket);
                        }
                        this._socket = null;
                        this._endPoint = null;
                    }

                    RdTrace.Message("MsgSckReceiver was disposed");
                }
            }
            catch (Exception ex)
            {
                RdTrace.Exception(ex);
            }
        }

        /// <summary>
        /// Dispose a instance of the <see cref="MsgSckReceiver"/> class.
        /// </summary>
        ~MsgSckReceiver()
        {
            Dispose(true);
        }
        #endregion
    }
}
