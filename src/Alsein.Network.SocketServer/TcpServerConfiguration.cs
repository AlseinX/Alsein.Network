using System.Collections.Generic;
using System.Net;

namespace Alsein.Network.SocketServer
{
    /// <summary>
    /// Server configuration.
    /// </summary>
    public class TcpServerConfiguration : ServerConfiguration
    {
        /// <summary>
        /// The backlog count on listening.
        /// </summary>
        /// <value></value>
        public int SocketBacklog { get; set; }
    }
}