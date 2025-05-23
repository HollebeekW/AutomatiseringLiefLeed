namespace AutomatiseringLiefLeed.Controllers
{
    using AutomatiseringLiefLeed.Data;
    using AutomatiseringLiefLeed.Models;
    using AutomatiseringLiefLeed.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    /// <summary>
    /// Defines the <see cref="AanvraagFormController" />
    /// </summary>
    public class AanvraagFormController : Controller
    {
        /// <summary>
        /// Defines the _context
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Defines the _afasService
        /// </summary>
        private readonly AFASService _afasService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AanvraagFormController"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="ApplicationDbContext"/></param>
        /// <param name="afasService">The afasService<see cref="AFASService"/></param>
        public AanvraagFormController(ApplicationDbContext context, AFASService afasService) // Updated constructor
        {
            _context = context;
            _afasService = afasService; // Initialize the missing service
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            var employees = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Alice Smith" },
                new SelectListItem { Value = "2", Text = "Bob Johnson" }
            };

            var reasons = new List<SelectListItem>
{
                new SelectListItem { Value = "1", Text = "geboorte" },
                new SelectListItem { Value = "2", Text = "ziek" },
                new SelectListItem { Value = "3", Text = "ziekte 3 maanden" },
                new SelectListItem { Value = "4", Text = "ziekte 3 weken" },
                new SelectListItem { Value = "5", Text = "ziekenhuisopname" },
                new SelectListItem { Value = "6", Text = "huwelijk/geregistreerd partnerschap" },
                new SelectListItem { Value = "7", Text = "ontslag/fpu/pensionering" },
                new SelectListItem { Value = "8", Text = "50e verjaardag" },
                new SelectListItem { Value = "9", Text = "65e verjaardag" },
                new SelectListItem { Value = "10", Text = "12,5 jaar huwelijk" },
                new SelectListItem { Value = "11", Text = "12,5 jaar ambtenaar" },
                new SelectListItem { Value = "12", Text = "25 jaar huwelijk" },
                new SelectListItem { Value = "13", Text = "overlijden ambtenaar of huisgenoot" },
                new SelectListItem { Value = "14", Text = "40 jaar ambtenaar" },
                new SelectListItem { Value = "15", Text = "40 jarig huwelijk" },
                new SelectListItem { Value = "20", Text = "Verjaardag" },
                new SelectListItem { Value = "21", Text = "Trouwen" }
            };

            ViewBag.EmployeesList = employees;
            ViewBag.Reasons = reasons;

            return View();
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="model">The model<see cref="Application"/></param>
        /// <returns>The <see cref="Task{IActionResult}"/></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(Application model)
        {
            if (!ModelState.IsValid)
            {
                // Herlaad ViewBag data
                var employees = new List<SelectListItem>
                {
                    new SelectListItem { Value = "1", Text = "Alice Smith" },
                    new SelectListItem { Value = "2", Text = "Bob Johnson" }
                };

                // Reasons
                var reasons = new List<SelectListItem>
{
                    new SelectListItem { Value = "1", Text = "geboorte" },
                    new SelectListItem { Value = "2", Text = "ziek" },
                    new SelectListItem { Value = "3", Text = "ziekte 3 maanden" },
                    new SelectListItem { Value = "4", Text = "ziekte 3 weken" },
                    new SelectListItem { Value = "5", Text = "ziekenhuisopname" },
                    new SelectListItem { Value = "6", Text = "huwelijk/geregistreerd partnerschap" },
                    new SelectListItem { Value = "7", Text = "ontslag/fpu/pensionering" },
                    new SelectListItem { Value = "8", Text = "50e verjaardag" },
                    new SelectListItem { Value = "9", Text = "65e verjaardag" },
                    new SelectListItem { Value = "10", Text = "12,5 jaar huwelijk" },
                    new SelectListItem { Value = "11", Text = "12,5 jaar ambtenaar" },
                    new SelectListItem { Value = "12", Text = "25 jaar huwelijk" },
                    new SelectListItem { Value = "13", Text = "overlijden ambtenaar of huisgenoot" },
                    new SelectListItem { Value = "14", Text = "40 jaar ambtenaar" },
                    new SelectListItem { Value = "15", Text = "40 jarig huwelijk" },
                    new SelectListItem { Value = "20", Text = "Verjaardag" },
                    new SelectListItem { Value = "21", Text = "Trouwen" }
            };

                ViewBag.EmployeesList = employees;
                ViewBag.Reasons = reasons;

                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage); // of gebruik logging
                }

                return View(model); // toon formulier opnieuw bij fout
            }

            model.DateOfApplication = DateTime.Now;
            model.IsAccepted = false;

            _context.Applications.Add(model);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Aanvraag succesvol ingediend!";



            return RedirectToAction("Success");
        }

        // GET: /AanvraagForm/Success

        /// <summary>
        /// The Success
        /// </summary>
        /// <returns>The <see cref="IActionResult"/></returns>
        [Authorize]
        public IActionResult Success()
        {
            // NIET VERWIJDEREN
            //ViewBag.Employees = new SelectList((System.Collections.IEnumerable)_afasService.GetEmployeesAsync(), "Id", "FullName");
            //ViewBag.Departments = new SelectList((System.Collections.IEnumerable)_afasService.GetDepartmentsAsync(), "Id", "Name");
            //ViewBag.Reasons = new SelectList((System.Collections.IEnumerable)_afasService.GetReasonsAsync(), "Id", "Title");

            

            return View();
        }

        // GET: /AanvraagForm/Start

        /// <summary>
        /// The Start
        /// </summary>
        /// <returns>The <see cref="IActionResult"/></returns>
        public IActionResult Start()
        {
            return View();
        }
    }
}
