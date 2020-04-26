﻿using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// category_api_obj
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CategoryApiObj
    {

        // bdType : category_id_type
        [JsonProperty("id")]
        public object Id { get; set; }

        // bdType : string
        [JsonProperty("name")]
        public string Name { get; set; }

        // bdType : share_type
        [JsonProperty("abs_rshares")]
        public object AbsRshares { get; set; }

        // bdType : asset
        [JsonProperty("total_payouts")]
        public Asset TotalPayouts { get; set; }

        // bdType : uint32_t
        [JsonProperty("discussions")]
        public uint Discussions { get; set; }

        // bdType : time_point_sec
        [JsonProperty("last_update")]
        public TimePointSec LastUpdate { get; set; }
    }

}
