using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
    [Route("api/net/metrics")]
    [ApiController]
    public class NetMetricsController : ControllerBase
    {
        private readonly ILogger<NetMetricsController> _logger;

        public NetMetricsController(ILogger<NetMetricsController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в MetricsManager.NetMetricsController");
        }

        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogDebug("MetricsManager.NetMetricsController.GetMetricsFromAgent вызван.");
            return Ok();
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogDebug("MetricsManager.NetMetricsController.GetMetricsFromAllCluster вызван.");
            return Ok();
        }
    }
}