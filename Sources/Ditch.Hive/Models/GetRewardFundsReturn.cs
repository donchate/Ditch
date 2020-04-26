using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// get_reward_funds_return
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetRewardFundsReturn
    {

        /// <summary>
        /// API name: funds
        /// 
        /// </summary>
        /// <returns>API type: api_reward_fund_object</returns>
        [JsonProperty("funds")]
        public ApiRewardFundObject[] Funds {get; set;}
    }
}
