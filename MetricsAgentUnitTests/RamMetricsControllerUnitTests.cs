using MetricsAgent.Controllers;
using MetricsAgent.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricsAgentUnitTests
{
    public class RamMetricsControllerUnitTests
    {
        private RamMetricsController controller;
        private Mock<RamMetricsRepository> mockRepo;
        private Mock<ILogger<RamMetricsController>> mockLogger;

        public RamMetricsControllerUnitTests()
        {
            mockRepo = new Mock<RamMetricsRepository>();
            mockLogger = new Mock<ILogger<RamMetricsController>>();
            controller = new RamMetricsController(mockRepo.Object, mockLogger.Object);
        }

        [Fact]
        public void GetByTimePeriod_ReturnsOk()
        {
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(50);

            var result = controller.GetMetricsFromTimePeriod(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
