using Microsoft.AspNetCore.Mvc;
using VSATicket.Application.Features.Users.LoginUser;

namespace VSATicket.Application.Features.Users.LoginUser
{
    [ApiController]
    [Route("api/auth")]
    public class LoginUserEndpoint : ControllerBase
    {
        private readonly LoginUserHandler _handler;

        public LoginUserEndpoint(LoginUserHandler handler)
        {
            _handler = handler;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserCommand command)
        {
            var token = await _handler.HandleAsync(command);

            if (token == null)
                return Unauthorized(new { Message = "Invalid username or password" });

            return Ok(new { Token = token });
        }
    }
}
