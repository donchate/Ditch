using System.Threading;
using System.Threading.Tasks;
using Ditch.Hive.Models;
using NUnit.Framework;

namespace Ditch.Hive.Tests.Apis
{
    [TestFixture]
    public class WitnessApiTest : BaseTest
    {
        [Test][Parallelizable]
        public async Task get_account_bandwidth()
        {
            var args = new GetAccountBandwidthArgs
            {
                Account = User.Login,
                Type = BandwidthType.Forum
            };
            var resp = await Api.GetAccountBandwidthAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestProperties(resp);
        }

        [Test][Parallelizable]
        public async Task get_reserve_ratio()
        {
            var args = new GetReserveRatioArgs();
            var resp = await Api.GetReserveRatioAsync(args, CancellationToken.None).ConfigureAwait(false);
            TestProperties(resp);
        }
    }
}
