using Microsoft.AspNetCore.Identity;

namespace WebServerAPI.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FristName { get; set; }

        public string LastName { get; set; }
    }
}
