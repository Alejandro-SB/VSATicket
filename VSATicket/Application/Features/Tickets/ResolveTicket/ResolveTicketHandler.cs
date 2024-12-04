using VSATicket.Domain.Common.Models;
using VSATicket.Application.Interfaces;

namespace VSATicket.Application.Features.Tickets.ResolveTicket
{
    public class ResolveTicketHandler
    {
        private readonly ITicketRepository _ticketRepository;

        public ResolveTicketHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<bool> HandleAsync(int id, ResolveTicketCommand command)
        {
            var ticket = await _ticketRepository.GetByIdAsync(id);

            if (ticket == null)
                return false;

            ticket.Solution = command.Solution;
            ticket.ResolvedBy = command.ResolvedBy;
            ticket.ResolvedAt = command.ResolvedAt;
            await _ticketRepository.ResolveTicketAsync(ticket);
            return true;
        }
    }
}
