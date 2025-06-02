using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutomatiseringLiefLeed.Data;
using AutomatiseringLiefLeed.Models;

namespace AutomatiseringLiefLeed.Controllers
{
    public class ReasonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReasonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Commented out everything currently not in use
        //If it's ever needed again:
        //Select to be uncommented lines, press CTRL + K and then CTRL + U

        // GET: Reasons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reasons.ToListAsync());
        }

        // GET: Reasons/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var reason = await _context.Reasons
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (reason == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(reason);
        //}

        //// GET: Reasons/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Reasons/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,GiftAmount,IsAnniversary,AnniversaryYears")] Reason reason)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(reason);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(reason);
        //}

        // GET: Reasons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reason = await _context.Reasons.FindAsync(id);
            if (reason == null)
            {
                return NotFound();
            }
            return View(reason);
        }

        // POST: Reasons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GiftAmount")] Reason reason)
        {
            if (id != reason.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Retrieve reason from database
                    var existingReason = await _context.Reasons.FindAsync(id);
                    if (existingReason == null)
                        return NotFound();

                    //Only update the GiftAmount
                    existingReason.GiftAmount = reason.GiftAmount;

                    //Save changes
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReasonExists(reason.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reason);
        }

        // GET: Reasons/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var reason = await _context.Reasons
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (reason == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(reason);
        //}

        //// POST: Reasons/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var reason = await _context.Reasons.FindAsync(id);
        //    if (reason != null)
        //    {
        //        _context.Reasons.Remove(reason);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool ReasonExists(int id)
        {
            return _context.Reasons.Any(e => e.Id == id);
        }
    }
}
