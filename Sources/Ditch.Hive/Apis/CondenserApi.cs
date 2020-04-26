﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ditch.Core.JsonRpc;
using Ditch.Hive.JsonRpc;
using Ditch.Hive.Models;
using Ditch.Hive.Operations;
using Newtonsoft.Json;

namespace Ditch.Hive
{
    public partial class OperationManager
    {
        #region system

        public JsonSerializerSettings CondenserJsonSerializerSettings { get; set; }

        /// <summary>
        /// Create and execute custom json-rpc method
        /// </summary>
        /// <typeparam name="T">Custom type. JsonConvert will try to convert json-response to you custom object</typeparam>
        /// <param name="api">Api name</param>
        /// <param name="method">Sets json-rpc "method" field</param>
        /// <param name="data">Sets to json-rpc params field. JsonConvert use`s for convert array of data to string.</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<T>> CondenserBroadcastRequestAsync<T>(string api, string method, object data, CancellationToken token)
        {
            var jsonRpc = JsonRpcRequest.CondenserRequest(CondenserJsonSerializerSettings, api, method, data);
            return ConnectionManager.ExecuteAsync<T>(jsonRpc, CondenserJsonSerializerSettings, token);
        }

        /// <summary>
        /// Create and execute custom json-rpc method
        /// </summary>
        /// <typeparam name="T">Custom type. JsonConvert will try to convert json-response to you custom object</typeparam>
        /// <param name="api">Api name</param>
        /// <param name="method">Sets json-rpc "method" field</param>
        /// <param name="data">Sets to json-rpc params field. JsonConvert use`s for convert array of data to string.</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<T>> CondenserCustomGetRequestAsync<T>(string api, string method, object data, CancellationToken token)
        {
            var jsonRpc = JsonRpcRequest.CondenserRequest(CondenserJsonSerializerSettings, api, method, data);
            return ConnectionManager.RepeatExecuteAsync<T>(jsonRpc, CondenserJsonSerializerSettings, token);
        }

        /// <summary>
        /// Create and execute custom json-rpc method
        /// </summary>
        /// <typeparam name="T">Custom type. JsonConvert will try to convert json-response to you custom object</typeparam>
        /// <param name="api">Api name</param>
        /// <param name="method">Sets json-rpc "method" field</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<T>> CondenserCustomGetRequestAsync<T>(string api, string method, CancellationToken token)
        {
            var jsonRpc = JsonRpcRequest.CondenserRequest(api, method);
            return ConnectionManager.RepeatExecuteAsync<T>(jsonRpc, CondenserJsonSerializerSettings, token);
        }


        /// <summary>
        /// Create and Broadcast a transaction to the network
        /// 
        /// The transaction will be checked for validity in the local database prior to broadcasting. If it fails to apply locally, an error will be thrown and the transaction will not be broadcast.
        /// </summary>
        /// <param name="userPrivateKeys"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="operations"></param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public async Task<JsonRpcResponse<VoidResponse>> CondenserBroadcastOperationsAsync(IList<byte[]> userPrivateKeys, BaseOperation[] operations, CancellationToken token)
        {
            var prop = await CondenserGetDynamicGlobalPropertiesAsync(token).ConfigureAwait(false);
            if (prop.IsError)
                return new JsonRpcResponse<VoidResponse>(prop);

            var transaction = await CreateTransactionAsync(prop.Result, userPrivateKeys, operations, token).ConfigureAwait(false);
            var args = new BroadcastTransactionArgs
            {
                Trx = transaction
            };
            return await CondenserBroadcastTransactionAsync(args, token).ConfigureAwait(false);
        }

        /// <summary>
        /// Create and Broadcast a transaction to the network
        /// 
        /// This call will not return until the transaction is included in a block. 
        /// </summary>
        /// <param name="userPrivateKeys"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <param name="operations"></param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public async Task<JsonRpcResponse<BroadcastTransactionSynchronousReturn>> CondenserBroadcastOperationsSynchronousAsync(IList<byte[]> userPrivateKeys, BaseOperation[] operations, CancellationToken token)
        {
            var prop = await CondenserGetDynamicGlobalPropertiesAsync(token).ConfigureAwait(false);
            if (prop.IsError)
                return new JsonRpcResponse<BroadcastTransactionSynchronousReturn>(prop);

            var transaction = await CreateTransactionAsync(prop.Result, userPrivateKeys, operations, token).ConfigureAwait(false);
            var args = new BroadcastTransactionSynchronousArgs
            {
                Trx = transaction
            };
            return await CondenserBroadcastTransactionSynchronousAsync(args, token).ConfigureAwait(false);
        }

        public async Task<JsonRpcResponse<VerifyAuthorityReturn>> CondenserVerifyAuthorityAsync(IList<byte[]> userPrivateKeys, BaseOperation[] testOps, CancellationToken token)
        {
            var prop = DynamicGlobalPropertyApiObj.Default;
            var transaction = await CreateTransactionAsync(prop, userPrivateKeys, testOps, token).ConfigureAwait(false);
            var args = new VerifyAuthorityArgs
            {
                Trx = transaction
            };
            return await CondenserVerifyAuthorityAsync(args, token).ConfigureAwait(false);
        }

