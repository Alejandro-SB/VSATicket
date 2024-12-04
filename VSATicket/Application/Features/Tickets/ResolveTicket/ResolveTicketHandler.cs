using VSATicket.Infrastructure.Data;
using VSATicket.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using VSATicket.Domain.Common.Models;

namespace VSATicket.Application.Features.Tickets.ResolveTicket
{
    public class ResolveTicketHandler
    {
        private readonly ApplicationDbContext _dbContext;

        public ResolveTicketHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> HandleAsync(int id, ResolveTicketCommand command)
        {
            var ticket = await _dbContext.Tickets
                .FirstOrDefaultAsync(t => t.Id == id);

            if (ticket == null)
                return false;

            ticket.Solution = command.Solution;
            ticket.ResolvedBy = command.ResolvedBy;
            ticket.ResolvedAt = command.ResolvedAt;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
