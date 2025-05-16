using AutomatiseringLiefLeed.Data;
using AutomatiseringLiefLeed.Services;
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

            // Fake data for Departments
            var departments = new List<dynamic>
            {
                new { Id = 1, Name = "HR" },
                new { Id = 2, Name = "IT" }
            };

            // Fake data for Reasons
            var reasons = new List<dynamic>
            {
                new { Id = 1, Title = "Birthday" },
                new { Id = 2, Title = "Anniversary" }
            };

            ViewBag.Employees = new SelectList(employees, "Id", "FullName");
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            ViewBag.Reasons = new SelectList(reasons, "Id", "Title");

            return View();
        }

        // GET: /AanvraagForm/Success
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
