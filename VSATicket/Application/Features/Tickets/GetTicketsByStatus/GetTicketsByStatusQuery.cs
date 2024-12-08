namespace VSATicket.Application.Features.Tickets.GetTicketsByStatus
{
    public class GetTicketByStatusQuery
    {
        public string Status { get; set; }

        public GetTicketByStatusQuery(string status)
        {
            Status = status;
        }
    }
}
