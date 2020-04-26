﻿using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// owner_authority_history_api_obj
    /// steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class OwnerAuthorityHistoryApiObj
    {

        // bdType : owner_authority_history_id_type
        [JsonProperty("id")]
        public object Id { get; set; }

        // bdType : account_name_type
        [JsonProperty("account")]
        public string Account { get; set; }

        // bdType : authority
        [JsonProperty("previous_owner_authority")]
        public Authority PreviousOwnerAuthority { get; set; }

        // bdType : time_point_sec
        [JsonProperty("last_valid_time")]
        public TimePointSec LastValidTime { get; set; }
    }
}