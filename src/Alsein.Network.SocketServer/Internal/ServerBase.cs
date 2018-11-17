using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Alsein.Network.SocketServer.Internal
{
    internal abstract class ServerBase : IServer
    {
        private TaskCompletionSource<object> _running = null;

        private bool _isStarting = false;

        private bool _isClosing = false;

        private protected EndPoint[] Bindings { get; }

        public ServerStatus Status
        {
            get
            {
                if (_running == null)
                {
                    return ServerStatus.NotStarted;
                }
                if (_isStarting)
                {
                    return ServerStatus.Starting;
                }
                if (_isClosing)
                {
                    return ServerStatus.Closing;
                }
                if (_running.Task.IsCompleted)
                {
                    return ServerStatus.Closed;
                }
                return ServerStatus.Running;
            }
        }

        public ServerBase(ServerConfiguration configuration)
        {
            Bindings = configuration.Bindings.ToArray();
        }

        public async Task Close()
        {
            _isClosing = true;
            await Stop();
            _isClosing = false;
            await _running.Task;
        }

        protected private abstract Task Stop();

        public async Task Run()
        {
            _isStarting = true;
            _running = new TaskCompletionSource<object>();
            await Start();
            _isStarting = false;
            await _running.Task;
        }

        protected private abstract Task Start();

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                Close().Wait();

                disposedValue = true;
            }
        }

        ~ServerBase()
        {
            Dispose(false);
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}