using Microsoft.EntityFrameworkCore;
using VSATicket.Infrastructure.Data;

namespace VSATicket.Application.Features.Tickets.GetTicket
{
    public class GetTicketHandler
    {
        private readonly ApplicationDbContext _dbContext;

        public GetTicketHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TicketDto?> HandleAsync(GetTicketQuery query)
        {
            var ticket = await _dbContext.Tickets
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == query.TicketId);

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
