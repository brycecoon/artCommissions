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
        public CommissionRequestController(ILogger<CommissionRequestController> logger, ICommissionService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<int> GetCount(int id)
        {
            _logger.LogInformation($"getting the number of commissions for artist {id}");
            var commissions = await _service.GetCount(id);
            return commissions;
        }
    }

}
