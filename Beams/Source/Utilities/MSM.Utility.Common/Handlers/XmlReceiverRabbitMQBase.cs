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

    using Janus.Rodeo.Windows.Library.UI.Common.Messages;
    using Janus.Rodeo.Windows.Library.UI.Common.Helpers;

    public abstract class XmlReceiverRabbitMQBase<T> : ReceiverRabbitMQBase
        where T : class
    {
        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlReceiverRabbitMQBase"/> class.
        /// </summary>
        /// <param name="default_queue_name"></param>
        public XmlReceiverRabbitMQBase(string default_queue_name)
            : base(default_queue_name)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlReceiverRabbitMQBase"/> class.
        /// </summary>
        /// <param name="virtual_host"></param>
        /// <param name="default_queue_name"></param>
        public XmlReceiverRabbitMQBase(string virtual_host, string default_queue_name)
            : base(virtual_host, default_queue_name)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlReceiverRabbitMQBase"/> class.
        /// </summary>
        /// <param name="default_queue_name"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public XmlReceiverRabbitMQBase(string default_queue_name, string username, string password)
            : base(default_queue_name, username, password)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlReceiverRabbitMQBase"/> class.
        /// </summary>
        /// <param name="virtual_host"></param>
        /// <param name="default_queue_name"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public XmlReceiverRabbitMQBase(string virtual_host, string default_queue_name, string username, string password)
            : base(virtual_host, default_queue_name, username, password)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlReceiverRabbitMQBase"/> class.
        /// </summary>
        /// <param name="ip_address"></param>
        /// <param name="virtual_host"></param>
        /// <param name="default_queue_name"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public XmlReceiverRabbitMQBase(string ip_address, string virtual_host, string default_queue_name, string username, string password)
            : base(ip_address, virtual_host, default_queue_name, username, password)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlReceiverRabbitMQBase"/> class.
        /// </summary>
        /// <param name="ip_address"></param>
        /// <param name="port"></param>
        /// <param name="virtual_host"></param>
        /// <param name="default_queue_name"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public XmlReceiverRabbitMQBase(string ip_address, int port, string virtual_host, string default_queue_name, string username, string password)
            : base(ip_address, port, virtual_host, default_queue_name, username, password)
        { }
        #endregion

        #region abstract methods
        /// <summary>
        /// process the message received and return a response
        /// </summary>
        /// <param name="source"></param>
        /// <param name="author"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        protected abstract void ProcessMessage(string source, XmlMsgAuthor author, T message);

        /// <summary>
        /// process the message received and return a response
        /// </summary>
        /// <param name="bufferRec"></param>
        /// <param name="bytesRec"></param>
        /// <param name="bufferSend"></param>
        /// <returns></returns>
        protected override void Receive(byte[] bufferRec)
        {
            XmlMsgFull<T> message_receive = CfgReader.Xml.GetItem<XmlMsgFull<T>>(bufferRec, 0, bufferRec.Length);
            if (message_receive.version != Janus.Rodeo.Windows.Library.UI.Common.Constant.MessageConstant.VERSION)
            {
                throw new Exception(string.Format("Error in the message version {0}", message_receive.version));
            }

            this.ProcessMessage(message_receive.source, message_receive.author, message_receive.data);
        }
        #endregion
    }
}