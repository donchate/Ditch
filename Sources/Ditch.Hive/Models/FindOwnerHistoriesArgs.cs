using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// find_owner_histories_args
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class FindOwnerHistoriesArgs
    {

        /// <summary>
        /// API name: owner
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("owner")]
        public string Owner {get; set;}
    }
}
