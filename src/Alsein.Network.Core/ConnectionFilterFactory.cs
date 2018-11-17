namespace Alsein.Network.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sendOutBoundAsync"></param>
    /// <param name="sendInBoundAsync"></param>
    /// <typeparam name="TOutBoundOut"></typeparam>
    /// <typeparam name="TOutBoundIn"></typeparam>
    /// <typeparam name="TInBoundOut"></typeparam>
    /// <typeparam name="TInBoundIn"></typeparam>
    /// <returns></returns>
    public delegate IConnectionFilter<TOutBoundOut, TOutBoundIn, TInBoundOut, TInBoundIn> ConnectionFilterFactory<out TOutBoundOut, in TOutBoundIn, out TInBoundOut, in TInBoundIn>(AsyncDataSender<TOutBoundOut> sendOutBoundAsync, AsyncDataSender<TInBoundOut> sendInBoundAsync);
}