        #endregion


        /// <summary>
        /// API name: broadcast_block
        /// 
        /// </summary>
        /// <param name="args">API type: broadcast_block_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<VoidResponse>> CondenserBroadcastBlockAsync(BroadcastBlockArgs args, CancellationToken token)
        {
            return CondenserBroadcastRequestAsync<VoidResponse>(KnownApiNames.CondenserApi, "broadcast_block", args, token);
        }

        /// <summary>
        /// API name: broadcast_transaction
        /// 
        /// </summary>
        /// <param name="args">API type: broadcast_transaction_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<VoidResponse>> CondenserBroadcastTransactionAsync(BroadcastTransactionArgs args, CancellationToken token)
        {
            return CondenserBroadcastRequestAsync<VoidResponse>(KnownApiNames.CondenserApi, "broadcast_transaction", args, token);
        }

        /// <summary>
        /// API name: broadcast_transaction_synchronous
        /// 
        /// </summary>
        /// <param name="args">API type: broadcast_transaction_synchronous_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: broadcast_transaction_synchronous_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<BroadcastTransactionSynchronousReturn>> CondenserBroadcastTransactionSynchronousAsync(BroadcastTransactionSynchronousArgs args, CancellationToken token)
        {
            return CondenserBroadcastRequestAsync<BroadcastTransactionSynchronousReturn>(KnownApiNames.CondenserApi, "broadcast_transaction_synchronous", args, token);
        }

        /// <summary>
        /// API name: get_account_bandwidth
        /// 
        /// </summary>
        /// <param name="args">API type: get_account_bandwidth_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_account_bandwidth_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetAccountBandwidthReturn>> CondenserGetAccountBandwidthAsync(GetAccountBandwidthArgs args, CancellationToken token)
        {
            return CondenserCustomGetRequestAsync<GetAccountBandwidthReturn>(KnownApiNames.CondenserApi, "get_account_bandwidth", args, token);
        }

        public Task<JsonRpcResponse<long>> CondenserGetAccountCountAsync(CancellationToken token)
        {
            return CondenserCustomGetRequestAsync<long>(KnownApiNames.CondenserApi, "get_account_count", token);
        }

        /// <summary>
        /// API name: get_account_history
        /// 
        /// </summary>
        /// <param name="args">API type: get_account_history_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_account_history_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetAccountHistoryReturn>> CondenserGetAccountHistoryAsync(GetAccountHistoryArgs args, CancellationToken token)
        {
            return CondenserCustomGetRequestAsync<GetAccountHistoryReturn>(KnownApiNames.CondenserApi, "get_account_history", args, token);
        }

        //  "condenser_api.get_account_references",
        //  "condenser_api.get_account_reputations",
        //  "condenser_api.get_account_votes",
        //  "condenser_api.get_accounts",
        //  "condenser_api.get_active_votes",

        /// <summary>
        /// API name: get_active_witnesses
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_active_witnesses_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetActiveWitnessesReturn>> CondenserGetActiveWitnessesAsync(CancellationToken token)
        {
            return CondenserCustomGetRequestAsync<GetActiveWitnessesReturn>(KnownApiNames.CondenserApi, "get_active_witnesses", token);
        }

        //  "condenser_api.get_block",
        public Task<JsonRpcResponse<GetBlockReturn>> CondenserGetBlockAsync(GetBlockArgs args, CancellationToken token)
        {
            return CondenserCustomGetRequestAsync<GetBlockReturn>(KnownApiNames.CondenserApi, "get_block", args, token);
        }
        //  "condenser_api.get_block_header",
        //  "condenser_api.get_blog",
        //  "condenser_api.get_blog_authors",
        //  "condenser_api.get_blog_entries",
        //  "condenser_api.get_chain_properties",
        //  "condenser_api.get_comment_discussions_by_payout",
        //  "condenser_api.get_config",
        //  "condenser_api.get_content",
        //  "condenser_api.get_content_replies",
        //  "condenser_api.get_conversion_requests",
        //  "condenser_api.get_current_median_history_price",
        //  "condenser_api.get_discussions_by_active",
        //  "condenser_api.get_discussions_by_author_before_date",
        //  "condenser_api.get_discussions_by_blog",
        //  "condenser_api.get_discussions_by_cashout",
        //  "condenser_api.get_discussions_by_children",
        //  "condenser_api.get_discussions_by_comments",
        //  "condenser_api.get_discussions_by_created",
        //  "condenser_api.get_discussions_by_feed",
        //  "condenser_api.get_discussions_by_hot",
        //  "condenser_api.get_discussions_by_promoted",
        //  "condenser_api.get_discussions_by_trending",
        //  "condenser_api.get_discussions_by_votes",
        public Task<JsonRpcResponse<GetDynamicGlobalPropertiesReturn>> CondenserGetDynamicGlobalPropertiesAsync(CancellationToken token)
        {
            return CondenserCustomGetRequestAsync<GetDynamicGlobalPropertiesReturn>(KnownApiNames.CondenserApi, "get_dynamic_global_properties", token);
        }
        //  "condenser_api.get_escrow",
        //  "condenser_api.get_expiring_vesting_delegations",
        //  "condenser_api.get_feed",
        //  "condenser_api.get_feed_entries",
        //  "condenser_api.get_feed_history",
        //  "condenser_api.get_follow_count",
        //  "condenser_api.get_followers",
        //  "condenser_api.get_following",
        //  "condenser_api.get_hardfork_version",
        //  "condenser_api.get_key_references",
        //  "condenser_api.get_market_history",
        //  "condenser_api.get_market_history_buckets",
        //  "condenser_api.get_next_scheduled_hardfork",
        //  "condenser_api.get_open_orders",
        //  "condenser_api.get_ops_in_block",
        //  "condenser_api.get_order_book",
        //  "condenser_api.get_owner_history",
        //  "condenser_api.get_post_discussions_by_payout",

