using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Ditch.Hive.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ApiAccountObjectMeta
    {
        [JsonProperty("profile")]
        public ApiAccountObjectMetaProfile Profile { get; set; }
        [JsonExtensionData]
        public Dictionary<string, JToken> Custom { get; set; }

        public ApiAccountObjectMeta()
        {
            Custom = new Dictionary<string, JToken>();
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ApiAccountObjectMetaProfile
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("about")]
        public string About { get; set; }
        [JsonProperty("website")]
        public string Website { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("cover_image")]
        public string CoverImage { get; set; }
        [JsonProperty("profile_image")]
        public string ProfileImage { get; set; }
        [JsonProperty("version")]
        public uint Version { get; set; }
    }
}
