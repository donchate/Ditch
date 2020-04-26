using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// _condenser_post_object
    /// https://github.com/steemit/hivemind/blob/master/hive/server/bridge_api/objects.py
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class HivemindPostStats
    {
        [JsonProperty("hide")]
        public bool Hide { get; set; }

        [JsonProperty("gray")]
        public bool Gray{ get; set; }

        [JsonProperty("total_votes")]
        public uint TotalVotes { get; set; }

        [JsonProperty("flag_weight")]
        public uint FlagWeight { get; set; }
    }
}