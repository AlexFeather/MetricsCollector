using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.Models.Dto;
using MetricsAgent.Models.Metrics;
using MetricsAgent.Models.Repositories;
using MetricsAgent.Models.Requests;
using MetricsAgent.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/net")]
    [ApiController]
    public class NetMetricsController : ControllerBase
    {
        private INetMetricsRepository _repository;
        private readonly ILogger<NetMetricsController> _logger;

        public NetMetricsController(INetMetricsRepository repository, ILogger<NetMetricsController> logger)
        {
            _repository = repository;
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в MetricsAgent.NetMetricsController");
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromTimePeriod([FromRoute]TimeSpan fromTime, [FromRoute]TimeSpan toTime)
        {
            _logger.LogDebug("MetricsAgent.NetMetricsController.GetMetricsFromTimePeriod вызван.");

            var metrics = _repository.GetByTimePeriod(fromTime, toTime);
            var response = new NetMetricsResponse()

            {
                Metrics = new List<NetMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(new NetMetricDto { Time = metric.Time, Value = metric.Value, Id = metric.Id });
            }

            return Ok(response);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] NetMetricCreateRequest request)
        {
            _logger.LogDebug("MetricsAgent.NetMetricsController.Create вызван.");
            _repository.Create(new NetMetric
            {
                Value = request.Value,
                Time = request.Time
            });

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            _logger.LogDebug("MetricsAgent.NetMetricsController.GetAll вызван.");
            var metrics = _repository.GetAll();

            var response = new NetMetricsResponse()
            {
                Metrics = new List<NetMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(new NetMetricDto { Time = metric.Time, Value = metric.Value, Id = metric.Id });
            }

            return Ok(response);

        }
    }
}