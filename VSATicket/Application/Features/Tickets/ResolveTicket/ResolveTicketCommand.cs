namespace VSATicket.Application.Features.Tickets.ResolveTicket
{
    public class ResolveTicketCommand
    {
        public string Solution { get; set; }
        public string ResolvedBy { get; set; }
        public DateTime ResolvedAt { get; set; }

        public ResolveTicketCommand(string solution, string resolvedBy, DateTime resolvedAt)
        {
            Solution = solution;
            ResolvedBy = resolvedBy;
            ResolvedAt = resolvedAt;
        }
    }
}
