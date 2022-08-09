using Microsoft.AspNetCore.Identity;

namespace Education.Core.Entities
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
        public bool IsActive { get; set; }
    }
}
