using MetricsManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly ILogger<AgentsController> _logger;

        public AgentsController(ILogger<AgentsController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в MetricsManager.AgentsController");
        }

        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {
            _logger.LogDebug("MetricsManager.AgentsController.RegisterAgent вызван.");
            return Ok();
        }

        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            _logger.LogDebug("MetricsManager.AgentsController.EnableAgentById вызван.");
            return Ok();
        }

        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            _logger.LogDebug("MetricsManager.AgentsController.DisableAgentById вызван.");
            return Ok();
        }

        [HttpGet("getList")]
        public IActionResult GetList()
        {
            _logger.LogDebug("MetricsManager.AgentsController.GetList вызван.");
            return Ok();
        }

    }
}