using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// get_market_history_return
    /// libraries\plugins\apis\market_history_api\include\steem\plugins\market_history_api\market_history_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetMarketHistoryReturn
    {

        /// <summary>
        /// API name: buckets
        /// 
        /// </summary>
        /// <returns>API type: market_history::bucket_object</returns>
        [JsonProperty("buckets")]
        public object[] Buckets {get; set;}
    }
}
