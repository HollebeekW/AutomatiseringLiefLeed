using AutomatiseringLiefLeed.Data;
using AutomatiseringLiefLeed.Models;
using AutomatiseringLiefLeed.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AutomatiseringLiefLeed.Controllers
{
    public class AanvraagFormController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AFASService _afasService;

        public AanvraagFormController(ApplicationDbContext context, AFASService afasService) // Updated constructor
        {
            _context = context;
            _afasService = afasService; // Initialize the missing service
        }

        // GET: /AanvraagForm/Create
        [Authorize]
        public IActionResult Create()
        {
            // NIET VERWIJDEREN
            //ViewBag.Employees = new SelectList((System.Collections.IEnumerable)_afasService.GetEmployeesAsync(), "Id", "FullName");
            //ViewBag.Departments = new SelectList((System.Collections.IEnumerable)_afasService.GetDepartmentsAsync(), "Id", "Name");
            //ViewBag.Reasons = new SelectList((System.Collections.IEnumerable)_afasService.GetReasonsAsync(), "Id", "Title");

            // fake data atm
            var employees = new List<dynamic>
            {
                new { Id = 1, FullName = "Alice Smith" },
                new { Id = 2, FullName = "Bob Johnson" }
            };


            // Fake data for Reasons
            var reasons = new List<dynamic>
            {
                new  { Id = 1, Title = "geboorte", EventPrice = 25, IsAnniversary = true },
                new  { Id = 2, Title = "ziek", EventPrice = 25, IsAnniversary = false },
                new  { Id = 3, Title = "ziekte 3 maanden", EventPrice = 25, IsAnniversary = false },
                new  { Id = 4, Title = "ziekte 3 weken", EventPrice = 25, IsAnniversary = false },
                new  { Id = 5, Title = "ziekte ziekenhuisopname", EventPrice = 25, IsAnniversary = false },
                new  { Id = 6, Title = "huwelijk/geregistreerd partnerschap", EventPrice = 40, IsAnniversary = true },
                new  { Id = 7, Title = "ontslag/fpu/pensionering", EventPrice = 25, IsAnniversary = true },
                new  { Id = 8, Title = "50e verjaardag", EventPrice = 25, IsAnniversary = true },
                new  { Id = 9, Title = "65e verjaardag", EventPrice = 25, IsAnniversary = true },
                new  { Id = 10, Title = "12,5 jaar huwelijk", EventPrice = 25, IsAnniversary = true },
                new  { Id = 11, Title = "12,5 jaar ambtenaar", EventPrice = 25, IsAnniversary = true },
                new  { Id = 12, Title = "25 jaar huwelijk", EventPrice = 25, IsAnniversary = true },
                new  { Id = 13, Title = "overlijden ambtenaar of huisgenoot", EventPrice = 50, IsAnniversary = false },
                new  { Id = 14, Title = "40 jaar ambtenaar", EventPrice = 40, IsAnniversary = true },
                new  { Id = 15, Title = "40 jarig huwelijk", EventPrice = 40, IsAnniversary = true },
                new  { Id = 20, Title = "Verjaardag", EventPrice = 40, IsAnniversary = true },
                new  { Id = 21, Title = "Trouwen", EventPrice = 50, IsAnniversary = true }
            };

            ViewBag.Employees = new SelectList(employees, "Id", "FullName");
            ViewBag.Reasons = new SelectList(reasons, "Id", "Title");

            return View();
        }

        // GET: /AanvraagForm/Success
        [Authorize]
        public IActionResult Success()
        {
            return View();
        }

        // GET: /AanvraagForm/Start

        public IActionResult Start()
        {
            return View();
        }

       
    }
}
