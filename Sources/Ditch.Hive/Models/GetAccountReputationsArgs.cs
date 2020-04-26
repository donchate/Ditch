using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// get_account_reputations_args
    /// libraries\plugins\apis\follow_api\include\steem\plugins\follow_api\follow_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetAccountReputationsArgs
    {

        /// <summary>
        /// API name: account_lower_bound
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("account_lower_bound")]
        public string AccountLowerBound {get; set;}

        /// <summary>
        /// API name: limit
        /// = 1000;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("limit")]
        public uint Limit {get; set;}
    }
}
