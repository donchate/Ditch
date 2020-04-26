﻿using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.JsonRpc;
using Ditch.Hive.Models;

namespace Ditch.Hive
{
    /// <summary>
    /// witness_api
    /// libraries\plugins\apis\witness_api\include\steem\plugins\witness_api\witness_api.hpp
    /// </summary>
    public partial class OperationManager
    {
        /// <summary>
        /// API name: get_account_bandwidth
        /// 
        /// </summary>
        /// <param name="args">API type: get_account_bandwidth_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_account_bandwidth_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetAccountBandwidthReturn>> GetAccountBandwidthAsync(GetAccountBandwidthArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetAccountBandwidthReturn>(KnownApiNames.WitnessApi, "get_account_bandwidth", args, token);
        }

        /// <summary>
        /// API name: get_reserve_ratio
        /// 
        /// </summary>
        /// <param name="args">API type: get_reserve_ratio_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_reserve_ratio_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetReserveRatioReturn>> GetReserveRatioAsync(GetReserveRatioArgs args, CancellationToken token)
        {
            return CustomGetRequestAsync<GetReserveRatioReturn>(KnownApiNames.WitnessApi, "get_reserve_ratio", args, token);
        }
    }
}
