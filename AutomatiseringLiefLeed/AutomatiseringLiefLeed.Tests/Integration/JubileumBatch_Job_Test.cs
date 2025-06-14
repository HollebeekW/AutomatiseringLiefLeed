using AutomatiseringLiefLeed.Data;
using AutomatiseringLiefLeed.Models;
using Microsoft.EntityFrameworkCore;

public sealed class JubileumBatchService
{
    private readonly ApplicationDbContext _ctx;

    public JubileumBatchService(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task RunAsync(DateTime? today = null)
    {
        // 0) Referentiedatum
        var now = today ?? DateTime.Today;
        var todayDateOnly = DateOnly.FromDateTime(now);

        // 1) Alle jubilea-redenen ophalen
        var reasons = await _ctx.Reasons
            .Where(r => r.IsAnniversary == true            // bool?  -> bool
                     && r.AnniversaryYears != null)        // double?/int? check
            .ToListAsync();

        foreach (var reason in reasons)
        {
            // 2) Welke indienst-datum hoort bij dit jubileum?
            var targetHireDate = todayDateOnly.AddYears((int)-reason.AnniversaryYears!.Value);

            // 3) Medewerkers die vandaag hun jubileum hebben
            var employees = await _ctx.Employees
                                      .Where(e => e.InDienstIVMDienstJaren == targetHireDate)
                                      .ToListAsync();

            foreach (var employee in employees)
            {
                // 4) Voorkom dubbelingen (zelfde jaar, zelfde reden)
                            var alreadyExists = await _ctx.Applications
                .AnyAsync(a => a.RecipientId == employee.Id
                            && a.ReasonId == reason.Id
                            && a.DateOfIssue.HasValue                // ← eerst checken
                            && a.DateOfIssue.Value.Year == now.Year  // ← daarna .Value
            );

                if (alreadyExists) continue;

                // 5) Aanvraag aanmaken en direct accepteren
                _ctx.Applications.Add(new Application
                {
                    RecipientId = employee.Id,
                    ReasonId = reason.Id,
                    DateOfIssue = now,
                    IsAccepted = true
                });
            }
        }

        // 6) Persist!
        await _ctx.SaveChangesAsync();
    }
}
