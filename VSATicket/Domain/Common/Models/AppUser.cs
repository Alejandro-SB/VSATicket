using Microsoft.AspNetCore.Identity;

namespace VSATicket.Domain.Common.Models
{
    public class AppUser : IdentityUser
    {
        public override string UserName { get; set; } 
        public override string Email { get; set; } 
        public string Role { get; set; } 
    }
}
