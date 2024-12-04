using VSATicket.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using VSATicket.Domain.Common.Models;

namespace VSATicket.Application.Features.Tickets.ChangeTicketStatus
{
    public class ChangeTicketStatusHandler
    {
        private readonly ApplicationDbContext _dbContext;

        public ChangeTicketStatusHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> HandleAsync(ChangeTicketStatusCommand command)
        {
            var ticket = await _dbContext.Tickets
                .FirstOrDefaultAsync(t => t.Id == command.Id);

            if (ticket == null)
                return false;

            ticket.Status = command.Status;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
