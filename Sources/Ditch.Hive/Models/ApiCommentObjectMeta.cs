using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Ditch.Hive.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ApiCommentObjectMeta
    {
        [JsonProperty("app")]
        public string App { get; set; }
        [JsonProperty("format")]
        public string Format { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("tags")]
        public string[] Tags { get; set; }
        [JsonProperty("users")]
        public string[] Users { get; set; }
        [JsonProperty("links")]
        public string[] Links { get; set; }
        [JsonProperty("image")]
        public string[] Images { get; set; }
        [JsonExtensionData]
        public Dictionary<string, JToken> custom { get; set; }

        public ApiCommentObjectMeta()
        {
            custom = new Dictionary<string, JToken>();
        }
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
