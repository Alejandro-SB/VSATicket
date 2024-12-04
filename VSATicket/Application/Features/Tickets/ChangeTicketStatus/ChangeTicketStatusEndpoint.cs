using Microsoft.AspNetCore.Mvc;
using VSATicket.Application.Features.Tickets.ChangeTicketStatus;

namespace VSATicket.Application.Features.Tickets.ChangeTicketStatus
{
    [ApiController]
    [Route("api/tickets")]
    public class ChangeTicketStatusEndpoint : ControllerBase
    {
        private readonly ChangeTicketStatusHandler _handler;

        public ChangeTicketStatusEndpoint(ChangeTicketStatusHandler handler)
        {
            _handler = handler;
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> ChangeTicketStatus(int id, [FromBody] string status)
        {
            var command = new ChangeTicketStatusCommand(id, status);
            var result = await _handler.HandleAsync(command);

            if (!result)
                return NotFound(new { Message = "Ticket not found" });

            return NoContent();
        }
    }
}
