using VSATicket.Infrastructure.Data;

namespace VSATicket.Application.Features.Tickets.GetTicket
{
    public class GetTicketHandler
    {
        private readonly ApplicationDbContext _context;

        public GetTicketHandler(ApplicationDbContext ticketRepository)
        {
            _context = ticketRepository;
        }

        public async Task<TicketDto?> HandleAsync(GetTicketQuery query)
        {
            var ticket = await _context.Tickets.GetById(query.TicketId);

            if (ticket == null)
                return null;

            return new TicketDto
            {
                Id = ticket.Id,
                CreatedBy = ticket.CreatedBy,
                Title = ticket.Title,
                Description = ticket.Description,
                Status = ticket.Status,
                Solution = ticket.Solution,
                ResolvedBy = ticket.ResolvedBy,
                CreatedAt = ticket.CreatedAt,
                OpenedAt = ticket.OpenedAt,
                ResolvedAt = ticket.ResolvedAt
            };
        }
    }
}
