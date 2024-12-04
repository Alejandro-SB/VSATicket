using VSATicket.Domain.Common.Models;
using VSATicket.Application.Interfaces;

namespace VSATicket.Application.Features.Tickets.DeleteTicket
{
    public class DeleteTicketHandler
    {
        private readonly ITicketRepository _ticketRepository;

        public DeleteTicketHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<bool> HandleAsync(DeleteTicketCommand command)
        {
            var ticket = await _ticketRepository.GetByIdAsync(command.Id);

            if (ticket == null)
                return false;

            await _ticketRepository.DeleteTicketAsync(ticket);
            return true;
        }
    }
}
