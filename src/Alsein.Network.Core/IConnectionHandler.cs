
using System.Threading.Tasks;

namespace Alsein.Network.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TOut"></typeparam>
    /// <typeparam name="TIn"></typeparam>
    public interface IConnectionHandler<out TOut, in TIn>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task ReveiceAsync(TIn data);
    }
}