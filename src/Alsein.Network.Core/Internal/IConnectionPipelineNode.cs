using System.Threading.Tasks;

namespace Alsein.Network.Core.Internal
{
    internal interface IConnectionPipelineNode<out TOut, in TIn>
    {
        Task ReceiveAsync(TIn data);

        event AsyncDataSender<TOut> SendAsync;
    }
}