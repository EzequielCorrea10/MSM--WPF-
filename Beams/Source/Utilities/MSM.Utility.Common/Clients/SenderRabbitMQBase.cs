using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using RabbitMQ.Client;

namespace HCM.Utility.Common.Clients
{
    using Janus.Rodeo.Windows.Library.Rd_Log;
    using Janus.Rodeo.Windows.Library.Rd_Common;

    public abstract class SenderRabbitMQBase : IDisposable
    {
        #region private constant
        protected const string LOCALHOST = "localhost";
        protected const int RETRY_CONNECTION = 10000;
        #endregion

        #region protected attributes
        /// <summary>
        /// Get the source of the message
        /// </summary>
        protected string _source;

        /// <summary>
        /// Get the source of the message
        /// </summary>
        protected string _clientname;
        #endregion

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
        /// Get the connection
        /// </summary>
		private IConnection _connection;

        /// <summary>
        /// Get the channel
        /// </summary>
        private IModel _channel;

        /// <summary>
        /// Get the properties
        /// </summary>
        private IBasicProperties _properties;

        /// <summary>
        /// Get the Ip Address of the connection.
        /// </summary>
        private string _ip_address;

        /// <summary>
        /// Get the Port of the connection.
        /// </summary>
        private int? _port;

        /// <summary>
        /// Get the Virtual Host of the connection.
        /// </summary>
        private string _virtual_host;

        /// <summary>
        /// Get default queue name
        /// </summary>
        private string _default_queue_name;

        /// <summary>
        /// Get the user of the connection.
        /// </summary>
        private string _username;

        /// <summary>
        /// Get the password of the connection.
        /// </summary>
        private string _password;

        /// <summary>
        /// connectTimeout
        /// </summary>
        private TimeSpan? _connectTimeout;

        /// <summary>
        /// sendTimeout
        /// </summary>
        private TimeSpan? _sendTimeout;

        /// <summary>
        /// receiveTimeout
        /// </summary>
        private TimeSpan? _receiveTimeout;
        #endregion

        #region public attributes
        /// <summary>
        /// Get or Set the Ip Address where the app will be connected to
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
        /// Get or Set the Port where the app will be connected to
        /// </summary>
        public int? Port
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
        /// Get or Set the Virtual Host where the app will be connected to
        /// </summary>
        public string VirtualHost
        {
            get { return this._virtual_host; }
            set
            {
                if (!this.Connected)
                {
                    this._virtual_host = value;
                }
            }
        }

        /// <summary>
        /// Get or Set the default queue name where the app will send the messages
        /// </summary>
        public string DefaulltQueueName
        {
            get { return this._default_queue_name; }
            set
            {
                if (!this.Connected)
                {
                    this._default_queue_name = value;
                }
            }
        }

        /// <summary>
        /// Get or Set the Username used to connect the app
        /// </summary>
        public string UserName
        {
            get { return this._username; }
            set
            {
                if (!this.Connected)
                {
                    this._username = value;
                }
            }
        }

        /// <summary>
        /// Get or Set the Password used to connect the app
        /// </summary>
        public string Password
        {
            get { return this._password; }
            set
            {
                if (!this.Connected)
                {
                    this._password = value;
                }
            }
        }

        /// <summary>
        /// Get or Set Connection Timeout
        /// </summary>
        public TimeSpan? ConnectTimeout
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
        /// Get or Set Send Timeout
        /// </summary>
        public TimeSpan? SendTimeout
        {
            get { return this._sendTimeout; }
            set
            {
                if (!this.Connected)
                {
                    this._sendTimeout = value;
                }
            }
        }

        /// <summary>
        /// Get or Set Receive Timeout
        /// </summary>
        public TimeSpan? ReceiveTimeout
        {
            get { return this._receiveTimeout; }
            set
            {
                if (!this.Connected)
                {
                    this._receiveTimeout = value;
                }
            }
        }

