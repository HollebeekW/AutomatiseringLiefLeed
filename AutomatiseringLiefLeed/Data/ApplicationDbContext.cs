using AutomatiseringLiefLeed.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Request> Requests { get; set; }
        public DbSet<Notes> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Reason>().HasData(
                new Reason { Id = 1, Name = "geboorte", EventPrice = 25, IsAnniversary = true },
                new Reason { Id = 2, Name = "ziek", EventPrice = 25, IsAnniversary = false },
                new Reason { Id = 3, Name = "ziekte 3 maanden", EventPrice = 25, IsAnniversary = false },
                new Reason { Id = 4, Name = "ziekte 3 weken", EventPrice = 25, IsAnniversary = false },
                new Reason { Id = 5, Name = "ziekte ziekenhuisopname", EventPrice = 25, IsAnniversary = false },
                new Reason { Id = 6, Name = "huwelijk/geregistreerd partnerschap", EventPrice = 40, IsAnniversary = true },
                new Reason { Id = 7, Name = "ontslag/fpu/pensionering", EventPrice = 25, IsAnniversary = true },
                new Reason { Id = 8, Name = "50e verjaardag", EventPrice = 25, IsAnniversary = true },
                new Reason { Id = 9, Name = "65e verjaardag", EventPrice = 25, IsAnniversary = true },
                new Reason { Id = 10, Name = "12,5 jaar huwelijk", EventPrice = 25, IsAnniversary = true },
                new Reason { Id = 11, Name = "12,5 jaar ambtenaar", EventPrice = 25, IsAnniversary = true },
                new Reason { Id = 12, Name = "25 jaar huwelijk", EventPrice = 25, IsAnniversary = true },
                new Reason { Id = 13, Name = "overlijden ambtenaar of huisgenoot", EventPrice = 50, IsAnniversary = false },
                new Reason { Id = 14, Name = "40 jaar ambtenaar", EventPrice = 40, IsAnniversary = true },
                new Reason { Id = 15, Name = "40 jarig huwelijk", EventPrice = 40, IsAnniversary = true },
                new Reason { Id = 20, Name = "Verjaardag", EventPrice = 40, IsAnniversary = true },
                new Reason { Id = 21, Name = "Trouwen", EventPrice = 50, IsAnniversary = true }
            );

            builder.Entity<Request>().HasData(
                new Request
                {
                    Id = 1,
                    EmployeeName = "Alice Example",
                    EventType = "Marriage",
                    RequestDate = new DateTime(2024, 1, 1),
                    Status = RequestStatus.Pending,
                    ManualReviewRequired = false,
                    PaymentApproved = true,
                    Note = "Voorbeeldaanvraag"
                },
                new Request
                {
                    Id = 2,
                    EmployeeName = "Bob Test",
                    EventType = "Birth",
                    RequestDate = new DateTime(2024, 1, 3),
                    Status = RequestStatus.Pending,
                    ManualReviewRequired = true,
                    PaymentApproved = false,
                    Note = "Spoed"
                }
            );
        }
    }
}
