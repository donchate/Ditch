using System;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// witness_api_obj
    /// libraries\app\include\steemit\app\steem_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class WitnessApiObj
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: witness_id_type</returns>
        [JsonProperty("id")]
        public object Id { get; set; }

        /// <summary>
        /// API name: owner
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("owner")]
        public string Owner { get; set; }

        /// <summary>
        /// API name: created
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("created")]
        public TimePointSec Created { get; set; }

        /// <summary>
        /// API name: url
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// API name: total_missed
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("total_missed")]
        public uint TotalMissed { get; set; }

        /// <summary>
        /// API name: last_aslot
        /// = 0;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("last_aslot")]
        public ulong LastAslot { get; set; }

        /// <summary>
        /// API name: last_confirmed_block_num
        /// = 0;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("last_confirmed_block_num")]
        public ulong LastConfirmedBlockNum { get; set; }

        /// <summary>
        /// API name: pow_worker
        /// = 0;
        /// </summary>
        /// <returns>API type: uint64_t</returns>
        [JsonProperty("pow_worker")]
        public ulong PowWorker { get; set; }

        /// <summary>
        /// API name: signing_key
        /// 
        /// </summary>
        /// <returns>API type: public_key_type</returns>
        [JsonProperty("signing_key")]
        public PublicKeyType SigningKey { get; set; }

        /// <summary>
        /// API name: props
        /// 
        /// </summary>
        /// <returns>API type: chain_properties</returns>
        [JsonProperty("props")]
        public ChainProperties Props { get; set; }

        /// <summary>
        /// API name: sbd_exchange_rate
        /// 
        /// </summary>
        /// <returns>API type: price</returns>
        [JsonProperty("sbd_exchange_rate")]
        public Price SbdExchangeRate { get; set; }

        /// <summary>
        /// API name: last_sbd_exchange_update
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("last_sbd_exchange_update")]
        public TimePointSec LastSbdExchangeUpdate { get; set; }

        /// <summary>
        /// API name: votes
        /// 
        /// </summary>
        /// <returns>API type: share_type</returns>
        [JsonProperty("votes")]
        public object Votes { get; set; }

        /// <summary>
        /// API name: virtual_last_update
        /// 
        /// </summary>
        /// <returns>API type: uint128</returns>
        [JsonProperty("virtual_last_update")]
        public UInt128 VirtualLastUpdate { get; set; }

        /// <summary>
        /// API name: virtual_position
        /// 
        /// </summary>
        /// <returns>API type: uint128</returns>
        [JsonProperty("virtual_position")]
        public UInt128 VirtualPosition { get; set; }

        /// <summary>
        /// API name: virtual_scheduled_time
        /// 
        /// </summary>
        /// <returns>API type: uint128</returns>
        [JsonProperty("virtual_scheduled_time")]
        public UInt128 VirtualScheduledTime { get; set; }

        /// <summary>
        /// API name: last_work
        /// 
        /// </summary>
        /// <returns>API type: digest_type</returns>
        [JsonProperty("last_work")]
        public object LastWork { get; set; }

        /// <summary>
        /// API name: running_version
        /// 
        /// </summary>
        /// <returns>API type: version</returns>
        [JsonProperty("running_version")]
        public Version RunningVersion { get; set; }

        /// <summary>
        /// API name: hardfork_version_vote
        /// 
        /// </summary>
        /// <returns>API type: hardfork_version</returns>
        [JsonProperty("hardfork_version_vote")]
        public object HardforkVersionVote { get; set; }

        /// <summary>
        /// API name: hardfork_time_vote
        /// 
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("hardfork_time_vote")]
        public TimePointSec HardforkTimeVote { get; set; }
    }
}
