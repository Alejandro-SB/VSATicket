namespace VSATicket.Application.Features.Tickets.ChangeTicketStatus
{
    public class ChangeTicketStatusCommand
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public ChangeTicketStatusCommand(int id, string status)
        {
            Id = id;
            Status = status;
        }
    }
}
