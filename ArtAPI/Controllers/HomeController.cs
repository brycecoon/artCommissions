using ArtAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailSender emailSender;

        public HomeController(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        [HttpPost("{email}")]
        public async Task<IActionResult> Index(string email)
        {
            await emailSender.SendEmailAsync(email);
            return View();
        }
    }
}
