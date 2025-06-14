using Moq;
using Xunit;
using AutomatiseringLiefLeed.Services;
using Azure.Core;
using AutomatiseringLiefLeed.Controllers;
using Microsoft.EntityFrameworkCore;
using AutomatiseringLiefLeed.Data;
using AutomatiseringLiefLeed.Models;
using Reason = AutomatiseringLiefLeed.Models.Reason;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; 

namespace AutomatiseringLiefLeed.AutomatiseringLiefLeed.Tests.Acceptance
{
    public class HR_aanvraag_overzicht_Test
    {
        [Fact(DisplayName = "F-01: “HR kan aanvraag goed")]
        public async Task ApproveRequest_()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            using var context = new ApplicationDbContext(options);

            var application = new Application
            {
                Id = 1,
                IsAccepted = null,
                DateOfApplication = DateTime.UtcNow,
                Reason = new Reason { Id = 1, Name = "Test" },
                DateOfIssue = DateTime.UtcNow,
                Sender = new Models.Employee
                {
                    Id = 1,
                    Medewerker = 1001,
                    Roepnaam = "Jan",
                    Achternaam = "Jansen",
                    EmailWerk = "jan.jansen@example.com",
                    GeboorteDatum = new DateOnly(1980, 1, 1),
                    AOWDatum = new DateOnly(2047, 1, 1),
                    InDienstIVMDienstJaren = new DateOnly(2010, 1, 1)
                },
                Recipient = new Models.Employee
                {
                    Id = 2,
                    Medewerker = 1002,
                    Roepnaam = "Piet",
                    Achternaam = "Pietersen",
                    EmailWerk = "piet.pietersen@example.com",
                    GeboorteDatum = new DateOnly(1985, 2, 2),
                    AOWDatum = new DateOnly(2052, 2, 2),
                    InDienstIVMDienstJaren = new DateOnly(2015, 2, 2),

                }
            };
            context.Applications.Add(application);
            await context.SaveChangesAsync();

            var controller = new AdminController(context);
            var httpContext = new DefaultHttpContext();
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = httpContext
            };

            // Act - Approve
            var result = await controller.Approve(application.Id);

            // Assert
            var updated = await context.Applications.FindAsync(application.Id);
            Assert.NotNull(updated);
            Assert.True(updated.IsAccepted);

            // Act - Reject (should delete)
            var rejectResult = await controller.Reject(application.Id);

            // Assert
            var deleted = await context.Applications.FindAsync(application.Id);
            Assert.Null(deleted);
        }

        [Fact(DisplayName = "F-01: HR kan aanvraag afkeuren.")]
        public async Task RejectRequest_()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()                // handig bij fouten
                .Options;

            await using var context = new ApplicationDbContext(options);

            var application = new Application
            {
                Id = 1,
                IsAccepted = null,                           // status nog onbekend
                DateOfApplication = DateTime.UtcNow,
                DateOfIssue = DateTime.UtcNow,
                Reason = new Reason { Id = 1, Name = "Test" },
                Sender = new Models.Employee
                {
                    Id = 1,
                    Medewerker = 1001,
                    Roepnaam = "Jan",
                    Achternaam = "Jansen",
                    EmailWerk = "jan.jansen@example.com",
                    GeboorteDatum = new DateOnly(1980, 1, 1),
                    AOWDatum = new DateOnly(2047, 1, 1),
                    InDienstIVMDienstJaren = new DateOnly(2010, 1, 1)
                },
                Recipient = new Models.Employee
                {
                    Id = 2,
                    Medewerker = 1002,
                    Roepnaam = "Piet",
                    Achternaam = "Pietersen",
                    EmailWerk = "piet.pietersen@example.com",
                    GeboorteDatum = new DateOnly(1985, 2, 2),
                    AOWDatum = new DateOnly(2052, 2, 2),
                    InDienstIVMDienstJaren = new DateOnly(2015, 2, 2)
                }
            };

            context.Applications.Add(application);
            await context.SaveChangesAsync();

            var controller = new AdminController(context)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };

            // Act – HR keurt de aanvraag af
            var result = await controller.Reject(application.Id);

            // Assert – aanvraag is verwijderd (of status ≠ approved, afhankelijk van je domein)
            var deleted = await context.Applications.FindAsync(application.Id);
            Assert.Null(deleted);

            // Eventueel: controleer het action-resultaat
            Assert.IsType<RedirectToActionResult>(result);
            var redirect = result as RedirectToActionResult;
            Assert.Equal("ApplicationOverview", redirect!.ActionName);
        }
    }
}
