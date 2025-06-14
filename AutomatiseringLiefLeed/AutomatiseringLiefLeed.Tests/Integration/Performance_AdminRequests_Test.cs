using System.Diagnostics;
using System.Threading.Tasks;
using AutomatiseringLiefLeed.Controllers;
using AutomatiseringLiefLeed.Data;
using AutomatiseringLiefLeed.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;


namespace AutomatiseringLiefLeed.AutomatiseringLiefLeed.Tests.Integration
{
    public class Performance_AdminRequests_Test
    {
        [Fact(DisplayName = "NF-01: HR-overzicht levert ≤ 300 ms bij 50 aanvragen")]
        public async Task PendingList_IsFastEnough()
        {
            // ---------- Arrange ----------
            var opts = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase($"perf-{System.Guid.NewGuid()}")
                .Options;

            await using var ctx = new ApplicationDbContext(opts);

            // Seed 50 dummy-aanvragen
            var reason = new Reason { Id = 1, Name = "Test", GiftAmount = 10 };
            ctx.Reasons.Add(reason);

            for (int i = 1; i <= 50; i++)
            {
                ctx.Employees.Add(new Employee { Id = i, Medewerker = 1000 + i, Roepnaam = $"U{i}", Achternaam = "Test" });
                ctx.Applications.Add(new Application
                {
                    SenderId = i,
                    RecipientId = i,
                    ReasonId = 1,
                    DateOfIssue = System.DateTime.UtcNow,
                    DateOfApplication = System.DateTime.UtcNow,
                    IsAccepted = null
                });
            }
            await ctx.SaveChangesAsync();

            var controller = new AdminController(ctx);

            // ---------- Act ----------
            var sw = Stopwatch.StartNew();
            var result = await controller.ApplicationOverview(
                 sortOrder: null,
                 status: null);
            sw.Stop();

            // ---------- Assert ----------
            Assert.InRange(sw.ElapsedMilliseconds, 0, 300);   // NF-01 eis
        }
    }
}

