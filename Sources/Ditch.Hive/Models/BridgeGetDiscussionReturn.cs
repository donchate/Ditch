using Ditch.Hive.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// Hivemind response to bridge.get_discussion
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class BridgeGetDiscussionReturn
    {
        /// <summary>
        /// This api response uses the author/perm as key and HivemindPost as value
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JToken> Response { get; set; }

        [JsonIgnore]
        public HivemindPost[] Replies { get; set; }

        public BridgeGetDiscussionReturn()
        {
            Response = new Dictionary<string, JToken>();
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        [OnDeserialized]
        internal void ConvertReplies(StreamingContext context)
        {
            var serializer = new JsonSerializer();
            serializer.Converters.Add(new NewJsonConverter());

            var converted = new List<HivemindPost>();
            foreach(KeyValuePair<string, JToken> item in Response)
            {
                converted.Add(item.Value.ToObject<HivemindPost>(serializer));
            }
            Replies = converted.ToArray();
        }
    }
}
