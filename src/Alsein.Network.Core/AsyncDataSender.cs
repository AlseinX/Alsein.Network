
using System.Threading.Tasks;

namespace Alsein.Network.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    public delegate Task AsyncDataSender<in TData>(TData data);
}