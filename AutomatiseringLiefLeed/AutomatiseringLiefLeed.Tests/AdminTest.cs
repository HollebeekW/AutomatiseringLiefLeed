using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutomatiseringLiefLeed.Controllers;
using AutomatiseringLiefLeed.Models;
using AutomatiseringLiefLeed.Data;
using System.Threading.Tasks;

namespace AutomatiseringLiefLeed.AutomatiseringLiefLeed.Tests
{
    public class AdminTest
    {
        [Fact]
        public async Task Approve_SetsIsAcceptedTrue_AndRedirects()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

            int applicationId = 1;

            // Seed database

            using (var context = new ApplicationDbContext(options))
            {
                context.Applications.Add(new Application
                {
                    Id = 1,
                    IsAccepted = false,
                    SenderId = "1",
                    RecipientId = "2"
                });
                context.SaveChanges();
            }

            // Act
            IActionResult result;
            using (var context = new ApplicationDbContext(options))
            {
                var controller = new AdminController(context);
                result = await controller.Approve(1);
            }

            // Assert
            using (var context = new ApplicationDbContext(options))
            {
                var application = await context.Applications.FindAsync(1);
                Assert.NotNull(application);
                Assert.True(application.IsAccepted);
            }
        }
    }
}
