using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VSATicket.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OpenedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(4232), new DateTime(2024, 12, 5, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(4581) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OpenedAt", "ResolvedAt" },
                values: new object[] { new DateTime(2024, 12, 4, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5406), new DateTime(2024, 12, 4, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5500), new DateTime(2024, 12, 5, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5527) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "OpenedAt" },
                values: new object[] { new DateTime(2024, 12, 3, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5531), new DateTime(2024, 12, 3, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5532) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "OpenedAt" },
                values: new object[] { new DateTime(2024, 12, 2, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5534), new DateTime(2024, 12, 2, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5535) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "OpenedAt", "ResolvedAt" },
                values: new object[] { new DateTime(2024, 12, 1, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5602), new DateTime(2024, 12, 1, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5603), new DateTime(2024, 12, 5, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5605) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "OpenedAt" },
                values: new object[] { new DateTime(2024, 11, 30, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5607), new DateTime(2024, 11, 30, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5608) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "OpenedAt" },
                values: new object[] { new DateTime(2024, 11, 29, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5610), new DateTime(2024, 11, 29, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5611) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "OpenedAt", "ResolvedAt" },
                values: new object[] { new DateTime(2024, 11, 28, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5613), new DateTime(2024, 11, 28, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5614), new DateTime(2024, 12, 5, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5615) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "OpenedAt" },
                values: new object[] { new DateTime(2024, 11, 27, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5617), new DateTime(2024, 11, 27, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5618) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "OpenedAt" },
                values: new object[] { new DateTime(2024, 11, 26, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5621), new DateTime(2024, 11, 26, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5621) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "OpenedAt", "ResolvedAt" },
                values: new object[] { new DateTime(2024, 11, 25, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5624), new DateTime(2024, 11, 25, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5624), new DateTime(2024, 12, 5, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5625) });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OpenedAt" },
                values: new object[] { new DateTime(2024, 12, 3, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(6381), new DateTime(2024, 12, 3, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(6722) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OpenedAt", "ResolvedAt" },
                values: new object[] { new DateTime(2024, 12, 2, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7676), new DateTime(2024, 12, 2, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7770), new DateTime(2024, 12, 3, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7773) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "OpenedAt" },
                values: new object[] { new DateTime(2024, 12, 1, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7777), new DateTime(2024, 12, 1, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7777) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "OpenedAt" },
                values: new object[] { new DateTime(2024, 11, 30, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7780), new DateTime(2024, 11, 30, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7781) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "OpenedAt", "ResolvedAt" },
                values: new object[] { new DateTime(2024, 11, 29, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7783), new DateTime(2024, 11, 29, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7784), new DateTime(2024, 12, 3, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7785) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "OpenedAt" },
                values: new object[] { new DateTime(2024, 11, 28, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7787), new DateTime(2024, 11, 28, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7788) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "OpenedAt" },
                values: new object[] { new DateTime(2024, 11, 27, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7790), new DateTime(2024, 11, 27, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7791) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "OpenedAt", "ResolvedAt" },
                values: new object[] { new DateTime(2024, 11, 26, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7793), new DateTime(2024, 11, 26, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7793), new DateTime(2024, 12, 3, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7794) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "OpenedAt" },
                values: new object[] { new DateTime(2024, 11, 25, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7796), new DateTime(2024, 11, 25, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7797) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "OpenedAt" },
                values: new object[] { new DateTime(2024, 11, 24, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7799), new DateTime(2024, 11, 24, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7800) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "OpenedAt", "ResolvedAt" },
                values: new object[] { new DateTime(2024, 11, 23, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7802), new DateTime(2024, 11, 23, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7803), new DateTime(2024, 12, 3, 19, 58, 18, 176, DateTimeKind.Utc).AddTicks(7804) });
        }
    }
}
