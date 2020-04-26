using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <inheritdoc />
    /// <summary>
    /// get_blog_entries_args
    /// libraries\plugins\apis\follow_api\include\steem\plugins\follow_api\follow_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetBlogEntriesArgs : GetFeedEntriesArgs
    {
    }
}
