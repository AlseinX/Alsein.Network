
using System.Threading.Tasks;

namespace Alsein.Network
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <typeparam name="TData"></typeparam>
    /// <returns></returns>
    public delegate Task AsyncDataSender<in TData>(TData data);
}