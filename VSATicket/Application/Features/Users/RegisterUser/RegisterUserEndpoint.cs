using Microsoft.AspNetCore.Mvc;
using VSATicket.Application.Features.Users.RegisterUser;

namespace VSATicket.Application.Features.Users.RegisterUser
{
    [ApiController]
    [Route("api/auth")]
    public class RegisterUserEndpoint : ControllerBase
    {
        private readonly RegisterUserHandler _handler;

        public RegisterUserEndpoint(RegisterUserHandler handler)
        {
            _handler = handler;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command)
        {
            var result = await _handler.HandleAsync(command);

            if (result.Succeeded)
                return Ok(new { Message = "User registered successfully" });

            return BadRequest(result.Errors);
        }
    }
}
