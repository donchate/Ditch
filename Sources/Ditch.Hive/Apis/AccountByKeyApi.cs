﻿using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.JsonRpc;
using Ditch.Hive.Models;

namespace Ditch.Hive
{
    /// <summary>
    /// account_by_key_api
    /// libraries\plugins\apis\account_by_key_api\include\steem\plugins\account_by_key_api\account_by_key_api.hpp
    /// </summary>
    public partial class OperationManager
    {
        /// <summary>
        /// API name: get_key_references
        /// 
        /// </summary>
        /// <param name="args">API type: get_block_header_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: account_name_type</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetKeyReferencesReturn>> GetKeyReferencesAsync(GetKeyReferencesArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetKeyReferencesReturn>(KnownApiNames.AccountByKeyApi, "get_key_references", args, token);
        }
    }
}
