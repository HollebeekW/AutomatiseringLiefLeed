using AutomatiseringLiefLeed.Controllers;
using AutomatiseringLiefLeed.Data;
using AutomatiseringLiefLeed.DTOs;
using AutomatiseringLiefLeed.Models;
using AutomatiseringLiefLeed.Services;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace AutomatiseringLiefLeed.AutomatiseringLiefLeed.Tests.Acceptance
{
    public class Application_Submit_Test
    {
        [Fact(DisplayName = "F-02: Medewerker kan aanvraag indienen.")]
        public async Task SubmitRequest_ReturnsPending()
        {
            // ---------- Arrange ----------
            var opts = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            await using var ctx = new ApplicationDbContext(opts);

            // Seed lookup-tabellen (verplichte velden)
            var sender = new Models.Employee { Id = 1, Medewerker = 1001, Roepnaam = "Jan", Achternaam = "Jansen" };
            var recipient = new Models.Employee { Id = 2, Medewerker = 1002, Roepnaam = "Piet", Achternaam = "Pietersen" };
            var reason = new Models.Reason { Id = 1, Name = "Jubileum", IsAnniversary = false };
            ctx.Employees.AddRange(sender, recipient);
            ctx.Reasons.Add(reason);
            await ctx.SaveChangesAsync();

            // Controller – injecteer ctx en fake (null) AFAS-service
            var httpContext = new DefaultHttpContext();                     // eigen HttpContext voor de test
            var tempProvider = new Mock<ITempDataProvider>();                // lege TempData-provider stub
            var tempData = new TempDataDictionary(httpContext, tempProvider.Object);

            var controller = new AanvraagFormController(ctx, null!)        // null! → AFASService niet gebruikt
            {
                ControllerContext = new ControllerContext { HttpContext = httpContext },
                TempData = tempData                                 // ← essentieel om NRE te voorkomen
            };

            var model = new Application
            {
                SenderId = sender.Id,
                RecipientId = recipient.Id,
                ReasonId = reason.Id,
                DateOfIssue = DateTime.UtcNow.AddDays(3)   // toekomstig, valide
            };

            // ---------- Act ----------
            var result = await controller.Create(model);

            // ---------- Assert ----------
            var stored = await ctx.Applications.SingleAsync();
            Assert.False(stored.IsAccepted);                 // status = Pending
            Assert.Equal(sender.Id, stored.SenderId);
            Assert.IsType<RedirectToActionResult>(result);  // redirect naar Success-view
        }
    }   
}

