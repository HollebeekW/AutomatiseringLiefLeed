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
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<ReasonModel> Reasons { get; set; }
        public DbSet<ApplicationUserModel> Users { get; set; }
    }
}
