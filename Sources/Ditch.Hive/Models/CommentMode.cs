using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    [JsonConverter(typeof(EnumConverter))]
    public enum CommentMode
    {
        FirstPayout,
        SecondPayout,
        Archived
    }
}