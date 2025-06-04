//using AutomatiseringLiefLeed.Data;
//using AutomatiseringLiefLeed.Models;
//using Microsoft.EntityFrameworkCore;
//using Xunit;

//namespace AutomatiseringLiefLeed.Tests;

//public class UnitTest1
//{
//    [Fact]
//    public async Task Can_Save_Application_To_Database()
//    {
//        // Arrange – in-memory database aanmaken
//        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
//            .UseInMemoryDatabase(databaseName: "ApplicationTestDB")
//            .Options;

//        using (var context = new ApplicationDbContext(options))
//        {
//            var application = new Application
//            {
//                Id = 1,
//                SenderId = "user123",
//                RecipientId = "user456",
//                DateOfApplication = DateTime.Today,
//                DateOfIssue = DateTime.Today.AddDays(1),
//                IsAccepted = false,
//                ReasonId = 2
//            };

//            // Act – opslaan
//            context.Applications.Add(application);
//            await context.SaveChangesAsync();
//        }

//        // Assert – ophalen en controleren
//        using (var context = new ApplicationDbContext(options))
//        {
//            var result = await context.Applications.FirstOrDefaultAsync(a => a.SenderId == "user123");
//            Assert.NotNull(result);
//            Assert.Equal(2, result.ReasonId);
//            Assert.False(result.IsAccepted);
//        }
//    }
//}
