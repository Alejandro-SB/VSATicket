using Microsoft.EntityFrameworkCore;
using VSATicket.Domain.Common.Models;

namespace VSATicket.Infrastructure.Data
{
    public static class TicketSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket
                {
                    Id = 1,
                    CreatedBy = "user1",
                    Title = "Ticket 1",
                    Description = "Description for Ticket 1",
                    Status = "Open",
                    Solution = null,
                    ResolvedBy = null,
                    CreatedAt = DateTime.UtcNow,
                    OpenedAt = DateTime.UtcNow,
                    ResolvedAt = null
                },
                new Ticket
                {
                    Id = 2,
                    CreatedBy = "user2",
                    Title = "Ticket 2",
                    Description = "Description for Ticket 2",
                    Status = "Closed",
                    Solution = "Solution for Ticket 2",
                    ResolvedBy = "resolver2",
                    CreatedAt = DateTime.UtcNow.AddDays(-1),
                    OpenedAt = DateTime.UtcNow.AddDays(-1),
                    ResolvedAt = DateTime.UtcNow
                },
                new Ticket
                {
                    Id = 3,
                    CreatedBy = "user3",
                    Title = "Ticket 3",
                    Description = "Description for Ticket 3",
                    Status = "In Progress",
                    Solution = null,
                    ResolvedBy = null,
                    CreatedAt = DateTime.UtcNow.AddDays(-2),
                    OpenedAt = DateTime.UtcNow.AddDays(-2),
                    ResolvedAt = null
                },
                new Ticket
                {
                    Id = 4,
                    CreatedBy = "user4",
                    Title = "Ticket 4",
                    Description = "Description for Ticket 4",
                    Status = "Open",
                    Solution = null,
                    ResolvedBy = null,
                    CreatedAt = DateTime.UtcNow.AddDays(-3),
                    OpenedAt = DateTime.UtcNow.AddDays(-3),
                    ResolvedAt = null
                },
                new Ticket
                {
                    Id = 5,
                    CreatedBy = "user5",
                    Title = "Ticket 5",
                    Description = "Description for Ticket 5",
                    Status = "Closed",
                    Solution = "Solution for Ticket 5",
                    ResolvedBy = "resolver5",
                    CreatedAt = DateTime.UtcNow.AddDays(-4),
                    OpenedAt = DateTime.UtcNow.AddDays(-4),
                    ResolvedAt = DateTime.UtcNow
                },
                new Ticket
                {
                    Id = 6,
                    CreatedBy = "user6",
                    Title = "Ticket 6",
                    Description = "Description for Ticket 6",
                    Status = "In Progress",
                    Solution = null,
                    ResolvedBy = null,
                    CreatedAt = DateTime.UtcNow.AddDays(-5),
                    OpenedAt = DateTime.UtcNow.AddDays(-5),
                    ResolvedAt = null
                },
                new Ticket
                {
                    Id = 7,
                    CreatedBy = "user7",
                    Title = "Ticket 7",
                    Description = "Description for Ticket 7",
                    Status = "Open",
                    Solution = null,
                    ResolvedBy = null,
                    CreatedAt = DateTime.UtcNow.AddDays(-6),
                    OpenedAt = DateTime.UtcNow.AddDays(-6),
                    ResolvedAt = null
                },
                new Ticket
                {
                    Id = 8,
                    CreatedBy = "user8",
                    Title = "Ticket 8",
                    Description = "Description for Ticket 8",
                    Status = "Closed",
                    Solution = "Solution for Ticket 8",
                    ResolvedBy = "resolver8",
                    CreatedAt = DateTime.UtcNow.AddDays(-7),
                    OpenedAt = DateTime.UtcNow.AddDays(-7),
                    ResolvedAt = DateTime.UtcNow
                },
                new Ticket
                {
                    Id = 9,
                    CreatedBy = "user9",
                    Title = "Ticket 9",
                    Description = "Description for Ticket 9",
                    Status = "In Progress",
                    Solution = null,
                    ResolvedBy = null,
                    CreatedAt = DateTime.UtcNow.AddDays(-8),
                    OpenedAt = DateTime.UtcNow.AddDays(-8),
                    ResolvedAt = null
                },
                new Ticket
                {
                    Id = 10,
                    CreatedBy = "user10",
                    Title = "Ticket 10",
                    Description = "Description for Ticket 10",
                    Status = "Open",
                    Solution = null,
                    ResolvedBy = null,
                    CreatedAt = DateTime.UtcNow.AddDays(-9),
                    OpenedAt = DateTime.UtcNow.AddDays(-9),
                    ResolvedAt = null
                },
                new Ticket
                {
                    Id = 11,
                    CreatedBy = "user11",
                    Title = "Ticket 11",
                    Description = "Description for Ticket 11",
                    Status = "Closed",
                    Solution = "Solution for Ticket 11",
                    ResolvedBy = "resolver11",
                    CreatedAt = DateTime.UtcNow.AddDays(-10),
                    OpenedAt = DateTime.UtcNow.AddDays(-10),
                    ResolvedAt = DateTime.UtcNow
                }
            );
        }
    }
}
