using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ditch.Hive.Models
{

    [JsonObject(MemberSerialization.OptIn)]
    public class GetRankedPostsArgs
    {
        public enum SortOptions
        {
            trending,
            hot,
            created,
            promoted,
            payout,
            payout_comments,
            muted
        }

        [JsonProperty("sort")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SortOptions Sort {get; set;}

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("observer")]
        public string Observer { get; set; }
    }
}
