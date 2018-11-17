using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Alsein.Network.SocketServer
{
    /// <summary>
    /// Server configuration.
    /// </summary>
    public class ServerConfiguration
    {
        /// <summary>
        /// The end points to be listened.
        /// </summary>
        /// <value></value>
        public IEnumerable<EndPoint> Bindings { get; set; }

        /// <summary>
        /// The handler function for each connection.
        /// </summary>
        /// <value></value>
        public Func<Socket, CancellationToken, Task> ConnectionHandler { get; set; }
    }
}