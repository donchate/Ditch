using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// list_accounts_return
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ListAccountsReturn
    {

        /// <summary>
        /// API name: accounts
        /// 
        /// </summary>
        /// <returns>API type: api_account_object</returns>
        [JsonProperty("accounts")]
        public ApiAccountObject[] Accounts {get; set;}
    }
}
