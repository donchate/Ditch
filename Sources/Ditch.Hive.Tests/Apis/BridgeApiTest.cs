using System;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Hive.Models;
using NUnit.Framework;

namespace Ditch.Hive.Tests.Apis
{
    [TestFixture]
    public class BridgeApiTest : BaseTest
    {
        public Array GetRankedPostsSorting()
        {
            return Enum.GetValues(typeof(GetRankedPostsArgs.SortOptions));
        }

        [Test][Parallelizable]
        public async Task Get_ranked_posts()
        {
            var args = new GetRankedPostsArgs
            {
                Sort = GetRankedPostsArgs.SortOptions.created,
                Observer = "ditch"
            };
            var resp = await Api.GetRankedPostsAsync(args, CancellationToken.None).ConfigureAwait(false);
            Assert.IsNull(resp.Exception);
        }
    }
}
