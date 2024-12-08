namespace VSATicket.Application.Features.Tickets.GetTicketsByCreator
{
    public class GetTicketsByCreatorQuery
    {
        public string CreatedBy { get; set; }

        public GetTicketsByCreatorQuery(string createdBy)
        {
            CreatedBy = createdBy;
        }
    }
}
