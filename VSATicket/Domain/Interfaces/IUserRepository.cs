using VSATicket.Domain.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace VSATicket.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> CreateUserAsync(AppUser user, string password);
        Task<AppUser?> GetUserByNameAsync(string userName);
        Task<SignInResult> PasswordSignInAsync(string userName, string password);
        Task AddToRoleAsync(AppUser user, string role);
    }
}
