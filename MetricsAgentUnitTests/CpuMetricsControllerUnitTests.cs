using MetricsAgent.Controllers;
using MetricsAgent.Models.Metrics;
using MetricsAgent.Models.Repositories;
using MetricsAgent.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricsAgentUnitTests
{
    public class CpuMetricsControllerUnitTests
    {
        private CpuMetricsController controller;
        private Mock<ICpuMetricsRepository> mockRepo;
        private Mock<ILogger<CpuMetricsController>> mockLogger;

        public CpuMetricsControllerUnitTests()
        {
            mockRepo = new Mock<ICpuMetricsRepository>();
            mockLogger = new Mock<ILogger<CpuMetricsController>>();
            controller = new CpuMetricsController(mockRepo.Object, mockLogger.Object);
        }

        [Fact]
        public void GetByTimePeriod_Should_Return_Ok()
        {
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(50);

            var result = controller.GetMetricsFromTimePeriod(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            mockRepo.Setup(_repository => _repository.Create(It.IsAny<CpuMetric>())).Verifiable();

            var result = controller.Create(new CpuMetricCreateRequest { Time = TimeSpan.FromSeconds(1), Value = 50 });

            mockRepo.Verify(_repository => _repository.Create(It.IsAny<CpuMetric>()), Times.AtMostOnce());
        }

        [Fact]
        public void GetAll_Should_Return_Ok() //вообще не понимаю, как это должно работать
        {
            mockRepo.Setup(_repository => _repository.GetAll()).Verifiable();
            var result = controller.GetAll();

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

    }
}
