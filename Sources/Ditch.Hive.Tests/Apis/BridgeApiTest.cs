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
            var resp = await Api.BridgeGetRankedPostsAsync(args, CancellationToken.None).ConfigureAwait(false);
            Assert.IsNull(resp.Exception);
        }

        [Test]
        public async Task GetDiscussion()
        {
            var args = new GetDiscussionArgs
            {
                Author = "adelepazani",
                Permlink = "how-i-paint-landscape-with-acrylic-on-canvas"
            };
            var resp = await Api.BridgeGetDiscussionAsync(args, CancellationToken.None).ConfigureAwait(false);
            Assert.IsNull(resp.Exception);
        }
    }
}
