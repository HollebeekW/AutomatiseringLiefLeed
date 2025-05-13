using AutomatiseringLiefLeed.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutomatiseringLiefLeed.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Reason> Reasons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Reason>().HasData(
                //some reasons are possibly unable to be used, will still leave them in just in case (for now)
                new Reason { Id = 1, Name = "geboorte", MoneyAmount = 25, IsAnniversary = true },
                new Reason { Id = 2, Name = "ziek", MoneyAmount = 25, IsAnniversary = false },
                new Reason { Id = 3, Name = "ziekte 3 maanden", MoneyAmount = 25, IsAnniversary = false },
                new Reason { Id = 4, Name = "ziekte 3 weken", MoneyAmount = 25, IsAnniversary = false },
                new Reason { Id = 5, Name = "ziekte ziekenhuisopname", MoneyAmount = 25, IsAnniversary = false },
                new Reason { Id = 6, Name = "huwelijk/geregistreerd partnerschap", MoneyAmount = 40, IsAnniversary = true },
                new Reason { Id = 7, Name = "ontslag/fpu/pensionering", MoneyAmount = 25 , IsAnniversary = true },
                new Reason { Id = 8, Name = "50e verjaardag", MoneyAmount = 25, IsAnniversary = true },
                new Reason { Id = 9, Name = "65e verjaardag", MoneyAmount = 25 , IsAnniversary = true },
                new Reason { Id = 10, Name = "12,5 jaar huwelijk", MoneyAmount = 25, IsAnniversary = true },
                new Reason { Id = 11, Name = "12,5 jaar ambtenaar", MoneyAmount = 25, IsAnniversary = true },
                new Reason { Id = 12, Name = "25 jaar huwelijk", MoneyAmount = 25, IsAnniversary = true },
                new Reason { Id = 13, Name = "overlijden ambtenaar of huisgenoot", MoneyAmount = 50, IsAnniversary = false },
                new Reason { Id = 14, Name = "40 jaar ambtenaar", MoneyAmount = 40, IsAnniversary = true},
                new Reason { Id = 15, Name = "40 jarig huwelijk", MoneyAmount = 40, IsAnniversary = true}
                );
        }
    }
}
