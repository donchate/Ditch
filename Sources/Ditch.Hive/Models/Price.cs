﻿using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// price
    /// steem-0.19.1\libraries\protocol\include\steemit\protocol\asset.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Price
    {

        // bdType : asset
        [JsonProperty("base")]
        public Asset Base { get; set; }

        // bdType : asset
        [JsonProperty("quote")]
        public Asset Quote { get; set; }
    }
}