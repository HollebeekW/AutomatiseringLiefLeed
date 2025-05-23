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
            //var requests = await _context.Requests
            //    .OrderByDescending(r => r.RequestDate)
            //    .ToListAsync();

            //return View(requests);
            return View();
        }

        // GET: /Admin/Details/5
        public async Task<IActionResult> Details(int id)
        {
            //var request = await _context.Requests.FindAsync(id);
            //if (request == null) return NotFound();

            //return View(request);
            return View();
        }

        // POST: /Admin/Approve/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id)
        {
            //var request = await _context.Requests.FindAsync(id);
            //if (request == null) return NotFound();

            //request.Status = RequestStatus.Approved;
            //await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: /Admin/Reject/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id)
        {
            //var request = await _context.Requests.FindAsync(id);
            //if (request == null) return NotFound();

            //request.Status = RequestStatus.Rejected;
            //await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: /Admin/AddNote
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNote(int id, string note)
        {
            //var request = await _context.Requests.FindAsync(id);
            //if (request == null) return NotFound();

            //request.Note = note;
            //await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
