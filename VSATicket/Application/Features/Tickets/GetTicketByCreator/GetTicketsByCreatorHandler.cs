using Microsoft.EntityFrameworkCore;
using VSATicket.Infrastructure.Data;

namespace VSATicket.Application.Features.Tickets.GetTicketsByCreator
{
    public class GetTicketsByCreatorHandler
    {
        private readonly ApplicationDbContext _context;

        public GetTicketsByCreatorHandler(ApplicationDbContext ticketRepository)
        {
            _context = ticketRepository;
        }

        public async Task<IEnumerable<GetTicketByCreatorDto>> HandleAsync(GetTicketsByCreatorQuery query)
        {
            var tickets = await _context.Tickets.FilterByCreator(query.CreatedBy)
                .Select(ticket => new GetTicketByCreatorDto
                {
                    Id = ticket.Id,
                    Title = ticket.Title,
                    Description = ticket.Description,
                    CreatedBy = ticket.CreatedBy
                }).ToListAsync();

            return tickets;
        }
    }
}
