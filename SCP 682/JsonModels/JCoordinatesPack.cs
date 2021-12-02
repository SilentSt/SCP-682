

namespace SCP_682.JsonModels
{
    [JsonObject]
    public class JCoordinatesPack
    {
        [JsonRequired]
        public string phone { get; set; }
        [JsonRequired]
        public string familyID { get; set; }
        [JsonRequired]
        public string color { get; set; }
        [JsonRequired]
        public List<JPoint> points { get; set; }
    }
    [JsonObject]
    public class JPoint
    {
        [JsonRequired]
        public double latitude { get; set; }
        [JsonRequired]
        public double longitude { get; set; }
    }
}
