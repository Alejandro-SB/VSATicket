namespace VSATicket.Application.Features.Tickets.GetTicket
{
    public class TicketDto
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string? Solution { get; set; }
        public string? ResolvedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? OpenedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
    }
}
