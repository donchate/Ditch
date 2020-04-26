using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// list_change_recovery_account_requests_return
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ListChangeRecoveryAccountRequestsReturn
    {

        /// <summary>
        /// API name: requests
        /// 
        /// </summary>
        /// <returns>API type: api_change_recovery_account_request_object</returns>
        [JsonProperty("requests")]
        public ApiChangeRecoveryAccountRequestObject[] Requests {get; set;}
    }
}
