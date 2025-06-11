using AutomatiseringLiefLeed.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AutomatiseringLiefLeed.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<Application>()
                .HasOne(a => a.Sender)
                .WithMany(e => e.Applications)
                .HasForeignKey(a => a.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            //!!DONT TOUCH!! reason seeding, commenting out reasons that are unable to be used for now (like marriage)
            builder.Entity<Reason>().HasData(
                //new Reason { Id = 1, Name = "geboorte", GiftAmount = 25, IsAnniversary = false },
                new Reason { Id = 2, Name = "ziek", GiftAmount = 25, IsAnniversary = false },
                new Reason { Id = 3, Name = "ziekte 3 maanden", GiftAmount = 25, IsAnniversary = false },
                new Reason { Id = 4, Name = "ziekte 3 weken", GiftAmount = 25, IsAnniversary = false },
                new Reason { Id = 5, Name = "ziekte ziekenhuisopname", GiftAmount = 25, IsAnniversary = false },
                //new Reason { Id = 6, Name = "huwelijk/geregistreerd partnerschap", GiftAmount = 40, IsAnniversary = false },
                new Reason { Id = 7, Name = "ontslag/fpu/pensionering", GiftAmount = 25, IsAnniversary = true, AnniversaryYears = 0 }, //anniversary years = 0, to filter out non preset dates
                new Reason { Id = 8, Name = "50e verjaardag", GiftAmount = 25, IsAnniversary = true, AnniversaryYears = 50 },
                new Reason { Id = 9, Name = "65e verjaardag", GiftAmount = 25, IsAnniversary = true, AnniversaryYears = 65 },
                //new Reason { Id = 10, Name = "12,5 jaar huwelijk", GiftAmount = 25, IsAnniversary = true },
                new Reason { Id = 11, Name = "12,5 jaar ambtenaar", GiftAmount = 25, IsAnniversary = true, AnniversaryYears = 12.5 },
                //new Reason { Id = 12, Name = "25 jaar huwelijk", GiftAmount = 25, IsAnniversary = true },
                new Reason { Id = 13, Name = "overlijden ambtenaar of huisgenoot", GiftAmount = 50, IsAnniversary = false },
                new Reason { Id = 14, Name = "40 jaar ambtenaar", GiftAmount = 40, IsAnniversary = true, AnniversaryYears = 40 }
                //new Reason { Id = 15, Name = "40 jarig huwelijk", GiftAmount = 40, IsAnniversary = true }
            );

            //Unsure of the reasoning behind this, uncommenting for now
            //        builder.Entity<Reason>().HasData(
            //    new Reason
            //    {
            //        Id = 101,
            //        Name = "Marriage",
            //        GiftAmount = 250.0,
            //        IsAnniversary = false,
            //        AnniversaryYears = 0
            //    },
            //    new Reason
            //    {
            //        Id = 102,
            //        Name = "Birth",
            //        GiftAmount = 150.0,
            //        IsAnniversary = false,
            //        AnniversaryYears = 0
            //    }
            //);

            //        // Application seeding
            //        builder.Entity<Application>().HasData(
            //            new Application
            //            {
            //                Id = 1,
            //                SenderId = "user-alice", // pas dit aan naar echte gebruiker ID
            //                RecipientId = "user-alice", // evt. zelfde als sender
            //                ReasonId = 1,
            //                DateOfApplication = new DateTime(2024, 1, 1),
            //                DateOfIssue = new DateTime(2024, 1, 5),
            //                IsAccepted = true
            //            },
            //            new Application
            //            {
            //                Id = 2,
            //                SenderId = "user-bob",
            //                RecipientId = "user-bob",
            //                ReasonId = 2,
            //                DateOfApplication = new DateTime(2024, 1, 3),
            //                DateOfIssue = new DateTime(2024, 1, 6),
            //                IsAccepted = false
            //            }
            //        );
            //    }
            //}
        }
    }
}
