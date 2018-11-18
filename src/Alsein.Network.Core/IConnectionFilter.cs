using System.Threading.Tasks;

namespace Alsein.Network.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TOutBoundOut"></typeparam>
    /// <typeparam name="TOutBoundIn"></typeparam>
    /// <typeparam name="TInBoundOut"></typeparam>
    /// <typeparam name="TInBoundIn"></typeparam>
    public interface IConnectionFilter<out TOutBoundOut, in TOutBoundIn, out TInBoundOut, in TInBoundIn>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task ReceiveOutBoundAsync(TOutBoundIn data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task ReceiveInBoundAsync(TInBoundIn data);
    }
}