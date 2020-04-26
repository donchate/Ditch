using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// enum_virtual_ops_return
    /// libraries\plugins\apis\account_history_api\include\steem\plugins\account_history_api\account_history_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class EnumVirtualOpsReturn
    {

        /// <summary>
        /// API name: ops
        /// 
        /// </summary>
        /// <returns>API type: api_operation_object</returns>
        [JsonProperty("ops")]
        public ApiOperationObject[] Ops { get; set; }

        /// <summary>
        /// API name: next_block_range_begin
        /// = 0;
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("next_block_range_begin")]
        public uint NextBlockRangeBegin { get; set; }
    }
}
