using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// discussion_query_result
    /// libraries\plugins\apis\tags_api\include\steem\plugins\tags_api\tags_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class DiscussionQueryResult
    {

        /// <summary>
        /// API name: discussions
        /// 
        /// </summary>
        /// <returns>API type: discussion</returns>
        [JsonProperty("discussions")]
        public Discussion[] Discussions {get; set;}
    }
}
