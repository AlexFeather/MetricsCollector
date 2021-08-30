using MetricsManager.Client.Repositories;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Jobs
{
    public class NetMetricsJob
    {
        private INetMetricsRepository _repository;

        public NetMetricsJob(INetMetricsRepository repository)
        {
            _repository = repository;
        }

        public Task Execute(IJobExecutionContext context)
        {
            return Task.CompletedTask;
        }
    }
}
