using Ditch.Steem.Models.Objects;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Return
{
    /// <summary>
    /// get_replies_by_last_update_return
    /// libraries\plugins\apis\tags_api\include\steem\plugins\tags_api\tags_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class GetRepliesByLastUpdateReturn : DiscussionQueryResult
    {
    }
}
