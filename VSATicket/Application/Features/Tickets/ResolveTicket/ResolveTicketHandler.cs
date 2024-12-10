using VSATicket.Infrastructure.Data;

namespace VSATicket.Application.Features.Tickets.ResolveTicket
{
    public class ResolveTicketHandler
    {
        private readonly ApplicationDbContext _context;

        public ResolveTicketHandler(ApplicationDbContext ticketRepository)
        {
            _context = ticketRepository;
        }

        public async Task<bool> HandleAsync(int id, ResolveTicketCommand command)
        {
            var ticket = await _context.Tickets.GetById(id);

            if (ticket == null)
                return false;

            ticket.Solution = command.Solution;
            ticket.ResolvedBy = command.ResolvedBy;
            ticket.ResolvedAt = command.ResolvedAt;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
