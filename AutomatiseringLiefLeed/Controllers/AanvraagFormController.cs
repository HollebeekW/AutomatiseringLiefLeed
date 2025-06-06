namespace AutomatiseringLiefLeed.Controllers
{
    using global::AutomatiseringLiefLeed.Data;
    using global::AutomatiseringLiefLeed.Models;
    using global::AutomatiseringLiefLeed.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

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

        private async Task<bool> DateCheck(Application model)
        {
            //get selected reason from database
            var reason = await _context.Reasons.FindAsync(model.ReasonId);

            //return error if reason is unselected (not expected, but extra failsafe won't hurt)
            if (reason == null)
            {
                ModelState.AddModelError("ReasonId", "Reason not found!");
                return false;
            }

            //skip the automatic date check when the reason selected is not an anniversary
            if (reason.IsAnniversary == false)
            {
                return true;
            }

            //get selected recipient employee
            var employee = await _context.Employees.FindAsync(model.RecipientId);

            //retrieve whether the selected reason is an anniversary
            //defaulted to false, to force a manual check in case of any error(s)
            bool isAnniversary = reason.IsAnniversary ?? false; 

            var dateOfIssue = model.DateOfIssue?.Date ?? DateTime.MinValue; //issuing date
            double anniversaryYears = reason.AnniversaryYears ?? 0; //amount of years
            string name = reason.Name?.ToLowerInvariant() ?? ""; //get reason name and set to all lowercase, to filter out what type of anniversary to use

            DateTime expectedDate; //expected date of anniversary

            //get name and calculate expected date of anniversary, by adding amount of months to the date of birth or employee starting date
            //for example: employee is born on 01-01-1970 --> 50th birthday will be on 1970 + 50 = 2020 --> 50th anniversary will be calculated as 01-01-2020
            //in months, to account for 12.5th anniversary --> multiplied by 12 to convert back to years
            if (name.Contains("verjaardag"))
            {
                expectedDate = employee.GeboorteDatum.ToDateTime(TimeOnly.MinValue).AddMonths((int)(anniversaryYears * 12));
            }
            else if (name.Contains("ambtenaar"))
            {
                expectedDate = employee.InDienstIVMDienstJaren.ToDateTime(TimeOnly.MinValue).AddMonths((int)(anniversaryYears * 12));
            }
            else
            {
                expectedDate = employee.AOWDatum.ToDateTime(TimeOnly.MinValue); //no calculation needed for retirement, only compare it to the date in the corresponding users' row in the "Employees" table
            }

            //return an error if dates do not match, including date of actual anniversary
            if (expectedDate.Date != dateOfIssue)
            {
                TempData["ErrorMessage"] = $"Error! Verwachte jubileumdatum: {expectedDate:dd-MM-yyyy}";
                return false;
            }

            //Set isAccepted to true
            model.IsAccepted = true;

            //if check passes, set value to true
            return true;
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

            //check if applicant and sender are different,
            if (model.SenderId == model.RecipientId)
            {
                TempData["ErrorMessage"] = "Aanvrager en ontvanger kunnen niet hetzelfde zijn!";
                return View(model);
            }

            //prevent ability to pick a past date
            if (model.DateOfIssue <  DateTime.Now)
            {
                TempData["ErrorMessage"] = "Die datum is al verlopen";
                return View(model);
            }

            model.DateOfApplication = DateTime.Now;
            model.IsAccepted = false;

            //if DateCheck returns false, redirect to application view
            if (!await DateCheck(model))
            {
                return View(model);
            }

            //save to database
            _context.Applications.Add(model);
            await _context.SaveChangesAsync();

            //redirect to next view, along with success message
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
