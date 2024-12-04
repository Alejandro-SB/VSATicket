using Microsoft.AspNetCore.Mvc;
using VSATicket.Application.Features.Tickets.ResolveTicket;

namespace VSATicket.Application.Features.Tickets.ResolveTicket
{
    [ApiController]
    [Route("api/tickets")]
    public class ResolveTicketEndpoint : ControllerBase
    {
        private readonly ResolveTicketHandler _handler;

        public ResolveTicketEndpoint(ResolveTicketHandler handler)
        {
            _handler = handler;
        }

        [HttpPatch("{id}/resolve")]
        public async Task<IActionResult> ResolveTicket(int id, [FromBody] ResolveTicketCommand command)
        {
            var result = await _handler.HandleAsync(id, command);

            if (!result)
                return NotFound(new { Message = "Ticket not found" });

            return NoContent();
        }
    }
}
