using SCP_682.JsonModels;

using SCPData;

using System.Linq;

namespace SCP_682.Service
{
    public static class Assist
    {
        public static JUser Convert(this User user)
        {
            return new JUser() { Name = user.Name, Phone = user.Phone,/* Photo = user.Photo,*/ Admin = user.Admin };
        }
    }
}
