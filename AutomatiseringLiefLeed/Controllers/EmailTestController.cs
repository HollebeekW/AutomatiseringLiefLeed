using AutomatiseringLiefLeed.Services.Email;
using Microsoft.AspNetCore.Mvc;

namespace AutomatiseringLiefLeed.Controllers
{
    public class EmailTestController : Controller
    {
        private readonly IEmailService _emailService;

        public EmailTestController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        //GET: /EmailTest/
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //POST: /EmailTest/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                ModelState.AddModelError("email", "Ongeldig emailadres");
                return View();
            }

            try
            {
                string subject = "Test Email";
                string body = $"Hello {email}!";
                string validationMessage = $"Test Email succesvol verzonden naar {email}!";

                _emailService.SendEmail(email, subject, body);
                ViewBag.Message = validationMessage;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View();
        }
    }
}
