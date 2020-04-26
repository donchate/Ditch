using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// list_votes_return
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ListVotesReturn
    {

        /// <summary>
        /// API name: votes
        /// 
        /// </summary>
        /// <returns>API type: api_comment_vote_object</returns>
        [JsonProperty("votes")]
        public ApiCommentVoteObject[] Votes {get; set;}
    }
}
