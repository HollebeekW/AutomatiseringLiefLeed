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

        public DbSet<ApplicationModel> ApplicationModelSet { get; set; }
        public DbSet<DepartmentModel> DepartmentModelSet { get; set; }
        public DbSet<ReasonModel> ReasonModelSet { get; set; }
        public DbSet<ApplicationUserModel> UserModelSet { get; set; }
    }
}
