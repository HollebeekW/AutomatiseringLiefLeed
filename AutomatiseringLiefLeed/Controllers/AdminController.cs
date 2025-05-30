using AutomatiseringLiefLeed.Data;
using AutomatiseringLiefLeed.Models;
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

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
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
            .OrderByDescending(a => a.DateOfApplication)
            .ToListAsync();


            //return View(requests);
            return View(applications);
        }

        // GET: /Admin/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var application = await _context.Applications.FindAsync(id);

            return View(application);
        }

        // POST: /Admin/Approve/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application == null) return NotFound();

            application.IsAccepted = true;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: /Admin/Reject/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application == null) return NotFound();

            application.IsAccepted = false;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
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
