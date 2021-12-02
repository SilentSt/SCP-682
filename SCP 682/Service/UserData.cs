using Newtonsoft.Json.Linq;

using SCP_682.JsonModels;

using SCPData;

using System.Linq;
using System.Threading.Tasks;

namespace SCP_682.Service
{
    public class UserData : IUserData
    {
        public SCPContext context = new SCPContext();
        public UserData()
        {
            context.Database.EnsureCreatedAsync();
        }
        public bool CheckUser(string phone)
        {
            return context.Users.Any(u => u.Phone == phone);
        }

        public async Task<User> CreateUserAsync(string name, string phone, string photo, bool admin, string familyID)
        {

            var user = new User() { Name = name, Phone = phone, Photo = photo, Admin = admin, FamilyID = familyID };
            if (admin)
            {
                user.FamilyID = Guid.NewGuid().ToString();
            }
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;

        }

        public async Task<User> UpdateUserAsync(string phone, string familyID)
        {
            var user = await GetUserAsync(phone);

            user.FamilyID = familyID;
            context.Users.Update(user);
            await context.SaveChangesAsync();
            return user;

        }

        public async Task<List<User>> GetFamilyAsync(string phone)
        {
            var user = await GetUserAsync(phone);
            if (user.FamilyID == null)
            {
                return null;
            }

            return context.Users.Where(x => x.FamilyID == user.FamilyID).ToList();

        }

        public async Task<User> GetUserAsync(string phone)
        {

            return await context.Users.FindAsync(phone);

        }

        public async Task<User> UpdateUserAsync(string phone, double latitude, double longitude, int battery)
        {
            var user = await GetUserAsync(phone);
            var time = DateTime.UtcNow;
            var point = new Point() { UserPhone = phone, Latitude = latitude, Longitude = longitude, Time = time, Battery = battery };
            await context.Coordinates.AddAsync(point);
            await context.SaveChangesAsync();

            return user;
        }

        public async Task<List<SafeZone>> GetSafeZoneAsync(string phone)
        {
            var user = await GetUserAsync(phone);
            var zones = context.SafeZones.Where(x => x.FamilyID == user.FamilyID).ToList();
            return zones;
        }

        public async Task<SafeZone> SetSafeZone(JCoordinatesPack pack)
        {
            var zone = JArray.FromObject(pack.points).ToString();
            var Safe = new SafeZone() { FamilyID = pack.familyID, Color = pack.color, Zone = zone };
            await context.SafeZones.AddAsync(Safe);
            await context.SaveChangesAsync();
            return Safe;
        }

        public async Task<List<LastPoint>> GetLastPoints(string phone)
        {
            var user = await GetUserAsync(phone);
            var fam = context.Users.Where(x => x.FamilyID == user.FamilyID).ToList();
            var list = new List<LastPoint>();
            foreach (var usr in fam)
            {
                if (context.Coordinates.Any(x => x.UserPhone == usr.Phone))
                {
                    var point = new LastPoint() { point = context.Coordinates?.OrderByDescending(f => f.Time).First(x => x.UserPhone == usr.Phone), Phone = usr.Phone, Name = usr.Name };
                    list.Add(point);
                }
            }
            return list;
        }
        public async Task<List<FUser>> GetLastIPoints(string phone)
        {
            var user = await GetUserAsync(phone);
            var fam = context.Users.Where(x => x.FamilyID == user.FamilyID).ToList();
            var list = new List<FUser>();
            foreach (var usr in fam)
            {
                if (context.Coordinates.Any(x => x.UserPhone == usr.Phone))
                {
                    var point = new FUser() { Name = usr.Name, Phone = usr.Phone, Image = usr.Photo };
                    list.Add(point);
                }
            }
            return list;
        }
    }
}
