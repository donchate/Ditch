using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// get_tags_used_by_author_args
    /// libraries\plugins\apis\tags_api\include\steem\plugins\tags_api\tags_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetTagsUsedByAuthorArgs
    {

        /// <summary>
        /// API name: author
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("author")]
        public string Author {get; set;}
    }
}
