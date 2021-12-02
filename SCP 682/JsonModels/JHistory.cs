
namespace SCP_682.JsonModels
{
    public class JHistory
    {
        public JUser user { get; set; }
        public List<JTPoint> points { get; set; }
    }
    [JsonObject]
    public class JTPoint
    {
        [JsonRequired]
        public double latitude { get; set; }
        [JsonRequired]
        public double longitude { get; set; }
        [JsonRequired]
        public DateTime time { get; set; }
        [JsonRequired]
        public int battery { get; set; }
    }
}
