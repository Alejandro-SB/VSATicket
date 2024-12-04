using VSATicket.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using VSATicket.Domain.Common.Models;

namespace VSATicket.Application.Features.Tickets.DeleteTicket
{
    public class DeleteTicketHandler
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteTicketHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> HandleAsync(DeleteTicketCommand command)
        {
            var ticket = await _dbContext.Tickets
                .FirstOrDefaultAsync(t => t.Id == command.Id);

            if (ticket == null)
                return false;

            _dbContext.Tickets.Remove(ticket);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
