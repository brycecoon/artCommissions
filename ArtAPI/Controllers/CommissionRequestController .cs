using Microsoft.AspNetCore.Mvc;
using ArtCommissions.Data;
using System.Security.AccessControl;
using ArtAPI.Services;

namespace ArtAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommissionRequestController : Controller
    {
        private readonly ILogger<CommissionRequestController> _logger;
        private ICommissionService _service;
        private readonly IEmailSender emailSender;
        public CommissionRequestController(ILogger<CommissionRequestController> logger, ICommissionService service, IEmailSender emailSender)
        {
            _logger = logger;
            _service = service;
            this.emailSender = emailSender;
        }

        [HttpGet("{id}")]
        public async Task<int> GetCount(int id)
        {
            _logger.LogInformation($"getting the number of commissions for artist {id}");
            int commissions = await _service.GetCount(id);



            return commissions;
        }

        [HttpPost("{email}")]
        public async Task<IActionResult> Index(string email)
        {
            await emailSender.SendEmailAsync(email);
            return Ok();
        }
    }
}
