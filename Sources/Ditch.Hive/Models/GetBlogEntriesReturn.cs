using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// get_blog_entries_return
    /// libraries\plugins\apis\follow_api\include\steem\plugins\follow_api\follow_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetBlogEntriesReturn
    {

        /// <summary>
        /// API name: blog
        /// 
        /// </summary>
        /// <returns>API type: blog_entry</returns>
        [JsonProperty("blog")]
        public BlogEntry[] Blog {get; set;}
    }
}
