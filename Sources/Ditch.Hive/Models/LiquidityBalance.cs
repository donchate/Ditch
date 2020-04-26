using Newtonsoft.Json;

namespace Ditch.Hive.Models
{

    [JsonObject(MemberSerialization.OptIn)]
    public class LiquidityBalance
    {
        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }
    }
}