using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;

namespace HSM.Utility.Common.Clients
{
    using Janus.Rodeo.Windows.Library.Rd_Log;
    using Janus.Rodeo.Windows.Library.Rd_Common;

    using Janus.Rodeo.Windows.Library.UI.Common.Messages;
    using Janus.Rodeo.Windows.Library.UI.Common.Helpers;

    public class XmlSenderRabbitMQBase : SenderRabbitMQBase
    {
        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlSenderRabbitMQBase"/> class.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="clientname"></param>
        /// <param name="default_queue_name"></param>
        public XmlSenderRabbitMQBase(string source, string clientname, string default_queue_name)
            : base(source, clientname, default_queue_name)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SenderRabbitMQBase"/> class.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="clientname"></param>
        /// <param name="virtual_host"></param>
        /// <param name="default_queue_name"></param>
        public XmlSenderRabbitMQBase(string source, string clientname, string virtual_host, string default_queue_name)
            : base(source, clientname, virtual_host, default_queue_name)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SenderRabbitMQBase"/> class.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="clientname"></param>
        /// <param name="default_queue_name"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public XmlSenderRabbitMQBase(string source, string clientname, string default_queue_name, string username, string password)
            : base(source, clientname, default_queue_name, username, password)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SenderRabbitMQBase"/> class.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="clientname"></param>
        /// <param name="virtual_host"></param>
        /// <param name="default_queue_name"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public XmlSenderRabbitMQBase(string source, string clientname, string virtual_host, string default_queue_name, string username, string password)
            : base(source, clientname, virtual_host, default_queue_name, username, password)
        { }

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
        public XmlSenderRabbitMQBase(string source, string clientname, string ip_address, string virtual_host, string default_queue_name, string username, string password)
            : base(source, clientname, ip_address, virtual_host, default_queue_name, username, password)
        { }

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
        public XmlSenderRabbitMQBase(string source, string clientname, string ip_address, int port, string virtual_host, string default_queue_name, string username, string password)
            : base(source, clientname, ip_address, port, virtual_host, default_queue_name, username, password)
        { }
        #endregion

        #region public methods
        /// <summary>
        /// Send
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="username"></param>
        /// <param name="data_send"></param>
        /// <returns></returns>
        protected bool Send<T>(string username, T data_send)
            where T : class
        {
            XmlMsgFull<T> message_send = new XmlMsgFull<T>();
            message_send.version = Janus.Rodeo.Windows.Library.UI.Common.Constant.MessageConstant.VERSION;
            message_send.source = this._source;
            message_send.author = new XmlMsgAuthor();
            message_send.author.username = username;
            message_send.author.clientname = this._clientname;
            message_send.author.eventtime = DateTimeOffset.Now;
            message_send.data = data_send;

            try
            {
                byte[] sendbuffer = CfgReader.Xml.GetBytes<XmlMsgFull<T>>(message_send);
                return this.SendMessage(sendbuffer);
            }
            catch (Exception ex)
            {
                RdTrace.Exception(ex);
            }

            return false;
        }
        #endregion
    }
}
