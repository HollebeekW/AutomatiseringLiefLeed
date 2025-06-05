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

            //check if applicant and sender are different,
            if (model.SenderId == model.RecipientId)
            {
                TempData["ErrorMessage"] = "Aanvrager en ontvanger kunnen niet hetzelfde zijn!";
                return View(model);
            }

            //commented out for now for testing purposes

            //if (model.DateOfIssue <  DateTime.Now)
            //{
            //    TempData["ErrorMessage"] = "Die datum is al verlopen";
            //    return View(model);
            //}

            var reason = await _context.Reasons.FindAsync(model.ReasonId);
            if (reason == null)
            {
                ModelState.AddModelError("ReasonId", "Reason not found!");
                return View(model);
            }

            var employee = await _context.Employees.FindAsync(model.RecipientId);

            bool isAnniversary = reason.IsAnniversary ?? false; //in case of error, revert to manual check
            
            if (reason.IsAnniversary == true)
            {
                var dateOfIssue = model.DateOfIssue.Value; //date of issuing
                var anniversaryYears = reason.AnniversaryYears ?? 0; //amount of years, so for "50e verjaardag", value is 50
                var anniversaryDate = DateTime.MinValue.Date; //date of anniversary
                var name = reason.Name?.ToLowerInvariant(); //name of reason

                if (name != null && name.Contains("verjaardag"))
                {
                    //1. Get employees date of birth
                    var birthday = employee.GeboorteDatum.ToDateTime(TimeOnly.MinValue).Date;

                    //2. Calculate date of anniverary by adding amount of years to the birthday
                    //For example: birthday is on 01/01/1970, 50th anniversary will be on 1970+50 = 2020 so 01/01/2020
                    //Calculated in months, to account for the 12.5 year anniversary (multiplied by 12 to convert back to years)
                    var expectedAnniversary = birthday.AddMonths((int)(anniversaryYears * 12));

                    //3. Check if dates are correct
                    //if not, return an error
                    if (expectedAnniversary != dateOfIssue)
                    {
                        TempData["ErrorMessage"] = "Error! Data komen niet overeen"; //todo: expand message, adding dates(?)
                        return View(model);
                    }

                    //else, insert into database
                    model.IsAccepted = true;
                    _context.Applications.Add(model);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Aanvraag succesvol ingediend!";
                }

                else if (name != null && name.Contains("ambtenaar"))
                {
                    //1. Get employees starting date
                    var startingDate = employee.InDienstIVMDienstJaren.ToDateTime(TimeOnly.MinValue).Date;

                    //2. Calculate date of anniversary by adding amount of years to starting date (same method as above)
                    var expectedAnniversary = startingDate.AddMonths((int)(anniversaryYears * 12));

                    //3. Check if dates are correct
                    //if not, return an error
                    if (expectedAnniversary != dateOfIssue)
                    {
                        TempData["ErrorMessage"] = "Error! Data komen niet overeen"; //todo: expand message, adding dates(?)
                        return View(model);
                    }

                    //else, insert into database
                    model.IsAccepted = true;
                    _context.Applications.Add(model);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Aanvraag succesvol ingediend!";
                }
                else
                {
                    anniversaryDate = employee.AOWDatum.ToDateTime(TimeOnly.MinValue).Date;
                    if (model.DateOfIssue == anniversaryDate)
                    {
                        model.IsAccepted = true;
                        _context.Applications.Add(model);
                        await _context.SaveChangesAsync();
                        TempData["SuccessMessage"] = "Aanvraag succesvol ingediend!";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Error! Data komen niet overeen";
                        return View(model);
                    }
                }
            }

            

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
