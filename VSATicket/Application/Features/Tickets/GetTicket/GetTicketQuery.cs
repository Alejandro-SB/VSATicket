namespace VSATicket.Application.Features.Tickets.GetTicket
{
    public class GetTicketQuery
    {
        public int TicketId { get; set; }

        public GetTicketQuery(int ticketId)
        {
            TicketId = ticketId;
        }
    }
}
