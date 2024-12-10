using VSATicket.Domain.Common.Models;
using VSATicket.Infrastructure.Data;

namespace VSATicket.Application.Features.Tickets.CreateTicket
{
    public class CreateTicketHandler
    {
        private readonly ApplicationDbContext _context;

        public CreateTicketHandler(ApplicationDbContext ticketRepository)
        {
            _context = ticketRepository;
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

            _context.Add(ticket);
            await _context.SaveChangesAsync();
        }
    }
}
