using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// https://github.com/steemit/hivemind/blob/master/hive/server/bridge_api/methods.py
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetAccountPostsArgs
    {
        public enum SortOptions
        {
            blog,
            feed,
            posts,
            comments,
            replies,
            payout
        }

        [JsonProperty("sort")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SortOptions Sort {get; set;}

        [JsonProperty("account")]
        public string Account { get; set; }
    }
}