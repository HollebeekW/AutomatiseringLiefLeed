using System.Net;
using System.Text.RegularExpressions;
using AutomatiseringLiefLeed.AutomatiseringLiefLeed.Tests.Seeding;
using AutomatiseringLiefLeed.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace AutomatiseringLiefLeed.Tests.Acceptance;

[Trait("Category", "Acceptance")]
public class AanvraagFormTests
{
    //private async Task<HttpClient> GetAuthenticatedClientAsync()
    //{
    //    var factory = new WebApplicationFactory<Program>()
    //   .WithWebHostBuilder(static builder =>
    //   {
    //       builder.UseEnvironment("Testing");
    //       _ = builder.ConfigureServices(async services =>
    //       {
    //           // Get the service provider
    //           var sp = services.BuildServiceProvider();

    //           // Create a scope to obtain a reference to the database context
    //           using (var scope = sp.CreateScope())
    //           {
    //               var scopedServices = scope.ServiceProvider;
    //               var db = scopedServices.GetRequiredService<ApplicationDbContext>();

    //               // Ensure the database is created
    //               db.Database.EnsureCreated();

    //               // Seed the database
    //               await ApplicationDbContextSeed.SeedAsync(db, scopedServices);
    //           }
    //       });
    //   });

    //    var client = factory.CreateDefaultClient();

    //    // Login ophalen en uitvoeren
    //    var loginHtml = await client.GetStringAsync("/Identity/Account/Login");
    //    var tokenMatch = Regex.Match(
    //        loginHtml,
    //        @"name=""__RequestVerificationToken""[^>]*value=""([^""]+)""",
    //        RegexOptions.IgnoreCase | RegexOptions.Singleline);
    //    Assert.True(tokenMatch.Success, "CSRF-token niet gevonden");
    //    var token = tokenMatch.Groups[1].Value;

    //    var form = new Dictionary<string, string?>
    //    {
    //        ["Input.Email"] = "admin@almere.nl",
    //        ["Input.Password"] = "Admin123!",
    //        ["__RequestVerificationToken"] = token
    //    };

    //    var resp = await client.PostAsync(
    //        "/Identity/Account/Login",
    //        new FormUrlEncodedContent(form));
    //    Assert.Equal(HttpStatusCode.Redirect, resp.StatusCode);

    //    return client;
    //}



    //[Fact]
    //public async Task GeldigeAanvraagFormulier_WordtVerwerktEnRedirect()
    //{
    //    // Arrange
    //    var client = await GetAuthenticatedClientAsync();

    //    // Haal het aanvraagformulier op en extract CSRF-token
    //    var getResponse = await client.GetAsync("/AanvraagForm/Create");
    //    if (getResponse.StatusCode == HttpStatusCode.Redirect)
    //    {
    //        var redirectUrl = getResponse.Headers.Location?.ToString();
    //        throw new Exception($"Redirected to {redirectUrl}. Authentication may have failed.");
    //    }
    //    getResponse.EnsureSuccessStatusCode();
    //    var formHtml = await getResponse.Content.ReadAsStringAsync();

    //    // Extract CSRF-token from form HTML
    //    var tokenMatch = Regex.Match(
    //        formHtml,
    //        @"name=""__RequestVerificationToken""[^>]*value=""([^""]+)""",
    //        RegexOptions.IgnoreCase | RegexOptions.Singleline);
    //    Assert.True(tokenMatch.Success, "CSRF-token niet gevonden op aanvraagformulier");
    //    var token = tokenMatch.Groups[1].Value;

    //    // Vul het formulier in met geldige data
    //    var aanvraagData = new Dictionary<string, string?>
    //    {
    //        ["SenderId"] = "12345",
    //        ["RecipientId"] = "67890",
    //        ["ReasonId"] = "1",
    //        ["DateOfIssue"] = "2024-06-01",
    //        ["__RequestVerificationToken"] = token
    //    };

    //    // Act
    //    var postResponse = await client.PostAsync(
    //        "/AanvraagForm/Create",
    //        new FormUrlEncodedContent(aanvraagData));

    //    // Assert
    //    Assert.Equal(HttpStatusCode.Redirect, postResponse.StatusCode);
    //    var redirectLocation = postResponse.Headers.Location?.ToString();
    //    Assert.NotNull(redirectLocation);
    //    Assert.Contains("Bevestiging", redirectLocation, StringComparison.OrdinalIgnoreCase);
    //}
}
