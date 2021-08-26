using MetricsManager.Client.Repositories;
using MetricsManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly ILogger<AgentsController> _logger;
        private IAgentsRepository _repository;

        public AgentsController(IAgentsRepository repository, ILogger<AgentsController> logger)
        {
            _repository = repository;
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в MetricsManager.AgentsController");
        }

        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody]string agentAdress)
        {
            _logger.LogDebug("MetricsManager.AgentsController.RegisterAgent вызван.");
            _repository.Create(new Uri(agentAdress));
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

            var response = _repository.GetList();
            return Ok(response);
        }

    }
}