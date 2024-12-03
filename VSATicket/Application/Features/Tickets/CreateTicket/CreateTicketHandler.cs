using VSATicket.Infrastructure.Data;
using VSATicket.Domain.Common.Models;

namespace VSATicket.Application.Features.Tickets.CreateTicket
{
    public class CreateTicketHandler
    {
        private readonly ApplicationDbContext _dbContext;

        public CreateTicketHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task HandleAsync(CreateTicketCommand command)
        {
            var ticket = new Ticket
            {
                CreatedBy = command.CreatedBy,
                Title = command.Title,
                Description = command.Description,
                Status = command.Status,
                CreatedAt = DateTime.UtcNow
            };

            _dbContext.Tickets.Add(ticket);
            await _dbContext.SaveChangesAsync();
        }
    }
}
