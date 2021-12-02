using SCP_682.JsonModels;

using SCPData;

using System.Threading.Tasks;

namespace SCP_682.Service
{
    public interface IUserData
    {
        public bool CheckUser(string phone);
        public Task<List<LastPoint>> GetLastPoints(string phone);
        public Task<List<FUser>> GetLastIPoints(string phone);
        public Task<User> CreateUserAsync(string name, string phone, string photo, bool admin, string familyID);
        public Task<User> UpdateUserAsync(string phone, string famalyPhone);
        public Task<User> UpdateUserAsync(string phone, double latitude, double longitude, int battery);
        public Task<List<User>> GetFamilyAsync(string phone);
        public Task<List<SafeZone>> GetSafeZoneAsync(string phone);
        public Task<User> GetUserAsync(string phone);
        public Task<SafeZone> SetSafeZone(JCoordinatesPack pack);
    }
}
