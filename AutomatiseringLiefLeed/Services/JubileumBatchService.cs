using AutomatiseringLiefLeed.Data;
using Microsoft.EntityFrameworkCore;

namespace AutomatiseringLiefLeed.Services
{
    public class JubileumBatchService
    {
        private readonly ApplicationDbContext _ctx;
        public JubileumBatchService(ApplicationDbContext ctx) => _ctx = ctx;

        public async Task RunAsync()
        {
            var today = DateTime.Today;
            var reasons = await _ctx.Reasons.Where(r => r.IsAnniversary == true).ToListAsync();

            foreach (var emp in _ctx.Employees)
            {
                foreach (var reason in reasons)
                {
                    // Bereken verwachte datum (zoals in DateCheck) …
                    // Als match → _ctx.Applications.Add(new Application { … IsAccepted = true });
                }
            }
            await _ctx.SaveChangesAsync();
        }
    }
}
