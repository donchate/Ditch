using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// get_transaction_args
    /// libraries\plugins\apis\account_history_api\include\steem\plugins\account_history_api\account_history_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetTransactionArgs
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: transaction_id_type</returns>
        [JsonProperty("id")]
        public string Id {get; set;}
    }
}
