using VSATicket.Infrastructure.Data;

namespace VSATicket.Application.Features.Tickets.DeleteTicket
{
    public class DeleteTicketHandler
    {
        private readonly ApplicationDbContext _context;

        public DeleteTicketHandler(ApplicationDbContext ticketRepository)
        {
            _context = ticketRepository;
        }

        public async Task<bool> HandleAsync(DeleteTicketCommand command)
        {
            var ticket = await _context.Tickets.GetById(command.Id);

            if (ticket == null)
                return false;

            _context.Remove(ticket);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
