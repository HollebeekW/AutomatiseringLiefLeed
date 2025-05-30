using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AutomatiseringLiefLeed;
using AutomatiseringLiefLeed.Data;

public class TestWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");   // zie stap 2

        builder.ConfigureServices(services =>
        {
            // 1. bestaande ApplicationDbContext-registratie eruit
            var dbDescriptor = services.Single(d =>
                d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
            services.Remove(dbDescriptor);

            // 2. In-Memory provider er­voor in de plaats
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("TestDb"));

            // 3. Database aanmaken & seed-data toevoegen (rollen, admin-gebruiker, …)
            var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            db.Database.EnsureCreated();
            SeedTestData(db);               // → maak “admin@almere.nl” rol/gebruiker e.d.
        });
    }

    private static void SeedTestData(ApplicationDbContext db)
    {
        // voorbeeld: db.Reasons.Add(new Reason { Id = 1, Name = "Jubileum 25 jaar" });
        db.SaveChanges();
    }
}
