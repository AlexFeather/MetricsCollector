using MetricsManager.Client.DAL.Dto;
using MetricsManager.Client.Requests;
using MetricsManager.Client.Responses;
using MetricsManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        private readonly ILogger<CpuMetricsController> _logger;
        private readonly AgentsController _agentsController;
        private readonly MetricsAgentClient _agentClient;


        public CpuMetricsController(ILogger<CpuMetricsController> logger, AgentsController agentsController, MetricsAgentClient agentClient)
        {
            _agentsController = agentsController;
            _agentClient = agentClient;
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в MetricsManager.CpuMetricsController");
        }

        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation("MetricsManager.CpuMetricsController.GetMetricsFromAgent вызван.");

            Uri agentAdress;
            AgentInfo agent;
            IList<CpuMetricDto> metrics;

            var agentsList = (List<AgentInfo>)_agentsController.GetList();
            if (agentsList.Count > 0)
            {
                agent = agentsList.Find(x => x.AgentId == agentId);
                agentAdress = agent.AgentAddress;
                metrics = (IList<CpuMetricDto>)_agentClient.GetAllCpuMetrics(new GetAllCpuMetricsApiRequest(agentAdress, fromTime, toTime));
                return Ok(metrics);
            }
            else 
            {
                return Ok();
            }


        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogDebug("MetricsManager.CpuMetricsController.GetMetricsFromAllCluster вызван.");
            return Ok();
        }
    }
}