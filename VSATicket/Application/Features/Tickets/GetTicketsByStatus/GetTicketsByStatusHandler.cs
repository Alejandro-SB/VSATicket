using Microsoft.EntityFrameworkCore;
using VSATicket.Infrastructure.Data;

namespace VSATicket.Application.Features.Tickets.GetTicketsByStatus
{
    public class GetTicketsByStatusHandler
    {
        private readonly ApplicationDbContext _context;

        public GetTicketsByStatusHandler(ApplicationDbContext ticketRepository)
        {
            _context = ticketRepository;
        }

        public async Task<IEnumerable<GetTicketByStatusDto>> HandleAsync(GetTicketByStatusQuery query)
        {
            var tickets = await _context.Tickets.FilterByStatus(query.Status)
                .Select(ticket => new GetTicketByStatusDto
                {
                    Id = ticket.Id,
                    Title = ticket.Title,
                    Status = ticket.Status
                })
                .ToListAsync();

            return tickets;
        }

        // If you don't like the inline in the select, you can do this
        //private Expression<Func<Ticket, GetTicketByStatusDto>> MapToDto = (ticket) =>
        //    new()
        //    {
        //        Id = ticket.Id,
        //        Title = ticket.Title,
        //        Status = ticket.Status
        //    };
    }
}
