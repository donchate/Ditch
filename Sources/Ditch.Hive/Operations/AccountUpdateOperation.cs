﻿using Ditch.Core.Attributes;
using Ditch.Hive.Models;
using Newtonsoft.Json;

namespace Ditch.Hive.Operations
{
    /// <inheritdoc />
    /// <summary>
    /// Update an existing account
    /// This operation is used to update an existing account. It can be used to update the authorities, or adjust the options on the account.
    /// See @ref account_object::options_type for the options which may be updated.
    /// 
    /// account_update_operation
    /// libraries\protocol\include\steemit\protocol\steem_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class AccountUpdateOperation : BaseOperation
    {
        public const string OperationName = "account_update_operation";
        public override string TypeName => OperationName;

        public override OperationType Type => OperationType.AccountUpdate;

        /// <summary>
        /// API name: account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [MessageOrder(20)]
        [JsonProperty("account")]
        public string Account { get; set; }

        /// <summary>
        /// API name: owner
        /// 
        /// </summary>
        /// <returns>API type: authority</returns>
        [MessageOrder(30)]
        [JsonProperty("owner", NullValueHandling = NullValueHandling.Ignore)]
        public Authority Owner { get; set; }

        /// <summary>
        /// API name: active
        /// 
        /// </summary>
        /// <returns>API type: authority</returns>
        [MessageOrder(40)]
        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        public Authority Active { get; set; }

        /// <summary>
        /// API name: posting
        /// 
        /// </summary>
        /// <returns>API type: authority</returns>
        [MessageOrder(50)]
        [JsonProperty("posting", NullValueHandling = NullValueHandling.Ignore)]
        public Authority Posting { get; set; }

        /// <summary>
        /// API name: memo_key
        /// 
        /// </summary>
        /// <returns>API type: public_key_type</returns>
        [MessageOrder(60)]
        [JsonProperty("memo_key")]
        public PublicKeyType MemoKey { get; set; }

        /// <summary>
        /// API name: json_metadata
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [MessageOrder(70)]
        [JsonProperty("json_metadata")]
        public string JsonMetadata { get; set; }

        public AccountUpdateOperation(string account, PublicKeyType memoKey, string jsonMetadata)
        {
            Account = account;
            MemoKey = memoKey;
            JsonMetadata = jsonMetadata;
        }
    }
}
