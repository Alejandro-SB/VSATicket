using VSATicket.Domain.Common.Models;
using VSATicket.Application.Interfaces;

namespace VSATicket.Application.Features.Tickets.ChangeTicketStatus
{
    public class ChangeTicketStatusHandler
    {
        private readonly ITicketRepository _ticketRepository;

        public ChangeTicketStatusHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<bool> HandleAsync(ChangeTicketStatusCommand command)
        {
            var ticket = await _ticketRepository.GetByIdAsync(command.Id);

            if (ticket == null)
                return false;

            ticket.Status = command.Status;
            await _ticketRepository.ChangeTicketStatusAsync(ticket);
            return true;
        }
    }
}
