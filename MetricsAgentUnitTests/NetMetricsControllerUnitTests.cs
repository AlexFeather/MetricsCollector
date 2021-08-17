using MetricsAgent.Controllers;
using MetricsAgent.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricsAgentUnitTests
{
    public class NetMetricsControllerUnitTests
    {
        private NetMetricsController controller;
        private Mock<NetMetricsRepository> mockRepo;
        private Mock<ILogger<NetMetricsController>> mockLogger;

        public NetMetricsControllerUnitTests()
        {
            mockRepo = new Mock<NetMetricsRepository>();
            mockLogger = new Mock<ILogger<NetMetricsController>>();
            controller = new NetMetricsController(mockRepo.Object, mockLogger.Object);
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
