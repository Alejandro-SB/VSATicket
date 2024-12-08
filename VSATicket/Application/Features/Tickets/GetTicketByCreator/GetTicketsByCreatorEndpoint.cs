using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VSATicket.Application.Features.Tickets.GetTicketsByCreator;
using System.Threading.Tasks;
using System.Linq;

namespace VSATicket.Application.Features.Tickets.GetTicketsByCreator
{
    [ApiController]
    [Route("api/tickets")]
    public class GetTicketsByCreatorEndpoint : ControllerBase
    {
        private readonly GetTicketsByCreatorHandler _handler;

        public GetTicketsByCreatorEndpoint(GetTicketsByCreatorHandler handler)
        {
            _handler = handler;
        }

        [Authorize(Roles = "user,admin")]
        [HttpGet("creator/{createdBy}")]
        public async Task<IActionResult> GetTicketsByCreator(string createdBy)
        {
            var query = new GetTicketsByCreatorQuery(createdBy);
            var result = await _handler.HandleAsync(query);

            if (result == null || !result.Any())
                return NotFound(new { Message = "No tickets found for the specified creator" });

            return Ok(result);
        }
    }
}
