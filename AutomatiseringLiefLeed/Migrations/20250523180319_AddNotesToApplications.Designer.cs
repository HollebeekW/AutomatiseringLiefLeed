﻿// <auto-generated />
using System;
using AutomatiseringLiefLeed.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutomatiseringLiefLeed.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250523180319_AddNotesToApplications")]
    partial class AddNotesToApplications
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutomatiseringLiefLeed.Models.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfApplication")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfIssue")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<int>("ReasonId")
                        .HasColumnType("int");

                    b.Property<string>("RecipientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReasonId");

                    b.ToTable("Applications");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfApplication = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfIssue = new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAccepted = true,
                            ReasonId = 1,
                            RecipientId = "user-alice",
                            SenderId = "user-alice"
                        },
                        new
                        {
                            Id = 2,
                            DateOfApplication = new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfIssue = new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAccepted = false,
                            ReasonId = 2,
                            RecipientId = "user-bob",
                            SenderId = "user-bob"
                        });
                });

            modelBuilder.Entity("AutomatiseringLiefLeed.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfEmployment")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfMarriage")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfSickness")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSick")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
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

            modelBuilder.Entity("AutomatiseringLiefLeed.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("AutomatiseringLiefLeed.Models.Reason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AnniversaryYears")
                        .HasColumnType("float");

                    b.Property<double>("GiftAmount")
                        .HasColumnType("float");

                    b.Property<bool>("IsAnniversary")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reasons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnniversaryYears = 0.0,
                            GiftAmount = 25.0,
                            IsAnniversary = true,
                            Name = "geboorte"
                        },
                        new
                        {
                            Id = 2,
                            AnniversaryYears = 0.0,
                            GiftAmount = 25.0,
                            IsAnniversary = false,
                            Name = "ziek"
                        },
                        new
                        {
                            Id = 3,
                            AnniversaryYears = 0.0,
                            GiftAmount = 25.0,
                            IsAnniversary = false,
                            Name = "ziekte 3 maanden"
                        },
                        new
                        {
                            Id = 4,
                            AnniversaryYears = 0.0,
                            GiftAmount = 25.0,
                            IsAnniversary = false,
                            Name = "ziekte 3 weken"
                        },
                        new
                        {
                            Id = 5,
                            AnniversaryYears = 0.0,
                            GiftAmount = 25.0,
                            IsAnniversary = false,
                            Name = "ziekte ziekenhuisopname"
                        },
                        new
                        {
                            Id = 6,
                            AnniversaryYears = 0.0,
                            GiftAmount = 40.0,
                            IsAnniversary = true,
                            Name = "huwelijk/geregistreerd partnerschap"
                        },
                        new
                        {
                            Id = 7,
                            AnniversaryYears = 0.0,
                            GiftAmount = 25.0,
                            IsAnniversary = true,
                            Name = "ontslag/fpu/pensionering"
                        },
                        new
                        {
                            Id = 8,
                            AnniversaryYears = 0.0,
                            GiftAmount = 25.0,
                            IsAnniversary = true,
                            Name = "50e verjaardag"
                        },
                        new
                        {
                            Id = 9,
                            AnniversaryYears = 0.0,
                            GiftAmount = 25.0,
                            IsAnniversary = true,
                            Name = "65e verjaardag"
                        },
                        new
                        {
                            Id = 10,
                            AnniversaryYears = 0.0,
                            GiftAmount = 25.0,
                            IsAnniversary = true,
                            Name = "12,5 jaar huwelijk"
                        },
                        new
                        {
                            Id = 11,
                            AnniversaryYears = 0.0,
                            GiftAmount = 25.0,
                            IsAnniversary = true,
                            Name = "12,5 jaar ambtenaar"
                        },
                        new
                        {
                            Id = 12,
                            AnniversaryYears = 0.0,
                            GiftAmount = 25.0,
                            IsAnniversary = true,
                            Name = "25 jaar huwelijk"
                        },
                        new
                        {
                            Id = 13,
                            AnniversaryYears = 0.0,
                            GiftAmount = 50.0,
                            IsAnniversary = false,
                            Name = "overlijden ambtenaar of huisgenoot"
                        },
                        new
                        {
                            Id = 14,
                            AnniversaryYears = 0.0,
                            GiftAmount = 40.0,
                            IsAnniversary = true,
                            Name = "40 jaar ambtenaar"
                        },
                        new
                        {
                            Id = 15,
                            AnniversaryYears = 0.0,
                            GiftAmount = 40.0,
                            IsAnniversary = true,
                            Name = "40 jarig huwelijk"
                        },
                        new
                        {
                            Id = 20,
                            AnniversaryYears = 0.0,
                            GiftAmount = 40.0,
                            IsAnniversary = true,
                            Name = "Verjaardag"
                        },
                        new
                        {
                            Id = 21,
                            AnniversaryYears = 0.0,
                            GiftAmount = 50.0,
                            IsAnniversary = true,
                            Name = "Trouwen"
                        },
                        new
                        {
                            Id = 101,
                            AnniversaryYears = 0.0,
                            GiftAmount = 250.0,
                            IsAnniversary = false,
                            Name = "Marriage"
                        },
                        new
                        {
                            Id = 102,
                            AnniversaryYears = 0.0,
                            GiftAmount = 150.0,
                            IsAnniversary = false,
                            Name = "Birth"
                        });
                });

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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AutomatiseringLiefLeed.Models.Application", b =>
                {
                    b.HasOne("AutomatiseringLiefLeed.Models.Reason", "Reason")
                        .WithMany("Applications")
                        .HasForeignKey("ReasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reason");
                });

            modelBuilder.Entity("AutomatiseringLiefLeed.Models.Note", b =>
                {
                    b.HasOne("AutomatiseringLiefLeed.Models.Application", "Application")
                        .WithMany("Notes")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");
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
                    b.HasOne("AutomatiseringLiefLeed.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AutomatiseringLiefLeed.Models.ApplicationUser", null)
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

                    b.HasOne("AutomatiseringLiefLeed.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AutomatiseringLiefLeed.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutomatiseringLiefLeed.Models.Application", b =>
                {
                    b.Navigation("Notes");
                });

            modelBuilder.Entity("AutomatiseringLiefLeed.Models.Reason", b =>
                {
                    b.Navigation("Applications");
                });
#pragma warning restore 612, 618
        }
    }
}
