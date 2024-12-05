using VSATicket.Domain.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VSATicket.Application.Interfaces;

namespace VSATicket.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUserAsync(AppUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<AppUser?> GetUserByNameAsync(string userName)
        {
            return await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<SignInResult> PasswordSignInAsync(string userName, string password)
        {
            return await _signInManager.PasswordSignInAsync(userName, password, false, false);
        }

        public async Task AddToRoleAsync(AppUser user, string role)
        {
            await _userManager.AddToRoleAsync(user, role);
        }
    }
}
