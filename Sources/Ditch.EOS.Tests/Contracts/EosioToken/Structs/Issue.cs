using Newtonsoft.Json;
using Ditch.EOS;
using Ditch.Core.Models;
using Ditch.EOS.Models;

namespace Ditch.EOS.Contracts.EosioToken.Structs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Issue
    {
        [JsonProperty("to")]
        public BaseName To {get; set;}

        [JsonProperty("quantity")]
        public Asset Quantity {get; set;}

        [JsonProperty("memo")]
        public string Memo {get; set;}

    }
}
