using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.Eosio.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PermissionLevelWeight
    {
        [JsonProperty("permission")]
        public PermissionLevel Permission {get; set;}

        [JsonProperty("weight")]
        public ushort Weight {get; set;}

    }
}
