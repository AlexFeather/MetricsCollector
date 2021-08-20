using MetricsAgent.Models.Repositories;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class NetMetricJob : IJob
    {
        private INetMetricsRepository _repository;
        public NetMetricJob(INetMetricsRepository repository)
        {
            _repository = repository;
        }
        public Task Execute(IJobExecutionContext context)
        {
            return Task.CompletedTask;
        }
    }
}
