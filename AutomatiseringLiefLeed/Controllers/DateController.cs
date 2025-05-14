using AutomatiseringLiefLeed.Data;
using AutomatiseringLiefLeed.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutomatiseringLiefLeed.Controllers
{
    //FOR TESTING PURPOSES ONLY. NOT FOR FINAL PRODUCT
    public class DateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DateController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: Dates
        public async Task<IActionResult> Index()
        {
            return _context.Dates != null ?
                View(await _context.Dates.ToListAsync()) :
                Problem("Entity set 'ApplicationDbContext.Date' is null");
        }

        //GET: Dates/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Dates/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstDate,SecondDate")] Date date)
        {
            //validation in controller for now, later preferably in model
            if (date.FirstDate > date.SecondDate)
            {
                ModelState.AddModelError("", "First date must be earlier than second date");
            }

            if (ModelState.IsValid)
            {
                _context.Add(date);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(date);
        }

        //Check difference between dates
        public async Task<IActionResult> CheckDateDifference(int id)
        {
            var date = await _context.Dates.FindAsync(id);

            if (date == null)
            {
                return NotFound();
            }

            //convert DateOnly to DateTime and take time values for 00:00, to ensure it only calculates in days
            var days = (date.SecondDate.ToDateTime(TimeOnly.MinValue)
                - date.FirstDate.ToDateTime(TimeOnly.MinValue)).Days;

            //convert days to years
            var years = (days / 365);

            //check if years equals to anniversary
            if (years == 12.5 || years == 25 || years == 40 )
            {
                //return separate message if date is an anniversary
                TempData["IsAnniversary"] = $"Gefeliciteerd! Dit is de {years}ste jubileum";
            }

            //show amount of years
            TempData["DaysDifference"] = $"Het verschil is {years} jaar/jaren.";

            //return to index
            return RedirectToAction("Index");
        }
    }
}
