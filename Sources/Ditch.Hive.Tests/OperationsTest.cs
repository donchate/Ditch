using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.JsonRpc;
using Ditch.Hive.Operations;
using NUnit.Framework;

namespace Ditch.Hive.Tests
{
    [TestFixture]
    public class OperationsTest : CondenserOperationsTest
    {
        protected override async Task Post(IList<byte[]> postingKeys, bool isNeedBroadcast, params BaseOperation[] op)
        {
            JsonRpcResponse response;
            if (isNeedBroadcast | IsNeedBroadcast)
                response = await Api.BroadcastOperationsAsync(postingKeys, op, CancellationToken.None).ConfigureAwait(false);
            else
                response = await Api.VerifyAuthorityAsync(postingKeys, op, CancellationToken.None).ConfigureAwait(false);

            WriteLine(response);
            Assert.IsFalse(response.IsError);
        }
    }
}