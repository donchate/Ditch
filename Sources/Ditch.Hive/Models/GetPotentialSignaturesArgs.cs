using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// get_potential_signatures_args
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetPotentialSignaturesArgs
    {

        /// <summary>
        /// API name: trx
        /// 
        /// </summary>
        /// <returns>API type: signed_transaction</returns>
        [JsonProperty("trx")]
        public SignedTransaction Trx { get; set; }
    }
}
