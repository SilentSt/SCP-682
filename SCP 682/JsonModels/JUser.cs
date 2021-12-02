
using SCPData;

namespace SCP_682.JsonModels
{
    [JsonObject]
    public class JUser
    {
        [JsonRequired]
        public string Name { get; set; }
        [JsonRequired]
        public string Phone { get; set; }
        [JsonRequired]
        public string Photo { get; set; }
        [JsonRequired]
        public bool Admin { get; set; }
        public string? FamilyID { get; set; }
    }

    
}
