using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VSATicket.Application.Features.Tickets.GetTicket;

namespace VSATicket.Application.Features.Tickets.GetTicket
{
    [ApiController]
    [Route("api/tickets")]
    public class GetTicketEndpoints : ControllerBase
    {
        private readonly GetTicketHandler _handler;

        public GetTicketEndpoints(GetTicketHandler handler)
        {
            _handler = handler;
        }

        [Authorize(Roles = "user,admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketById(int id)
        {
            var query = new GetTicketQuery(id);
            var result = await _handler.HandleAsync(query);

            if (result == null)
                return NotFound(new { Message = "Ticket not found" });

            return Ok(result);
        }
    }
}
