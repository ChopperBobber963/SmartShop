using Microsoft.AspNetCore.Identity;

namespace SmartShop.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
