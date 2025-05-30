using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit;

namespace AutomatiseringLiefLeed.AutomatiseringLiefLeed.Tests.Acceptance
{
    public class Home_Index_Returns200
    {
        private readonly HttpClient _client;
        public Home_Index_Returns200()
        {
            var factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(b => b.UseEnvironment("Testing"));
            _client = factory.CreateClient();
        }
        [Fact(DisplayName = "Home Index returns 200 OK")]
        public async Task HomeIndexReturns200()
        {
            // Act
            var response = await _client.GetAsync("/");
            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
