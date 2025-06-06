using AutomatiseringLiefLeed.Data;
using AutomatiseringLiefLeed.Models;
using AutomatiseringLiefLeed.Services.Email;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutomatiseringLiefLeed.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;

        public AdminController(ApplicationDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        // GET: /Admin/
        public IActionResult Index()
        {
            return View();
        }

        // ApplicationOverview view
        public async Task<IActionResult> ApplicationOverview()
        {
            var applications = await _context.Applications
                .Include(a => a.Reason)
                .Include(a => a.Sender)
                .Include(a => a.Recipient)
                .OrderByDescending(a => a.DateOfApplication)
                .ToListAsync();


            //return View(requests);
            return View(applications);
        }

        // GET: /Admin/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var application = await _context.Applications
                .Include(a => a.Sender)
                .Include(a => a.Recipient)
                .Include(a => a.Reason)
                .Include(a => a.Notes) // if you're also displaying notes
                .FirstOrDefaultAsync(a => a.Id == id);

            if (application == null)
                return NotFound();

            return View(application);
        }

        // POST: /Admin/Approve/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id)
        {
            var application = await _context.Applications
                .Include(a => a.Sender)
                .Include(a => a.Reason)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (application == null) return NotFound();

            application.IsAccepted = true;
            await _context.SaveChangesAsync();

            //Send email
            if (application.Sender != null && application.Reason != null)
            {
                _emailService.SendApplicationApprovedEmail(
                    application.Sender.EmailWerk,
                    $"{application.Sender.Roepnaam} {application.Sender.Achternaam}",
                    application.Reason.Name,
                    application.DateOfApplication?.ToString("dd-MM-yyyy") ?? "Onbekende datum"
                );
            }

            return RedirectToAction(nameof(ApplicationOverview));
        }

        // POST: /Admin/Reject/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id)
        {
            var application = await _context.Applications
                .Include(a => a.Sender)
                .Include(a => a.Reason)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (application == null) return NotFound();

            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();

            //Send email
            if (application.Sender != null && application.Reason != null)
            {
                _emailService.SendApplicationRejectedEmail(
                    application.Sender.EmailWerk,
                    $"{application.Sender.Roepnaam} {application.Sender.Achternaam}",
                    application.Reason.Name,
                    application.DateOfApplication?.ToString("dd-MM-yyyy")
                );
            }

            return RedirectToAction(nameof(ApplicationOverview));
        }

        // POST: /Admin/AddNote
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNote(int id, string note)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application == null) return NotFound();

           
            var newNote = new Note
            {
                ApplicationId = application.Id,
                AuthorName = User.Identity?.Name ?? "Unknown",
                Text = note,
                CreatedAt = DateTime.UtcNow
            };

            _context.Notes.Add(newNote);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
