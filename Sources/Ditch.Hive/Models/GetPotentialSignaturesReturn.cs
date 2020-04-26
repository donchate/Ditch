using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// get_potential_signatures_return
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetPotentialSignaturesReturn : GetRequiredSignaturesReturn
    {
    }
}
