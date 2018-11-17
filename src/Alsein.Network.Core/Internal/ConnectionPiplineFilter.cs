using System.Threading.Tasks;

namespace Alsein.Network.Core.Internal
{
    internal class ConnectionPiplineFilter<TOutBoundOut, TOutBoundIn, TInBoundOut, TInBoundIn> : IConnectionPipelineNode<TOutBoundOut, TOutBoundIn>
    {
        private IConnectionFilter<TOutBoundOut, TOutBoundIn, TInBoundOut, TInBoundIn> _filter;

        private IConnectionPipelineNode<TInBoundIn, TInBoundOut> _next;

        public ConnectionPiplineFilter(ConnectionFilterFactory<TOutBoundOut, TOutBoundIn, TInBoundOut, TInBoundIn> filterFactory, IConnectionPipelineNode<TInBoundIn, TInBoundOut> next)
        {
            _next = next;
            _filter = filterFactory(OnSendAsync, next.ReceiveAsync);
            _next.SendAsync += _filter.ReceiveInBoundAsync;
        }

        public event AsyncDataSender<TOutBoundOut> SendAsync;

        private Task OnSendAsync(TOutBoundOut data) =>
            SendAsync?.Invoke(data) ?? Task.CompletedTask;

        public Task ReceiveAsync(TOutBoundIn data) => _filter.ReceiveOutBoundAsync(data);
    }
}