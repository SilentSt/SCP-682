namespace SCP_682.JsonModels
{
    [JsonObject]
    public class JCoordinates
    {
        [JsonRequired]
        public string phone { get; set; }
        [JsonRequired]
        public double latitude { get; set; }
        [JsonRequired]
        public double longitude { get; set; }
        [JsonRequired]
        public int Battery { get; set; }
    }
}
