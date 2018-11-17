using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Alsein.Network.SocketServer.Internal;

namespace Alsein.Network.SocketServer
{
    internal class TcpServer : ServerBase
    {
        private Socket[] _listeners;

        private ICollection<Func<Task>> _connectionCancellers;

        private Func<Socket, CancellationToken, Task> _handler;

        private int _socketBacklog;

        public TcpServer(TcpServerConfiguration configuration) : base(configuration)
        {
            _socketBacklog = configuration.SocketBacklog;
            _handler = configuration.ConnectionHandler;
            _connectionCancellers = new LinkedList<Func<Task>>();
        }

        private protected override Task Start()
        {
            _listeners = new Socket[Bindings.Length];
            lock (_listeners)
            {
                for (var i = 0; i < _listeners.Length; i++)
                {
                    _listeners[i] = Listen(Bindings[i]);
                }
            }
            return Task.CompletedTask;
        }

        private protected override async Task Stop()
        {
            lock (_listeners)
            {
                foreach (var listener in _listeners)
                {
                    listener.Close();
                }
            }
            await Task.WhenAll(_connectionCancellers.Select(canceller => canceller()));
        }

        private Socket Listen(EndPoint binding)
        {
            var socket = new Socket(binding.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(binding);
            socket.Listen(_socketBacklog);
            socket.BeginAccept(OnAccept, socket);
            return socket;
        }

        private void OnAccept(IAsyncResult ar)
        {
            var listener = (Socket)ar.AsyncState;
            lock (_listeners)
            {
                if (Status == ServerStatus.Closing || Status == ServerStatus.Closed)
                {
                    return;
                }
                var connection = listener.EndAccept(out _, ar);
                var cancellation = new CancellationTokenSource();
                var handler = Task.Run(() => _handler(connection, cancellation.Token), cancellation.Token);
                _connectionCancellers.Add(async () =>
                {
                    cancellation.Cancel();
                    await handler;
                });
                listener.BeginAccept(OnAccept, listener);
            }
        }
    }
}