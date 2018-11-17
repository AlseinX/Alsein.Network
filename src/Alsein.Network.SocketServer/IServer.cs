using System;
using System.Threading.Tasks;

namespace Alsein.Network.SocketServer
{
    /// <summary>
    /// 
    /// </summary>
    public interface IServer : IDisposable
    {
        /// <summary>
        /// Starts the server, returning on closed.
        /// </summary>
        /// <returns></returns>
        Task Run();

        /// <summary>
        /// The current status of the server.
        /// </summary>
        /// <value></value>
        ServerStatus Status { get; }

        /// <summary>
        /// Closes the server, returning on completion.
        /// </summary>
        /// <returns></returns>
        Task Close();
    }
}