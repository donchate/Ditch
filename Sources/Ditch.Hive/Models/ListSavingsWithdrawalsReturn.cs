using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// list_savings_withdrawals_return
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ListSavingsWithdrawalsReturn
    {

        /// <summary>
        /// API name: withdrawals
        /// 
        /// </summary>
        /// <returns>API type: api_savings_withdraw_object</returns>
        [JsonProperty("withdrawals")]
        public ApiSavingsWithdrawObject[] Withdrawals {get; set;}
    }
}
