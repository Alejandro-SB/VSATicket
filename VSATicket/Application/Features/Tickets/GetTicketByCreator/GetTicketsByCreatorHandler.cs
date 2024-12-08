using VSATicket.Application.Interfaces;
using VSATicket.Domain.Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSATicket.Application.Features.Tickets.GetTicketsByCreator
{
    public class GetTicketsByCreatorHandler
    {
        private readonly ITicketRepository _ticketRepository;

        public GetTicketsByCreatorHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<IEnumerable<GetTicketByCreatorDto>> HandleAsync(GetTicketsByCreatorQuery query)
        {
            var tickets = await _ticketRepository.GetTicketsByCreatorAsync(query.CreatedBy);
            return tickets.Select(MapToDto).ToList();
        }

        private GetTicketByCreatorDto MapToDto(Ticket ticket)
        {
            return new GetTicketByCreatorDto
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                CreatedBy = ticket.CreatedBy
            };
        }
    }
}