        /// <summary>
        /// Get the indication if the channel is open
        /// </summary>
        public bool Connected
        {
            get
            {
                if (this._connection == null)
                {
                    return false;
                }
                return this._connection.IsOpen;
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SenderRabbitMQBase"/> class.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="clientname"></param>
        /// <param name="default_queue_name"></param>
        public SenderRabbitMQBase(string source, string clientname, string default_queue_name)
        {
            this._source = source;
            this._clientname = clientname;
            this._ip_address = LOCALHOST;
            this._default_queue_name = default_queue_name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SenderRabbitMQBase"/> class.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="clientname"></param>
        /// <param name="virtual_host"></param>
        /// <param name="default_queue_name"></param>
        public SenderRabbitMQBase(string source, string clientname, string virtual_host, string default_queue_name)
        {
            this._source = source;
            this._clientname = clientname;
            this._ip_address = LOCALHOST;
            this._virtual_host = virtual_host;
            this._default_queue_name = default_queue_name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SenderRabbitMQBase"/> class.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="clientname"></param>
        /// <param name="default_queue_name"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public SenderRabbitMQBase(string source, string clientname, string default_queue_name, string username, string password)
        {
            this._source = source;
            this._clientname = clientname;
            this._ip_address = LOCALHOST;
            this._default_queue_name = default_queue_name;
            this._username = username;
            this._password = password;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SenderRabbitMQBase"/> class.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="clientname"></param>
        /// <param name="virtual_host"></param>
        /// <param name="default_queue_name"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public SenderRabbitMQBase(string source, string clientname, string virtual_host, string default_queue_name, string username, string password)
        {
            this._source = source;
            this._clientname = clientname;
            this._ip_address = LOCALHOST;
            this._virtual_host = virtual_host;
            this._default_queue_name = default_queue_name;
            this._username = username;
            this._password = password;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SenderRabbitMQBase"/> class.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="clientname"></param>
        /// <param name="ip_address"></param>
        /// <param name="virtual_host"></param>
        /// <param name="default_queue_name"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public SenderRabbitMQBase(string source, string clientname, string ip_address, string virtual_host, string default_queue_name, string username, string password)
        {
            this._source = source;
            this._clientname = clientname;
            this._ip_address = string.IsNullOrEmpty(ip_address) ? LOCALHOST : ip_address;
            this._virtual_host = virtual_host;
            this._default_queue_name = default_queue_name;
            this._username = username;
            this._password = password;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SenderRabbitMQBase"/> class.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="clientname"></param>
        /// <param name="ip_address"></param>
        /// <param name="port"></param>
        /// <param name="virtual_host"></param>
        /// <param name="default_queue_name"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public SenderRabbitMQBase(string source, string clientname, string ip_address, int port, string virtual_host, string default_queue_name, string username, string password)
        {
            this._source = source;
            this._clientname = clientname;
            this._ip_address = string.IsNullOrEmpty(ip_address) ? LOCALHOST : ip_address;
            this._port = port;
            this._virtual_host = virtual_host;
            this._default_queue_name = default_queue_name;
            this._username = username;
            this._password = password;
        }
        #endregion

        #region public methods
        /// <summary>
        /// Connect
        /// </summary>
        public void Connect()
        {
            lock (this.lockInstance)
            {
                if (!this.Connected)
                {
                    this.ValidationConnection();

                    this.OpenConnection();
                }
            }
        }

        /// <summary>
        /// Disconnect
        /// </summary>
        public void Disconnect()
        {
            lock (this.lockInstance)
            {
                if (this.Connected)
                {
                    this.CloseConnection();
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
            if (this._ip_address != LOCALHOST)
            {
                if (!NetworkFunctions.IsIPAddress(this._ip_address))
                {
                    throw new Exception(string.Format("[ERROR]: You must provide a Remote IP [{0}] with a valid format", this._ip_address));
                }

                if (this._port != null && this._port <= 0)
                {
                    throw new Exception("[ERROR] You MUST specify a valid port number");
                }
            }
        }

        /// <summary>
        /// Start Connection
        /// </summary>
        private void OpenConnection()
        {
            try
            {
                this._connection = this.GetConnection();

                this._channel = this._connection.CreateModel();
                this._channel.QueueDeclare(queue: this._default_queue_name,
                                           durable: true,
                                           exclusive: false,
                                           autoDelete: false,
                                           arguments: null);

                this._properties = this._channel.CreateBasicProperties();
                this._properties.CorrelationId = Guid.NewGuid().ToString();
                this._properties.Persistent = true;
            }
            catch (RabbitMQ.Client.Exceptions.BrokerUnreachableException ex)
            {
                RdTrace.Exception(ex, "IP: {0}, V-Host: {1}", this._ip_address, this._virtual_host);

                if (this._connection != null && this._connection.IsOpen)
                    this._connection.Close();
            }
            catch (Exception ex)
            {
                RdTrace.Exception(ex, "IP: {0}, V-Host: {1}, Q-Name: {2}, Usr: {3}, Pwd: {4}", this._ip_address, this._virtual_host, this._default_queue_name, this._username, this._password);

                if (this._connection != null && this._connection.IsOpen)
                    this._connection.Close();
            }
        }

        /// <summary>
        /// Get Connection
        /// </summary>
        /// <returns></returns>
        private IConnection GetConnection()
        {
            ConnectionFactory factory = new ConnectionFactory() { HostName = this._ip_address };
            factory.AutomaticRecoveryEnabled = true;
            factory.NetworkRecoveryInterval = TimeSpan.FromMilliseconds(RETRY_CONNECTION);

            if (this._port != null)
            {
                factory.Port = this._port.Value;
            }

            if (!string.IsNullOrEmpty(this._virtual_host))
            {
                factory.VirtualHost = this._virtual_host;
            }

            if (!string.IsNullOrEmpty(this._username))
            {
                factory.UserName = this._username;
            }

            if (!string.IsNullOrEmpty(this._password))
            {
                factory.Password = this._password;
            }

            if (this._connectTimeout != null)
            {
                factory.RequestedConnectionTimeout = this._connectTimeout.Value;
            }

            if (this._receiveTimeout != null)
            {
                factory.SocketReadTimeout = this._receiveTimeout.Value;
            }

            if (this._sendTimeout != null)
            {
                factory.SocketReadTimeout = this._sendTimeout.Value;
            }

            return factory.CreateConnection();
        }

        /// <summary>
        /// Close Connection
        /// </summary>
        /// <param name="workerSocket">
        /// workerSocket
        /// </param>
        private void CloseConnection()
        {
            try
            {
                if (this._channel != null)
                {
                    this._channel.Close();
                    this._channel.Dispose();
                }
            }
            catch { }

            try
            {
                if (this._connection != null)
                {
                    this._connection.Close();
                    this._connection.Dispose();
                }
            }
            catch { }

            this._connection = null;
        }
        #endregion

        #region sending methods
        /// <summary>
        /// Send message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected bool SendMessage(byte[] message)
        {
            try
            {
                mutex_sending_message.WaitOne();

                this._channel.BasicPublish(exchange: "",
                                           routingKey: this._default_queue_name,
                                           basicProperties: this._properties,
                                           body: message);

                return true;
            }
            catch (Exception e)
            {
                RdTrace.Exception(e, "message {0}", string.Join(":", message));
            }
            finally
            {
                mutex_sending_message.ReleaseMutex();
            }

            return false;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// Dispose a instance of the <see cref="SenderRabbitMQBase"/> class.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose a instance of the <see cref="SenderRabbitMQBase"/> class.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            try
            {
                this.Disconnect();
            }
            catch (Exception ex)
            {
                RdTrace.Exception(ex);
            }
        }

        /// <summary>
        /// Dispose a instance of the <see cref="SenderRabbitMQBase"/> class.
        /// </summary>
        ~SenderRabbitMQBase()
        {
            Dispose(true);
        }
        #endregion
    }
}