﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Ditch.Steem.Tests
{
    [TestFixture]
    public class ConnectionTest : BaseTest
    {
        [OneTimeSetUp]
        protected override void OneTimeSetUp() { }

        /// <summary>
        /// https://www.steem.center/index.php?title=Public_Websocket_Servers
        /// </summary>
        /// <param name="url"></param>
        [Ignore("LongRuningTest")]
        [Test]
        [TestCase("https://api.steemit.com")]
        [TestCase("https://steemd.steemit.com")]
        [TestCase("https://steemd.steemitstage.com")]
        [TestCase("https://steemd.steemitdev.com")]
        [TestCase("https://steemd.privex.io")]
        [TestCase("https://gtg.steem.house:8090")]
        [TestCase("https://rpc.steemliberator.com")]
        [TestCase("https://node.steem.ws")]
        [TestCase("https://steemd.minnowsupportproject.org")]
        [TestCase("https://rpc.buildteam.io")]
        [TestCase("https://steemd.pevo.science")]
        [TestCase("https://steemd.steemgigs.org")]
        [TestCase("https://rpc.buildteam.io")]
        [TestCase("https://steemd2.steepshot.org")]
        [TestCase("https://steemd.steepshot.org")]
        public void NodeTest(string url)
        {
            var manager = new OperationManager();
            var token = CancellationToken.None;

            var sw = new Stopwatch();
            var urls = new List<string> { url };
            sw.Restart();
            if (manager.TryConnectTo(urls, token))
            {
                manager.GetHardforkProperties(token);
            }
            sw.Stop();

            WriteLine($"time (mls): {sw.ElapsedMilliseconds}");
            Assert.IsTrue(manager.IsConnected, $"Not connected to {url}");
        }

        [Ignore("LongRuningTest")]
        [Test]
        public async Task TryConnectToHttpsTest()
        {
            var urls = new List<string> {
                "https://api.steemit.com",
                "https://steemd.steemit.com",
                "https://steemd.steemitstage.com",
                "https://steemd.steemitdev.com",
                "https://steemd.privex.io",
                "https://gtg.steem.house:8090",
                "https://rpc.steemliberator.com",
                "https://node.steem.ws",
                "https://steemd.minnowsupportproject.org",
                "https://rpc.buildteam.io",
                "https://steemd.pevo.science",
                "https://steemd.steemgigs.org",
                "https://rpc.buildteam.io",
                "https://steemd2.steepshot.org"
            };

            var manager = new OperationManager();

            var sw = new Stopwatch();
            for (var i = 0; i < 5; i++)
            {
                sw.Restart();
                var url = manager.TryConnectTo(urls, CancellationToken.None);
                sw.Stop();
                WriteLine($"{i} conected to {url} {sw.ElapsedMilliseconds}");
                Assert.IsTrue(manager.IsConnected, "Not connected");
                await Task.Delay(3000);
            }
        }
    }
}
