using Microsoft.AspNetCore.Mvc;
using ArtCommissions.Data;
using System.Security.AccessControl;
using ArtAPI.Services;
using NuGet.Protocol;
using System.Text.Json;

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
        public async Task<string> GetCount(int id)
        {
            _logger.LogInformation($"getting the number of commissions for artist {id}");
            var commissions = await _service.GetCount(id);
            string jsonString = JsonSerializer.Serialize(commissions);
            return jsonString;
        }

        [HttpPost("{email}")]
        public async Task<IActionResult> Index(string email)
        {
            await emailSender.SendEmailAsync(email);
            return Ok();
        }
    }
}
