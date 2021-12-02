using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using SCP_682.Service;

using SCPData;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SCP_682.JsonModels;

namespace SCP_682.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        //update photo, update name, 
        private readonly ILogger<UserController> _logger;
        private IUserData users;

        public UserController(ILogger<UserController> logger, UserData data)
        {
            _logger = logger;
            users = data;
        }
        

        [HttpPost("user")]
        public async Task<IActionResult> CreateUser([FromBody] JUser user)
        {
            if (users.CheckUser(user.Phone))
            {
                return new ContentResult() { Content = JObject.FromObject(await users.GetUserAsync(user.Phone)).ToString(), StatusCode = 201 };
            }
            var ruser = await users.CreateUserAsync(user.Name, user.Phone, user.Photo, user.Admin, user.FamilyID);
            return new ContentResult() { Content = "{ 'familyID':'"+ruser.FamilyID+"'}", StatusCode = 200 };
        }
        [HttpGet("user")]
        public async Task<IActionResult> GetUser(string phone)
        {
            if (users.CheckUser(phone))
            {
                return new ContentResult() { Content = JObject.FromObject(await users.GetUserAsync(phone)).ToString(), StatusCode = 201 };
            }
            return new BadRequestResult();
        }
        
        [HttpPatch("updatecoordinates")]
        public async Task<IActionResult> UpdateCoordinates([FromBody] JCoordinates coordinates)
        {
            await users.UpdateUserAsync(coordinates.phone, coordinates.latitude, coordinates.longitude, coordinates.Battery);
            var lastPoints = await users.GetLastPoints(coordinates.phone);
            return new ContentResult() { Content = JArray.FromObject(lastPoints).ToString(),StatusCode=200};
        }
        
        [HttpGet("safezone")]
        public async Task<IActionResult> GetSafeZone(string phone)
        {
            var history = await users.GetSafeZoneAsync(phone);
            return new ContentResult() { Content = JObject.FromObject(history).ToString(), StatusCode = 200 };
        }
        
        [HttpGet("family")]
        public async Task<IActionResult> GetFamily(string phone)
        {
            var lastPoints = await users.GetLastIPoints(phone);
            return new ContentResult() { Content = JArray.FromObject(lastPoints).ToString(), StatusCode = 200 };
        }

        [HttpPost("setsafezone")]
        public async Task<IActionResult> Post([FromBody] JCoordinatesPack jCoordinates)
        {
            await users.SetSafeZone(jCoordinates);
            return Ok();
        }
        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return new ContentResult() { Content = "Pong", StatusCode = 200 };
        }

    }
}
