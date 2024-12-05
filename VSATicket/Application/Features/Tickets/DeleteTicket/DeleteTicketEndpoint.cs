using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VSATicket.Application.Features.Tickets.DeleteTicket
{
    [ApiController]
    [Route("api/tickets")]
    public class DeleteTicketEndpoint : ControllerBase
    {
        private readonly DeleteTicketHandler _handler;

        public DeleteTicketEndpoint(DeleteTicketHandler handler)
        {
            _handler = handler;
        }

        [Authorize(Roles = "user")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var command = new DeleteTicketCommand(id);
            var result = await _handler.HandleAsync(command);

            if (!result)
                return NotFound(new { Message = "Ticket not found" });

            return NoContent();
        }
    }
}
