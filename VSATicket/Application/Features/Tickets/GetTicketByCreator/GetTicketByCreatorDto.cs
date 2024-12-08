namespace VSATicket.Application.Features.Tickets.GetTicketsByCreator
{
    public class GetTicketByCreatorDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
    }
}
