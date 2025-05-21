using AutomatiseringLiefLeed.Data;
using AutomatiseringLiefLeed.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace AutomatiseringLiefLeed.Tests;

public class UnitTest1
{
    [Fact]
    public async Task Can_Save_Request_To_Database()
    {
        // Arrange – in-memory database aanmaken
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "RequestTestDB") // Ensure the extension method is available
            .Options;

        using (var context = new ApplicationDbContext(options))
        {
            var request = new Request
            {
                EmployeeName = "Test Medewerker",
                EventType = "jubileum",
                RequestDate = DateTime.Today,
                Note = "testnotitie",
                Status = "Pending",
                ManualReviewRequired = false,
                PaymentApproved = false
            };

            // Act – opslaan
            context.Requests.Add(request);
            await context.SaveChangesAsync();
        }

        // Assert – ophalen en controleren
        using (var context = new ApplicationDbContext(options))
        {
            var result = await context.Requests.FirstOrDefaultAsync(r => r.EmployeeName == "Test Medewerker");
            Assert.NotNull(result);
            Assert.Equal("jubileum", result.EventType);
        }
    }
}
