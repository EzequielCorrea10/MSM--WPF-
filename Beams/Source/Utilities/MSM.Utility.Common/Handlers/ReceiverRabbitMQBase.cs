using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace HSM.Utility.Common.Handlers
{
    using Janus.Rodeo.Windows.Library.Rd_Log;
    using Janus.Rodeo.Windows.Library.Rd_Common;

    public abstract class ReceiverRabbitMQBase : IDisposable
    {
        #region private constant
        protected const string LOCALHOST = "localhost";
        protected const int RETRY_CONNECTION = 10000;
        #endregion

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
        /// Get the connection
        /// </summary>
		private IConnection _connection;

        /// <summary>
        /// Get the channel
        /// </summary>
        private IModel _channel;

        /// <summary>
        /// Get the consumer
        /// </summary>
        private EventingBasicConsumer _consumer;

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
        /// Get the indication if the thread is running
        /// </summary>
        public bool Starting
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
        /// Initializes a new instance of the <see cref="ReceiverRabbitMQBase"/> class.
        /// </summary>
        /// <param name="default_queue_name"></param>
        public ReceiverRabbitMQBase(string default_queue_name)
        {
            this._ip_address = LOCALHOST;
            this._default_queue_name = default_queue_name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiverRabbitMQBase"/> class.
        /// </summary>
        /// <param name="virtual_host"></param>
        /// <param name="default_queue_name"></param>
        public ReceiverRabbitMQBase(string virtual_host, string default_queue_name)
        {
            this._ip_address = LOCALHOST;
            this._virtual_host = virtual_host;
            this._default_queue_name = default_queue_name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiverRabbitMQBase"/> class.
        /// </summary>
        /// <param name="default_queue_name"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public ReceiverRabbitMQBase(string default_queue_name, string username, string password)
        {
            this._ip_address = LOCALHOST;
            this._default_queue_name = default_queue_name;
            this._username = username;
            this._password = password;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiverRabbitMQBase"/> class.
        /// </summary>
        /// <param name="virtual_host"></param>
        /// <param name="default_queue_name"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public ReceiverRabbitMQBase(string virtual_host, string default_queue_name, string username, string password)
        {
            this._ip_address = LOCALHOST;
            this._virtual_host = virtual_host;
            this._default_queue_name = default_queue_name;
            this._username = username;
            this._password = password;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiverRabbitMQBase"/> class.
        /// </summary>
        /// <param name="ip_address"></param>
        /// <param name="virtual_host"></param>
        /// <param name="default_queue_name"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public ReceiverRabbitMQBase(string ip_address, string virtual_host, string default_queue_name, string username, string password)
        {
            this._ip_address = string.IsNullOrEmpty(ip_address) ? LOCALHOST : ip_address;
            this._virtual_host = virtual_host;
            this._default_queue_name = default_queue_name;
            this._username = username;
            this._password = password;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiverRabbitMQBase"/> class.
        /// </summary>
        /// <param name="ip_address"></param>
        /// <param name="port"></param>
        /// <param name="virtual_host"></param>
        /// <param name="default_queue_name"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public ReceiverRabbitMQBase(string ip_address, int port, string virtual_host, string default_queue_name, string username, string password)
        {
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
        /// Start Listen
        /// </summary>
        /// <returns></returns>
        public void Start()
        {
            lock (this.lockInstance)
            {
                if (!this.Connected)
                {
                    this.ValidationFunctions();

                    this.ValidationConnection();

                    this.OpenConnection();
                }
            }
        }

        /// <summary>
        /// Start Listen
        /// </summary>
        /// <returns></returns>
        public void StartAsync()
        {
            lock (this.lockInstance)
            {
                if (!this.Connected && !this.Starting)
                {
                    this.ValidationFunctions();

                    this.ValidationConnection();

                    if (this._cancelTask != null && !this._cancelTask.IsCancellationRequested)
                    {
                        this._cancelTask.Cancel();
                    }
                    this._cancelTask = new CancellationTokenSource();

                    this._processTask = new Task(() => DoStart(this._cancelTask.Token), this._cancelTask.Token);
                    this._processTask.Start();
                }
            }
        }

        /// <summary>
        /// Stop Listen
        /// </summary>
        /// <returns></returns>
        public void Stop()
        {
            lock (this.lockInstance)
            {
                if (this.Starting)
                {
                    if (this._cancelTask != null)
                    {
                        this._cancelTask.Cancel();
                    }
                    this._processTask.Wait(100);
                }

                if (this.Connected)
                {
                    this.CloseConnection();
                }
            }
        }
        #endregion

        #region protected abstract methods
        /// <summary>
        /// Validate the functions where the data will be send to
        /// </summary>
        protected abstract void ValidationFunctions();

        /// <summary>
        /// process the message received and return a response
        /// </summary>
        /// <param name="bufferRec"></param>
        /// <param name="bytesRec"></param>
        /// <param name="bufferSend"></param>
        /// <returns></returns>
        protected abstract void Receive(byte[] message);
        #endregion

        #region task methods
        /// <summary>
        /// Activation Process
        /// </summary>
        /// <param name="token"></param>
        private void DoStart(CancellationToken token)
        {
            try
            {
                DateTimeOffset lastExecution = DateTimeOffset.Now.AddMilliseconds(RETRY_CONNECTION);

                while (true)
                {
                    if ((DateTimeOffset.Now - lastExecution).TotalMilliseconds >= RETRY_CONNECTION)
                    {
                        this.OpenConnection();

                        lastExecution = DateTimeOffset.Now;
                    }

                    if (token.IsCancellationRequested || this.Connected)
                    {
                        break;
                    }

                    Thread.Sleep(200);
                }
            }
            catch (Exception ex)
            {
                RdTrace.Exception(ex);
            }
            finally
            {
                if (!token.IsCancellationRequested && !this.Connected)
                {
                    _processTask = new Task(() => DoStart(token), token);
                    _processTask.Start();
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

                this._channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                this._consumer = new EventingBasicConsumer(this._channel);
                this._consumer.Received += Receive;

                this._channel.BasicConsume(queue: this._default_queue_name,
                                           autoAck: false,
                                           consumer: this._consumer);

                RdTrace.Debug("IP: {0}, V-Host: {1}, Q-Name: {2} Connected", this._ip_address, this._virtual_host, this._default_queue_name);
            }
            catch (RabbitMQ.Client.Exceptions.BrokerUnreachableException ex)
            {
                RdTrace.Exception(ex, "IP: {0}, V-Host: {1}, Q-Name: {2}, Usr: {3}, Pwd: {4}", this._ip_address, this._virtual_host, this._default_queue_name, this._username, this._password);

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

        #region event methods
        /// <summary>
        /// Receive the message sent by Client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Receive(object sender, BasicDeliverEventArgs e)
        {
            ReadOnlyMemory<byte> body = e.Body;
            IBasicProperties props = e.BasicProperties;

            try
            {
                this.Receive(body.ToArray());
            }
            catch (Exception ex)
            {
                RdTrace.Exception(ex, "Origin: {0}", props.CorrelationId);
            }
            finally
            {
                this._channel.BasicAck(deliveryTag: e.DeliveryTag, multiple: false);
            }
        }
        #endregion

        #region Destructor
        /// <summary>
        /// Dispose a instance of the <see cref="ReceiverRabbitMQBase"/> class.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose a instance of the <see cref="ReceiverRabbitMQBase"/> class.
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
        /// Dispose a instance of the <see cref="ReceiverRabbitMQBase"/> class.
        /// </summary>
        ~ReceiverRabbitMQBase()
        {
            Dispose(true);
        }
        #endregion
    }
}