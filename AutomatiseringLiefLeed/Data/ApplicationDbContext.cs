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

        public DbSet<ApplicationModel> Applications { get; set; }
        public DbSet<ReasonModel> Reasons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ReasonModel>().HasData(
                //some reasons are possibly unable to be used, will still leave them in just in case (for now)
                new ReasonModel { Id = 1, Name = "geboorte", MoneyAmount = 25, IsAnniversary = true },
                new ReasonModel { Id = 2, Name = "ziek", MoneyAmount = 25, IsAnniversary = false },
                new ReasonModel { Id = 3, Name = "ziekte 3 maanden", MoneyAmount = 25, IsAnniversary = false },
                new ReasonModel { Id = 4, Name = "ziekte 3 weken", MoneyAmount = 25, IsAnniversary = false },
                new ReasonModel { Id = 5, Name = "ziekte ziekenhuisopname", MoneyAmount = 25, IsAnniversary = false },
                new ReasonModel { Id = 6, Name = "huwelijk/geregistreerd partnerschap", MoneyAmount = 40, IsAnniversary = true },
                new ReasonModel { Id = 7, Name = "ontslag/fpu/pensionering", MoneyAmount = 25 , IsAnniversary = true },
                new ReasonModel { Id = 8, Name = "50e verjaardag", MoneyAmount = 25, IsAnniversary = true },
                new ReasonModel { Id = 9, Name = "65e verjaardag", MoneyAmount = 25 , IsAnniversary = true },
                new ReasonModel { Id = 10, Name = "12,5 jaar huwelijk", MoneyAmount = 25, IsAnniversary = true },
                new ReasonModel { Id = 11, Name = "12,5 jaar ambtenaar", MoneyAmount = 25, IsAnniversary = true },
                new ReasonModel { Id = 12, Name = "25 jaar huwelijk", MoneyAmount = 25, IsAnniversary = true },
                new ReasonModel { Id = 13, Name = "overlijden ambtenaar of huisgenoot", MoneyAmount = 50, IsAnniversary = false },
                new ReasonModel { Id = 14, Name = "40 jaar ambtenaar", MoneyAmount = 40, IsAnniversary = true},
                new ReasonModel { Id = 15, Name = "40 jarig huwelijk", MoneyAmount = 40, IsAnniversary = true}
                );
        }
    }
}
