using VSATicket.Infrastructure.Data;

namespace VSATicket.Application.Features.Tickets.ChangeTicketStatus
{
    public class ChangeTicketStatusHandler
    {
        private readonly ApplicationDbContext _context;

        public ChangeTicketStatusHandler(ApplicationDbContext ticketRepository)
        {
            _context = ticketRepository;
        }

        public async Task<bool> HandleAsync(ChangeTicketStatusCommand command)
        {
            var ticket = await _context.Tickets.GetById(command.Id);

            if (ticket == null)
                return false;

            ticket.Status = command.Status;
            // Change tracker is enabled, so you can just do this
            await _context.SaveChangesAsync();

            //await _context.ChangeTicketStatusAsync(ticket);
            return true;
        }
    }
}
