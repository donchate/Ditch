using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Ditch.Hive.Models
{
    public class Manabar
    {
        [JsonProperty("current_mana")]
        public ulong CurrentMana { get; set; }

        [JsonProperty("last_update_time")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastUpdateTime { get; set; }
    }
}