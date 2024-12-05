using VSATicket.Domain.Common.Models;
using VSATicket.Application.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace VSATicket.Application.Features.Users.RegisterUser
{
    public class RegisterUserHandler
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IdentityResult> HandleAsync(RegisterUserCommand command)
        {
            var user = new AppUser
            {
                UserName = command.UserName,
                Email = command.Email,
                Role = "user" 
            };

            var result = await _userRepository.CreateUserAsync(user, command.Password);

            if (result.Succeeded)
            {
                await _userRepository.AddToRoleAsync(user, "user");
            }

            return result;
        }
    }
}
