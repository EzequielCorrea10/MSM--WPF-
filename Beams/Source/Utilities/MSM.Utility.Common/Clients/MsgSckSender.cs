using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;

namespace HSM.Utility.Common
{
    using Janus.Rodeo.Windows.Library.Rd_Log;
    using Janus.Rodeo.Windows.Library.Rd_Common;
    using HSM.Utility.Common.Constants;
    using HSM.Utility.Common.Structures;

    /// <summary>
    /// Sender of Response
    /// </summary>
    public abstract class MsgSckSender : IDisposable
    {
        #region private attributes
        /// <summary>
        /// use to lock the logical
        /// </summary>
        private readonly object lockInstance = new object();

        /// <summary>
        /// Used to Block the execution in Write and Read, only one at the time
        /// </summary>
        private Mutex mutex_sending_message = new Mutex();

        /// <summary>
        /// Get the socket
        /// </summary>
        private Socket _socket;

        /// <summary>
        /// Get the remotePoint
        /// </summary>
        private IPEndPoint _remotePoint;

        /// <summary>
        /// Get the source of the message
        /// </summary>
        private byte _source;

        /// <summary>
        /// Get the Ip Address of the connection.
        /// </summary>
        private string _ip_address;

        /// <summary>
        /// Get the Port of the connection.
        /// </summary>
        private int _port;

        /// <summary>
        /// connectTimeout
        /// </summary>
        private int _connectTimeout;

        /// <summary>
        /// size of header
        /// </summary>
        private int _sizeOfHeader;
        #endregion

        #region public attribute
        /// <summary>
        /// Get the Ip Address where the app will be connected to
        /// </summary>
        public string IP
        {
            get { return this._ip_address; }
            set
            {
                if (!this.Connected)
                {
                    this._ip_address = value;
                }
            }
        }

