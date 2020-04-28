namespace Ditch.Hive.Models
{
    public class ApiNode
    {
        public string Url { get; set; }
        public string Version { get; set; }
        public string Owner { get; set; }
        public byte Score { get; set; }
        public bool Active { get; set; } = true;
    }
}