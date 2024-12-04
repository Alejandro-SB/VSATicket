using VSATicket.Domain.Common.Models;
using VSATicket.Application.Interfaces;

namespace VSATicket.Application.Features.Tickets.CreateTicket
{
    public class CreateTicketHandler
    {
        private readonly ITicketRepository _ticketRepository;

        public CreateTicketHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
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

            await _ticketRepository.CreateTicketAsync(ticket);
        }
    }
}
