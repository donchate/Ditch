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
        
        public Task<JsonRpcResponse<GetRankedPostsReturn>> GetRankedPostsAsync(GetRankedPostsArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetRankedPostsReturn>(KnownApiNames.BridgeApi, "get_ranked_posts", args, token);
        }
    }
}
