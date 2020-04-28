using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.JsonRpc;
using Ditch.Hive.Models;

namespace Ditch.Hive
{
    /// <summary>
    /// bridge presents data interpreted by the hivemind database
    /// https://github.com/steemit/hivemind
    /// </summary>
    public partial class OperationManager
    {

        /////////////////////////////
        // Bridge //
        /////////////////////////////
        
        // get_profile
        // get_trending_topics
        // get_post

        public Task<JsonRpcResponse<List<HivemindPost>>> GetAccountPosts(GetAccountPostsArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<List<HivemindPost>>(KnownApiNames.BridgeApi, "get_account_posts", args, token);
        }

        public Task<JsonRpcResponse<List<HivemindPost>>> GetRankedPostsAsync(GetRankedPostsArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<List<HivemindPost>>(KnownApiNames.BridgeApi, "get_ranked_posts", args, token);
        }
    }
}