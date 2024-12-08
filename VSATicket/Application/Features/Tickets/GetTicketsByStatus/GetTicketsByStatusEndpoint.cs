using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using VSATicket.Application.Features.Tickets.GetTicketsByStatus;

namespace VSATicket.Application.Features.Tickets.GetTicketsByStatus
{
    [ApiController]
    [Route("api/tickets")]
    public class GetTicketsByStatusEndpoint : ControllerBase
    {
        private readonly GetTicketsByStatusHandler _handler;

        public GetTicketsByStatusEndpoint(GetTicketsByStatusHandler handler)
        {
            _handler = handler;
        }


        [Authorize(Roles = "admin")]
        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetTicketsByStatus(string status)
        {
            var query = new GetTicketByStatusQuery(status);
            var result = await _handler.HandleAsync(query);

            if (result == null || !result.Any())
                return NotFound(new { Message = "No tickets found with the specified status" });

            return Ok(result);
        }
    }
}
