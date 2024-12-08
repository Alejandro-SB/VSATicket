using VSATicket.Domain.Common.Models;

namespace VSATicket.Application.Interfaces
{
    public interface ITicketRepository
    {
        Task<Ticket?> GetByIdAsync(int id);
        Task CreateTicketAsync(Ticket ticket);
        Task ChangeTicketStatusAsync(Ticket ticket);
        Task DeleteTicketAsync(Ticket ticket);
        Task ResolveTicketAsync(Ticket ticket);
        Task<IEnumerable<Ticket>> GetTicketsByStatusAsync(string status);
        Task<IEnumerable<Ticket>> GetTicketsByCreatorAsync(string createdBy);
    }
}
