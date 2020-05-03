using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Ditch.Hive.Models
{
    public class ApiAccountObjectMeta
    {
        [JsonProperty("about")]
        public string About { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("profile")]
        public Dictionary<string, string> Profile { get; set; }
        [JsonProperty("website")]
        public string Website { get; set; }
        [JsonExtensionData]
        public Dictionary<string, JToken> Custom { get; set; }

        public ApiAccountObjectMeta()
        {
            Custom = new Dictionary<string, JToken>();
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
