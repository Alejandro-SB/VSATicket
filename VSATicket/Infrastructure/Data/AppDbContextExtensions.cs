using Microsoft.EntityFrameworkCore;
using VSATicket.Domain.Common.Models;

namespace VSATicket.Infrastructure.Data;

public static class AppDbContextExtensions
{

    public static async Task<Ticket?> GetById(this DbSet<Ticket> tickets, int id)
    {
        return await tickets.FirstOrDefaultAsync(x => x.Id == id);
    }

    public static IQueryable<Ticket> FilterByCreator(this DbSet<Ticket> tickets, string creator)
    {
        return tickets.Where(x => x.CreatedBy == creator);
    }

    public static IQueryable<Ticket> FilterByStatus(this DbSet<Ticket> tickets, string status)
    {
        return tickets.Where(x => x.Status == status);
    }
}
