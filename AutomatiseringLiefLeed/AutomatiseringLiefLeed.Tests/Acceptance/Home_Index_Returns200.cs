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
            _client = new TestWebApplicationFactory().CreateClient();
        }

        [Fact]
        public async Task Returns200()
        {
            var response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();
        }
    }
}
