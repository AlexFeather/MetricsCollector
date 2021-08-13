using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/net")]
    [ApiController]
    public class NetMetricsController : ControllerBase
    {
        private readonly ILogger<NetMetricsController> _logger;

        public NetMetricsController(ILogger<NetMetricsController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в MetricsAgent.NetMetricsController");
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromTimePeriod([FromRoute]TimeSpan fromTime, [FromRoute]TimeSpan toTime)
        {
            _logger.LogDebug("MetricsAgent.NetMetricsController.GetMetricsFromTimePeriod вызван.");
            return Ok();
        }
    }
}