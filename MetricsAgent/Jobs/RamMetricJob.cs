using MetricsAgent.Models.Metrics;
using MetricsAgent.Models.Repositories;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class RamMetricJob : IJob
    {
        private IRamMetricsRepository _repository;
        private PerformanceCounter _ramCounter;

        public RamMetricJob(IRamMetricsRepository repository)
        {
            _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            _repository = repository;
        }
        public Task Execute(IJobExecutionContext context)
        {
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            var memoryAviable = Convert.ToInt32(_ramCounter.NextValue());

            _repository.Create(new RamMetric { Time = time, Value = memoryAviable });

            return Task.CompletedTask;
        }
    }
}