        /// <summary>
        /// API name: get_potential_signatures
        /// 
        /// </summary>
        /// <param name="args">API type: get_potential_signatures_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_potential_signatures_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetPotentialSignaturesReturn>> CondenserGetPotentialSignaturesAsync(GetPotentialSignaturesArgs args, CancellationToken token)
        {
            return CondenserCustomGetRequestAsync<GetPotentialSignaturesReturn>(KnownApiNames.CondenserApi, "get_potential_signatures", args, token);
        }

        //  "condenser_api.get_reblogged_by",
        //  "condenser_api.get_recent_trades",
        //  "condenser_api.get_recovery_request",
        //  "condenser_api.get_replies_by_last_update",

        /// <summary>
        /// API name: get_required_signatures
        /// 
        /// </summary>
        /// <param name="args">API type: get_required_signatures_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_required_signatures_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetRequiredSignaturesReturn>> CondenserGetRequiredSignaturesAsync(GetRequiredSignaturesArgs args, CancellationToken token)
        {
            return CondenserCustomGetRequestAsync<GetRequiredSignaturesReturn>(KnownApiNames.CondenserApi, "get_required_signatures", args, token);
        }

        //  "condenser_api.get_reward_fund",
        //  "condenser_api.get_savings_withdraw_from",
        //  "condenser_api.get_savings_withdraw_to",
        //  "condenser_api.get_state",
        //  "condenser_api.get_tags_used_by_author",
        //  "condenser_api.get_ticker",
        //  "condenser_api.get_trade_history",
        //  "condenser_api.get_transaction",

        /// <summary>
        /// API name: get_transaction_hex
        /// Get a hexdump of the serialized binary form of a transaction
        ///
        /// 
        /// </summary>
        /// <param name="args">API type: get_transaction_hex_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: get_transaction_hex_return</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<GetTransactionHexReturn>> CondenserGetTransactionHexAsync(GetTransactionHexArgs args, CancellationToken token)
        {
            return CondenserCustomGetRequestAsync<GetTransactionHexReturn>(KnownApiNames.CondenserApi, "get_transaction_hex", args, token);
        }

        //  "condenser_api.get_trending_tags",
        public Task<JsonRpcResponse<GetTrendingTagsReturn>> CondenserGetTrendingTagsAsync(GetTrendingTagsArgs args, CancellationToken token)
        {
            return CondenserCustomGetRequestAsync<GetTrendingTagsReturn>(KnownApiNames.CondenserApi, "get_trending_tags", args, token);
        }
        //  "condenser_api.get_version",
        //  "condenser_api.get_vesting_delegations",
        //  "condenser_api.get_volume",
        //  "condenser_api.get_withdraw_routes",
        //  "condenser_api.get_witness_by_account",
        //  "condenser_api.get_witness_count",
        //  "condenser_api.get_witness_schedule",
        //  "condenser_api.get_witnesses",
        //  "condenser_api.get_witnesses_by_vote",
        //  "condenser_api.lookup_account_names",
        //  "condenser_api.lookup_accounts",
        //  "condenser_api.lookup_witness_accounts",
        //  "condenser_api.verify_account_authority",

        /// <summary>
        /// API name: verify_authority
        /// 
        /// </summary>
        /// <param name="args">API type: verify_authority_args</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: verify_authority_return true of the @ref trx has all of the required signatures, otherwise throws an exception</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public Task<JsonRpcResponse<VerifyAuthorityReturn>> CondenserVerifyAuthorityAsync(VerifyAuthorityArgs args, CancellationToken token)
        {
            return CondenserCustomGetRequestAsync<VerifyAuthorityReturn>(KnownApiNames.CondenserApi, "verify_authority", args, token);
        }
    }
}
