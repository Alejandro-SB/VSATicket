namespace VSATicket.Application.Features.Tickets.DeleteTicket
{
    public class DeleteTicketCommand
    {
        public int Id { get; set; }

        public DeleteTicketCommand(int id)
        {
            Id = id;
        }
    }
}
