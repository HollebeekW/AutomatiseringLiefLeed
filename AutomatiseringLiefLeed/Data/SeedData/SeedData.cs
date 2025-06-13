using AutomatiseringLiefLeed.Models;
using Microsoft.AspNetCore.Identity;

namespace AutomatiseringLiefLeed.Data.SeedData
{
    public static class SeedData
    {
        public static async Task SeedUsersAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

            var email = "hans@almere.nl";

            // Seed ApplicationUser
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true,
                    FirstName = "Hans",
                    LastName = "Gebruiker"
                };
                await userManager.CreateAsync(user, "Wachtwoord123!");
            }

            // Seed Employee
            if (!dbContext.Employees.Any(e => (e.EmailWerk ?? string.Empty).ToLower() == email.ToLower()))
            {
                dbContext.Employees.Add(new Employee
                {
                    Roepnaam = "Hans",
                    Achternaam = "Gebruiker",
                    EmailWerk = email,
                    GeboorteDatum = DateOnly.FromDateTime(DateTime.Now.AddYears(-30)),
                    AOWDatum = DateOnly.FromDateTime(DateTime.Now.AddYears(37)),
                    InDienstIVMDienstJaren = DateOnly.FromDateTime(DateTime.Now.AddYears(-5))
                });
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
