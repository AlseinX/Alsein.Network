using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Alsein.Network.Test
{
    public class SocketServerTest
    {
        [Fact]
        public async Task Test1()
        {
            var result = new List<string>();
            var task = Task.Run(async () =>
            {
                Task.Delay(1000).Wait();
                result.Add("b");
                await Task.Delay(1000);
                result.Add("c");
            });
            result.Add("a");
            await task;
            result.Add("d");
        }
    }
}