﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VSATicket.Infrastructure.Data;

#nullable disable

namespace VSATicket.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241205152440_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("VSATicket.Domain.Common.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("VSATicket.Domain.Common.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OpenedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ResolvedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResolvedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Solution")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 12, 5, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(4232),
                            CreatedBy = "user1",
                            Description = "Description for Ticket 1",
                            OpenedAt = new DateTime(2024, 12, 5, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(4581),
                            Status = "Open",
                            Title = "Ticket 1"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 12, 4, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5406),
                            CreatedBy = "user2",
                            Description = "Description for Ticket 2",
                            OpenedAt = new DateTime(2024, 12, 4, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5500),
                            ResolvedAt = new DateTime(2024, 12, 5, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5527),
                            ResolvedBy = "resolver2",
                            Solution = "Solution for Ticket 2",
                            Status = "Closed",
                            Title = "Ticket 2"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 12, 3, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5531),
                            CreatedBy = "user3",
                            Description = "Description for Ticket 3",
                            OpenedAt = new DateTime(2024, 12, 3, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5532),
                            Status = "In Progress",
                            Title = "Ticket 3"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 12, 2, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5534),
                            CreatedBy = "user4",
                            Description = "Description for Ticket 4",
                            OpenedAt = new DateTime(2024, 12, 2, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5535),
                            Status = "Open",
                            Title = "Ticket 4"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 12, 1, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5602),
                            CreatedBy = "user5",
                            Description = "Description for Ticket 5",
                            OpenedAt = new DateTime(2024, 12, 1, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5603),
                            ResolvedAt = new DateTime(2024, 12, 5, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5605),
                            ResolvedBy = "resolver5",
                            Solution = "Solution for Ticket 5",
                            Status = "Closed",
                            Title = "Ticket 5"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2024, 11, 30, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5607),
                            CreatedBy = "user6",
                            Description = "Description for Ticket 6",
                            OpenedAt = new DateTime(2024, 11, 30, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5608),
                            Status = "In Progress",
                            Title = "Ticket 6"
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2024, 11, 29, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5610),
                            CreatedBy = "user7",
                            Description = "Description for Ticket 7",
                            OpenedAt = new DateTime(2024, 11, 29, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5611),
                            Status = "Open",
                            Title = "Ticket 7"
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2024, 11, 28, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5613),
                            CreatedBy = "user8",
                            Description = "Description for Ticket 8",
                            OpenedAt = new DateTime(2024, 11, 28, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5614),
                            ResolvedAt = new DateTime(2024, 12, 5, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5615),
                            ResolvedBy = "resolver8",
                            Solution = "Solution for Ticket 8",
                            Status = "Closed",
                            Title = "Ticket 8"
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(2024, 11, 27, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5617),
                            CreatedBy = "user9",
                            Description = "Description for Ticket 9",
                            OpenedAt = new DateTime(2024, 11, 27, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5618),
                            Status = "In Progress",
                            Title = "Ticket 9"
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(2024, 11, 26, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5621),
                            CreatedBy = "user10",
                            Description = "Description for Ticket 10",
                            OpenedAt = new DateTime(2024, 11, 26, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5621),
                            Status = "Open",
                            Title = "Ticket 10"
                        },
                        new
                        {
                            Id = 11,
                            CreatedAt = new DateTime(2024, 11, 25, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5624),
                            CreatedBy = "user11",
                            Description = "Description for Ticket 11",
                            OpenedAt = new DateTime(2024, 11, 25, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5624),
                            ResolvedAt = new DateTime(2024, 12, 5, 15, 24, 39, 700, DateTimeKind.Utc).AddTicks(5625),
                            ResolvedBy = "resolver11",
                            Solution = "Solution for Ticket 11",
                            Status = "Closed",
                            Title = "Ticket 11"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("VSATicket.Domain.Common.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("VSATicket.Domain.Common.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VSATicket.Domain.Common.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("VSATicket.Domain.Common.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}