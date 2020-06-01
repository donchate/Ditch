using Ditch.Core;
using Ditch.Hive.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ditch.Hive
{
    // https://developers.hive.io/quickstart/#quickstart-hive-full-nodes
    // https://github.com/holgern/beem/blob/master/beem/nodelist.py
    public static class NodeManager
    {
        private static readonly RepeatHttpClient HttpClient = new RepeatHttpClient();
        private static readonly HttpManager HttpManager = new HttpManager(HttpClient);
        public static OperationManager Api = new OperationManager(HttpManager);

        public static List<ApiNode> nodes = new List<ApiNode>(){
            new ApiNode()
            {
                Url = "https://api.hive.blog",
                Version = "0.23.0",
                Owner = "hive",
                Score = 50
            },
            new ApiNode()
            {
                Url = "https://api.hivekings.com",
                Version = "0.23.0",
                Owner = "drakos",
                Score = 50
            },
            new ApiNode()
            {
                Url = "https://anyx.io",
                Version = "0.23.0",
                Owner = "anyx",
                Score = 50
            },
            new ApiNode()
            {
                Url = "https://api.openhive.network",
                Version = "0.23.0",
                Owner = "gtg",
                Score = 20
            },
            new ApiNode()
            {
                Url = "https://api.hive.blue",
                Version = "0.23.0",
                Owner = "guiltyparties",
                Score = 20
            },
            new ApiNode()
            {
                Url = "https://techcoderx.com",
                Version = "0.23.0",
                Owner = "openhive",
                Score = 10
            },
            new ApiNode()
            {
                Url = "https://hived.privex.io",
                Version = "0.23.0",
                Owner = "someguy123",
                Score = 10
            },
            new ApiNode()
            {
                Url = "https://api.pharesim.me",
                Version = "0.23.0",
                Owner = "pharesim",
                Score = 10
            },
            new ApiNode()
            {
                Url = "https://rpc.ausbit.dev",
                Version = "0.23.0",
                Owner = "ausbitbank",
                Score = 10
            },
            new ApiNode()
            {
                Url = "https://hive.roelandp.nl",
                Version = "0.23.0",
                Owner = "roelandp",
                Score = 10
            }
        };

        public static ApiNode GetBestNode()
        {
            return nodes.Where(Active => true).Aggregate((agg, next) =>
                next.Score > agg.Score ? next : agg);
        }

        public static ApiNode[] GetActiveNodes()
        {
            return nodes.Where(Active => true).OrderByDescending(x => x.Score).ToArray();
        }
        
        public static async Task UpdateScores()
        {
            string[] args = { "fullnodeupdate" };
            await Api.ConnectToAsync(CancellationToken.None).ConfigureAwait(false);
            var response = await Api.CondenserGetAccountsAsync(args, CancellationToken.None);
        }
    }
}
