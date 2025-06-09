using AutomatiseringLiefLeed.Data;
using AutomatiseringLiefLeed.Models;
using Microsoft.AspNetCore.Identity;

namespace AutomatiseringLiefLeed.AutomatiseringLiefLeed.Tests.Seeding
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByEmailAsync("admin@almere.nl");
            if (user == null)
            {
                user = new ApplicationUser { UserName = "admin@almere.nl", Email = "admin@almere.nl" };
                await userManager.CreateAsync(user, "Admin123!");
            }

            //if (!context.Applications.Any())
            //{
            //    context.Applications.AddRange(
            //        new Application
            //        {
            //            SenderId = "1",
            //            RecipientId = "2",
            //            DateOfApplication = DateTime.Now,
            //            DateOfIssue = DateTime.Now.AddDays(7),
            //            IsAccepted = false,
            //            ReasonId = 1
            //        },
            //        new Application
            //        {
            //            SenderId = "2",
            //            RecipientId = "3",
            //            DateOfApplication = DateTime.Now,
            //            DateOfIssue = DateTime.Now.AddDays(14),
            //            IsAccepted = true,
            //            ReasonId = 2
            //        }
            //    );
            //    context.SaveChanges();
            //}
        }
    }
}
