using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VSATicket.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Solution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResolvedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OpenedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResolvedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "OpenedAt", "ResolvedAt", "ResolvedBy", "Solution", "Status", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 3, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(6381), "user1", "Description for Ticket 1", new DateTime(2024, 12, 3, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(6722), null, null, null, "Open", "Ticket 1" },
                    { 2, new DateTime(2024, 12, 2, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7676), "user2", "Description for Ticket 2", new DateTime(2024, 12, 2, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7770), new DateTime(2024, 12, 3, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7773), "resolver2", "Solution for Ticket 2", "Closed", "Ticket 2" },
                    { 3, new DateTime(2024, 12, 1, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7777), "user3", "Description for Ticket 3", new DateTime(2024, 12, 1, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7777), null, null, null, "In Progress", "Ticket 3" },
                    { 4, new DateTime(2024, 11, 30, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7780), "user4", "Description for Ticket 4", new DateTime(2024, 11, 30, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7781), null, null, null, "Open", "Ticket 4" },
                    { 5, new DateTime(2024, 11, 29, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7783), "user5", "Description for Ticket 5", new DateTime(2024, 11, 29, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7784), new DateTime(2024, 12, 3, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7785), "resolver5", "Solution for Ticket 5", "Closed", "Ticket 5" },
                    { 6, new DateTime(2024, 11, 28, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7787), "user6", "Description for Ticket 6", new DateTime(2024, 11, 28, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7788), null, null, null, "In Progress", "Ticket 6" },
                    { 7, new DateTime(2024, 11, 27, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7790), "user7", "Description for Ticket 7", new DateTime(2024, 11, 27, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7791), null, null, null, "Open", "Ticket 7" },
                    { 8, new DateTime(2024, 11, 26, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7793), "user8", "Description for Ticket 8", new DateTime(2024, 11, 26, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7793), new DateTime(2024, 12, 3, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7794), "resolver8", "Solution for Ticket 8", "Closed", "Ticket 8" },
                    { 9, new DateTime(2024, 11, 25, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7796), "user9", "Description for Ticket 9", new DateTime(2024, 11, 25, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7797), null, null, null, "In Progress", "Ticket 9" },
                    { 10, new DateTime(2024, 11, 24, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7799), "user10", "Description for Ticket 10", new DateTime(2024, 11, 24, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7800), null, null, null, "Open", "Ticket 10" },
                    { 11, new DateTime(2024, 11, 23, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7802), "user11", "Description for Ticket 11", new DateTime(2024, 11, 23, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7803), new DateTime(2024, 12, 3, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7804), "resolver11", "Solution for Ticket 11", "Closed", "Ticket 11" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
