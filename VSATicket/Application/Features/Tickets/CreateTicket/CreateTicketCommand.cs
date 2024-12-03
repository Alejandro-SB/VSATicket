namespace VSATicket.Application.Features.Tickets.CreateTicket
{
    public class CreateTicketCommand
    {
        public string CreatedBy { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
