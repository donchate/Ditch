using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    [JsonConverter(typeof(EnumConverter))]
    public enum WithdrawRouteType
    {
        Incoming,
        Outgoing,
        All
    }
}
