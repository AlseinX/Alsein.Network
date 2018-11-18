using System.Threading.Tasks;

namespace Alsein.Network.Configuration.Internal
{
    internal class ConnectionPipelineHandler<TOut, TIn> : IConnectionPipelineNode<TOut, TIn>
    {
        private IConnectionHandler<TOut, TIn> _handler;

        public ConnectionPipelineHandler(ConnectionHandlerFactory<TOut, TIn> handlerFactory)
        {
            _handler = handlerFactory(OnSendAsync);
        }

        public event AsyncDataSender<TOut> SendAsync;

        private Task OnSendAsync(TOut data) =>
            SendAsync?.Invoke(data) ?? Task.CompletedTask;

        public Task ReceiveAsync(TIn data) => _handler.ReveiceAsync(data);

    }
}