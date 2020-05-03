using Ditch.Hive.Models;
using Newtonsoft.Json;
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
        public static OperationManager Api;

        public static List<ApiNode> nodes = new List<ApiNode>(){
            new ApiNode()
            {
                Url = "https://api.hive.blog",
                Version = "0.23.0",
                Owner = "openhive",
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
                Url = "https://api.openhive.network",
                Version = "0.23.0",
                Owner = "openhive",
                Score = 20
            },
            new ApiNode()
            {
                Url = "https://api.guiltyparties.com",
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
        public static async Task UpdateNodes()
        {
            string[] args = { "fullnodeupdate" };
            var response = await Api.CondenserGetAccountsAsync(args, CancellationToken.None).ConfigureAwait(false);
        }
    }
}
