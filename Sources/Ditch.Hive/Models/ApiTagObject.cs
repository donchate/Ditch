using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// api_tag_object
    /// libraries\plugins\apis\condenser_api\include\steem\plugins\condenser_api\condenser_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ApiTagObject
    {

        /// <summary>
        /// API name: name
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("name")]
        public string Name {get; set;}

        /// <summary>
        /// API name: total_payouts
        /// 
        /// </summary>
        /// <returns>API type: legacy_asset</returns>
        [JsonProperty("total_payouts")]
        public Asset TotalPayouts {get; set;}

        /// <summary>
        /// API name: net_votes
        /// = 0;
        /// </summary>
        /// <returns>API type: int32_t</returns>
        [JsonProperty("net_votes")]
        public int NetVotes {get; set;}

        /// <summary>
        /// API name: top_posts
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("top_posts")]
        public uint TopPosts {get; set;}

        /// <summary>
        /// API name: comments
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("comments")]
        public uint Comments {get; set;}

        /// <summary>
        /// API name: trending
        /// = 0;
        /// </summary>
        /// <returns>API type: uint128</returns>
        [JsonProperty("trending")]
        public UInt128 Trending {get; set;}
    }
}
