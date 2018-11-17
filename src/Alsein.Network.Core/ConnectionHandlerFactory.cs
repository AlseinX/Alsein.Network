namespace Alsein.Network.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sendAsync"></param>
    /// <typeparam name="TOut"></typeparam>
    /// <typeparam name="TIn"></typeparam>
    /// <returns></returns>
    public delegate IConnectionHandler<TOut, TIn> ConnectionHandlerFactory<out TOut, in TIn>(AsyncDataSender<TOut> sendAsync);
}