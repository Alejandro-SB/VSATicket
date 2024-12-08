using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSATicket.Application.Interfaces;
using VSATicket.Domain.Common.Models;

namespace VSATicket.Application.Features.Tickets.GetTicketsByStatus
{
    public class GetTicketsByStatusHandler
    {
        private readonly ITicketRepository _ticketRepository;

        public GetTicketsByStatusHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<IEnumerable<GetTicketByStatusDto>> HandleAsync(GetTicketByStatusQuery query)
        {
            var tickets = await _ticketRepository.GetTicketsByStatusAsync(query.Status);
            return tickets.Select(MapToDto).ToList();
        }

        private GetTicketByStatusDto MapToDto(Ticket ticket)
        {
            return new GetTicketByStatusDto
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Status = ticket.Status
            };
        }
    }
}
