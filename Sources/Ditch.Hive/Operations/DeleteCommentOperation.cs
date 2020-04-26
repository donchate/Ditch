﻿using Ditch.Core.Attributes;
using Newtonsoft.Json;

namespace Ditch.Hive.Operations
{
    /// <inheritdoc />
    /// <summary>
    /// delete_comment_operation
    /// libraries\protocol\include\steemit\protocol\steem_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class DeleteCommentOperation : BaseOperation
    {
        public const string OperationName = "delete_comment_operation";
        public override string TypeName => OperationName;
        
        public override OperationType Type => OperationType.DeleteComment;

        /// <summary>
        /// API name: author
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("author")]
        [MessageOrder(20)]
        public string Author { get; set; }

        /// <summary>
        /// API name: permlink
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("permlink")]
        [MessageOrder(30)]
        public string Permlink { get; set; }


        public DeleteCommentOperation(string author, string permlink)
        {
            Author = author;
            Permlink = permlink;
        }
    }
}
