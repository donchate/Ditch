using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// broadcast_block_args
    /// libraries\plugins\apis\network_broadcast_api\include\steem\plugins\network_broadcast_api\network_broadcast_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class BroadcastBlockArgs
    {

        /// <summary>
        /// API name: block
        /// 
        /// </summary>
        /// <returns>API type: signed_block</returns>
        [JsonProperty("block")]
        public SignedBlock Block {get; set;}
    }
}
