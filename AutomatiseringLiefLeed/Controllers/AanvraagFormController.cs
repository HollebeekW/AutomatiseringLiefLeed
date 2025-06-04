namespace AutomatiseringLiefLeed.Controllers
{
    using global::AutomatiseringLiefLeed.Data;
    using global::AutomatiseringLiefLeed.Models;
    using global::AutomatiseringLiefLeed.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    /// <summary>
    /// Defines the <see cref="AanvraagFormController" />
    /// </summary>
    public class AanvraagFormController : Controller
    {

        private readonly ApplicationDbContext _context;

        private readonly AFASService _afasService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AanvraagFormController"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="ApplicationDbContext"/></param>
        /// <param name="afasService">The afasService<see cref="AFASService"/></param>
        
        private void PopulateDropdownLists()
        {
            var employees = _context.Employees
                .Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = e.Roepnaam + " " + e.Achternaam
                })
                .ToList();

            var reasons = _context.Reasons
                .Select(r => new SelectListItem
                {
                    Value = r.Id.ToString(),
                    Text = r.Name + " (€" + r.GiftAmount.ToString() + ")" //Ugly formatting, but it works
                })
                .ToList();

            ViewBag.Employees = employees;
            ViewBag.Reasons = reasons;
        }

        public AanvraagFormController(ApplicationDbContext context, AFASService afasService) // Updated constructor
        {
            _context = context;
            _afasService = afasService; // Initialize the missing service
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            //initialise viewbags
            PopulateDropdownLists();

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
            //initialise viewbags
            PopulateDropdownLists();

            if (!ModelState.IsValid)
            {
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
