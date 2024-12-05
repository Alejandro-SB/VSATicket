using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VSATicket.Application.Features.Tickets.CreateTicket;

namespace VSATicket.Application.Features.Tickets.CreateTicket
{
    [ApiController]
    [Route("api/tickets")]
    public class CreateTicketEndpoint : ControllerBase
    {
        private readonly CreateTicketHandler _handler;

        public CreateTicketEndpoint(CreateTicketHandler handler)
        {
            _handler = handler;
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketCommand command)
        {
            await _handler.HandleAsync(command);

            return CreatedAtAction("GetTicketById", "GetTicketEndpoints", new { id = command.Title }, command);
        }
    }
}
