using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Core;
using Ditch.Hive.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Ditch.Hive.Tests
{
    [TestFixture]
    public class ConnectionTest : BaseTest
    {
        [OneTimeSetUp]
        protected override void OneTimeSetUp()
        {
            HttpClient = new RepeatHttpClient();
            HttpManager = new HttpManager(HttpClient);
            Api = new OperationManager(HttpManager);
            ApiNode[] ActiveNodes = NodeManager.GetActiveNodes();
        }

        [Test]
        public async Task NodeScoringTest()
        {
            await NodeManager.UpdateScores();
        }

        [Test, Parallelizable, TestCaseSource("ActiveNodes")]
        public async Task NodeTest(ApiNode apiNode)
        {
            var token = CancellationToken.None;

            var sw = new Stopwatch();
            sw.Start();
            try
            {
                var isConnected = await Api
                    .ConnectToAsync(apiNode.Url, token)
                    .ConfigureAwait(false);

                Assert.IsTrue(isConnected, $"1 - DOWN {sw.ElapsedMilliseconds}");
            }
            catch (AssertionException)
            {
                throw;
            }
            catch (Exception)
            {
                Assert.Fail($"1 - DOWN {sw.ElapsedMilliseconds}");
                return;
            }

            var configResp = await Api
                .GetConfigAsync<JObject>(token)
                .ConfigureAwait(false);

            Assert.IsFalse(configResp.IsError, $"2 - NO CONFIG {sw.ElapsedMilliseconds}");

            var conf = configResp.Result;

            var isTestNet = conf.Value<bool>("IS_TEST_NET");
            Assert.IsFalse(isTestNet, "3 - Testnet");

            var version = configResp.Result.Value<string>("HIVE_BLOCKCHAIN_VERSION");
            Assert.IsFalse(string.IsNullOrEmpty(version), "4 - unknown version");
            Assert.IsTrue(new Regex("^0.23.[0-9]{1,2}$").IsMatch(version), "5 - not supported version");
            WriteLine(version);

            var args = new GetBlockArgs
            {
                BlockNum = 28000000
            };
            var block = await Api
                .GetBlockAsync(args, CancellationToken.None)
                .ConfigureAwait(false);

            Assert.IsFalse(block.IsError, "6 - get block error");

            var testDir = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
            var testFile = Path.Combine(testDir, "TestBlock28000000.txt");
            Assert.IsTrue(File.Exists(testFile), "test file not exist!");

            var validJson = File.ReadAllText(testFile);
            var t = JsonBeautify(block.RawResponse);
            Assert.IsTrue(t.Contains(validJson), $"7 - block validation fail{Environment.NewLine}{t}");

            WriteLine($"time (mls): {sw.ElapsedMilliseconds}");
            Assert.IsTrue(Api.IsConnected);
        }
    }
}
