using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Xunit;
using AutomatiseringLiefLeed.Data;
using AutomatiseringLiefLeed.Models;

namespace AutomatiseringLiefLeed.Testing
{
    public class RequestTests : IDisposable
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;
        private readonly ApplicationDbContext _context;

        public RequestTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite("Filename=:memory:")
                .Options;

            _context = new ApplicationDbContext(_options);
            _context.Database.OpenConnection();
            _context.Database.EnsureCreated();
        }

        [Fact]
        public async Task Request_Wordt_Opgeslagen()
        {
            var request = new Request
            {
                EmployeeName = "Test Gebruiker",
                EventType = "Verjaardag",
                RequestDate = DateTime.Today,
                Note = "Test",
                Status = "Pending",
                ManualReviewRequired = false,
                PaymentApproved = false
            };

            _context.Requests.Add(request);
            await _context.SaveChangesAsync();

            var result = await _context.Requests.FirstOrDefaultAsync(r => r.EmployeeName == "Test Gebruiker");
            Assert.NotNull(result);
            Assert.Equal("Verjaardag", result.EventType);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}