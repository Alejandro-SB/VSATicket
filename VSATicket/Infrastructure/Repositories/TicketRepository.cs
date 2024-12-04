using VSATicket.Domain.Common.Models;
using VSATicket.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using VSATicket.Application.Interfaces;

namespace VSATicket.Infrastructure.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TicketRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Ticket?> GetByIdAsync(int id)
        {
            return await _dbContext.Tickets.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task CreateTicketAsync(Ticket ticket)
        {
            _dbContext.Tickets.Add(ticket);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ChangeTicketStatusAsync(Ticket ticket)
        {
            _dbContext.Tickets.Update(ticket);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteTicketAsync(Ticket ticket)
        {
            _dbContext.Tickets.Remove(ticket);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ResolveTicketAsync(Ticket ticket)
        {
            _dbContext.Tickets.Update(ticket);
            await _dbContext.SaveChangesAsync();
        }
    }
}
