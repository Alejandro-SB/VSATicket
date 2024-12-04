using VSATicket.Application.Interfaces;

namespace VSATicket.Application.Features.Tickets.GetTicket
{
    public class GetTicketHandler
    {
        private readonly ITicketRepository _ticketRepository;

        public GetTicketHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<TicketDto?> HandleAsync(GetTicketQuery query)
        {
            var ticket = await _ticketRepository.GetByIdAsync(query.TicketId);

            if (ticket == null)
                return null;

            return new TicketDto
            {
                Id = ticket.Id,
                CreatedBy = ticket.CreatedBy,
                Title = ticket.Title,
                Description = ticket.Description,
                Status = ticket.Status,
                Solution = ticket.Solution,
                ResolvedBy = ticket.ResolvedBy,
                CreatedAt = ticket.CreatedAt,
                OpenedAt = ticket.OpenedAt,
                ResolvedAt = ticket.ResolvedAt
            };
        }
    }
}