        /// <summary>
        /// Get the Port where the app will be connected to
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
        /// Get the indication if the socket is connected
        /// </summary>
        public bool Connected
        {
            get
            {
                if (this._socket == null)
                {
                    return false;
                }
                return this._socket.Connected;
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MsgSckSender"/> class.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="ip_address"></param>
        /// <param name="port"></param>
        public MsgSckSender(byte source, string ip_address, int port)
        {
            this._source = source;
            this._ip_address = ip_address;
            this._port = port;

            this._sizeOfHeader = Marshal.SizeOf(typeof(MsgHeader));
            this._connectTimeout = SckConstant.SCK_CONNECT_TIMEOUT;
        }
        #endregion

        #region public methods
        /// <summary>
        /// Start Listen
        /// </summary>
        /// <returns></returns>
        public void Connect()
        {
            lock (this.lockInstance)
            {
                if (!this.Connected)
                {
                    this.ValidationConnection();

                    this.OpenSocket();
                }
            }
        }

        /// <summary>
        /// Stop Listen
        /// </summary>
        /// <returns></returns>
        public void Disconnect()
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

        #region private method
        /// <summary>
        /// Validate the parameters of connection
        /// </summary>
        private void ValidationConnection()
        {
            if (!NetworkFunctions.IsIPAddress(this._ip_address))
            {
                throw new Exception(string.Format("[ERROR]: You must provide a Remote IP [{0}] with correct format", this._ip_address));
            }

            if (this._port <= 0)
            {
                throw new Exception("[ERROR] You MUST specify a port number in which listen");
            }
        }

        /// <summary>
        /// Start Connection
        /// </summary>
        private void OpenSocket()
        {
            this._socket = this.GetSocket();
            this._remotePoint = new IPEndPoint(IPAddress.Parse(this._ip_address), this._port);

            if (!this.AsyncConnect(this._socket, (s, a, o) => s.BeginConnect(this._remotePoint, a, o), TimeSpan.FromMilliseconds(this._connectTimeout)))
            {
                this.CloseSocket(ref this._socket);
            }
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

        /// <summary>
        /// Start Connection
        /// </summary>
        private void ReopenSocket()
        {
            this.CloseSocket(ref this._socket);
            Thread.Sleep(5);
            this.OpenSocket();
        }

        /// <summary>
        /// Asyncs the connect.
        /// </summary>
        /// <param name="socket">The socket.</param>
        /// <param name="connect">The connect.</param>
        /// <param name="timeout">The timeout.</param>
        private bool AsyncConnect(Socket socket, Func<Socket, AsyncCallback, object, IAsyncResult> connect, TimeSpan timeout)
        {
            IAsyncResult asyncResult = connect(socket, null, null);
            try
            {
                if (asyncResult.AsyncWaitHandle.WaitOne(timeout, true))
                {
                    socket.EndConnect(asyncResult);
                    return true;
                }
            }
            catch (SocketException se)
            {
                RdTrace.Exception(se, "SockectException for AsynConnect");
            }
            catch (ObjectDisposedException ode)
            {
                RdTrace.Exception(ode, "ObjectDisposedException for AsynConnect");
            }
            catch (Exception e)
            {
                RdTrace.Exception(e, "Exception for AsynConnect");
            }

            return false;
        }
        #endregion

        #region sending methods
        /// <summary>
        /// Send
        /// </summary>
        /// <typeparam name="W"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="header"></param>
        /// <param name="message"></param>
        /// <param name="source_response"></param>
        /// <param name="data_response"></param>
        /// <returns></returns>
        protected int Send<W, T>(W header, T message, out byte source_response, out byte[] data_response) where W : struct 
                                                                                                     where T : struct
        {
            byte[] bufferHeader, bufferBody;

            bufferHeader = CommonFunctions.UnManageSerialize(header);
            bufferBody = CommonFunctions.UnManageSerialize(message);

            byte[] bufferRequest = new byte[bufferHeader.Length + bufferBody.Length];

            Buffer.BlockCopy(bufferHeader, 0, bufferRequest, 0, bufferHeader.Length);
            Buffer.BlockCopy(bufferBody, 0, bufferRequest, bufferHeader.Length, bufferBody.Length);

            return this.Send(bufferRequest, out source_response, out data_response);
        }

        /// <summary>
        /// Send
        /// </summary>
        /// <param name="message"></param>
        /// <param name="source_response"></param>
        /// <param name="data_response"></param>
        /// <returns></returns>
        protected int Send<T>(T message, out byte source_response, out byte[] data_response) where T : struct
        {
            return this.Send(CommonFunctions.UnManageSerialize(message), out source_response, out data_response);
        }

        /// <summary>
        /// Send
        /// </summary>
        /// <param name="message"></param>
        /// <param name="source_response"></param>
        /// <param name="data_response"></param>
        /// <returns></returns>
        protected int Send(byte[] message, out byte source_response, out byte[] data_response)
        {
            MsgHeader headerReq = new MsgHeader();
            headerReq.version = MsgConstant.MSG_VERSION;
            headerReq.source = this._source;

            byte[] bufferHeader = CommonFunctions.UnManageSerialize(headerReq);

            byte[] bufferRequest = new byte[bufferHeader.Length + message.Length];

            Buffer.BlockCopy(bufferHeader, 0, bufferRequest, 0, bufferHeader.Length);
            Buffer.BlockCopy(message, 0, bufferRequest, bufferHeader.Length, message.Length);

            byte[] byteResponse;

            int byteRec = this.SendRequest(bufferRequest, out byteResponse);
            if (byteRec > this._sizeOfHeader)
            {
                MsgHeader headerResp = (MsgHeader)CommonFunctions.UnManageDeserialize(byteResponse, 0, typeof(MsgHeader));
                if (headerResp.version == MsgConstant.MSG_VERSION)
                {
                    source_response = headerResp.source;
                    data_response = new byte[byteResponse.Length - this._sizeOfHeader];
                    Buffer.BlockCopy(byteResponse, this._sizeOfHeader, data_response, 0, data_response.Length);
                    return data_response.Length;
                }
            }

            source_response = 0;
            data_response = null;

            return 0;
        }

        /// <summary>
        /// Send request to the Server
        /// </summary>
        /// <param name="dataBuffer">
        /// dataBuffer
        /// </param>
        /// <param name="retry">
        /// retry
        /// </param>
        /// <returns>
        /// Indication the number of bytes sent
        /// </returns>
        private int SendRequest(byte[] data, out byte[] buffer)
        {
            int bytesSend = 0;
            int bytesReceive = 0;

            buffer = new byte[SckConstant.SCK_RECEIVE_BUFFER];

            try
            {
                mutex_sending_message.WaitOne();

                bytesSend = this.SendMessage(data, true);
                if (bytesSend == data.Length)
                {
                    bytesReceive = this.ReceiveMessage(ref buffer, true);
                }
            }
            catch (Exception e)
            {
                RdTrace.Exception(e, "data {0}", string.Join(":", data));
            }
            finally
            {
                mutex_sending_message.ReleaseMutex();
            }

            return bytesReceive;
        }

        /// <summary>
        /// Send message to a Server
        /// </summary>
        /// <param name="data">dataBuffer</param>
        /// <param name="retry">retry</param>
        /// <returns>Indication the number of bytes sent</returns>
        private int SendMessage(byte[] data, bool retry)
        {
            int bytesSend = 0;

            try
            {
                bytesSend = this._socket.Send(data, SocketFlags.None);
            }
            catch (SocketException e)
            {
                if (e.SocketErrorCode != System.Net.Sockets.SocketError.ConnectionReset)
                {
                    RdTrace.Exception(e, "data {0}, retry {1}", string.Join(":", data), retry);
                }
            }
            catch (Exception e)
            {
                RdTrace.Exception(e, "data {0}, retry {1}", string.Join(":", data), retry);
            }
            finally
            {
                if (bytesSend != data.Length)
                {
                    if (retry)
                    {
                        this.ReopenSocket();

                        if (this.Connected)
                        {
                            bytesSend = this.SendMessage(data, false);
                        }
                    }
                }
            }

            return bytesSend;
        }

        /// <summary>
        /// Send message to a Server
        /// </summary>
        /// <param name="data">dataBuffer</param>
        /// <param name="retry">retry</param>
        /// <returns>Indication the number of bytes sent</returns>
        private int ReceiveMessage(ref byte[] data, bool retry)
        {
            int bytesRec = 0;

            try
            {
                bytesRec = this._socket.Receive(data, 0, data.Length, SocketFlags.None);
            }
            catch (SocketException e)
            {
                if (e.SocketErrorCode != System.Net.Sockets.SocketError.ConnectionReset)
                {
                    RdTrace.Exception(e, "data {0}, retry {1}", string.Join(":", data), retry);
                }
            }
            catch (Exception e)
            {
                RdTrace.Exception(e, "data {0}, retry {1}", string.Join(":", data), retry);
            }
            finally
            {
                if (bytesRec <= 0)
                {
                    if (retry)
                    {
                        this.ReopenSocket();

                        if (this.Connected)
                        {
                            bytesRec = this.ReceiveMessage(ref data, false);
                        }
                    }
                }
            }

            return bytesRec;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// Dispose a instance of the <see cref="MsgSckSender"/> class.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose a instance of the <see cref="MsgSckSender"/> class.
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
                        this._remotePoint = null;
                    }

                    //RdTrace.Message("MsgSckSender was disposed");
                }
            }
            catch (Exception ex)
            {
                RdTrace.Exception(ex);
            }
        }

        /// <summary>
        /// Dispose a instance of the <see cref="MsgSckSender"/> class.
        /// </summary>
        ~MsgSckSender()
        {
            Dispose(true);
        }
        #endregion
    }
}
