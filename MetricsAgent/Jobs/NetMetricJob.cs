using MetricsAgent.Models.Repositories;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class NetMetricJob : IJob
    {
        private INetMetricsRepository _repository;
        private PerformanceCounterCategory category;
        private string[] instances;

        PerformanceCounter[] dataSentCounters;
        PerformanceCounter[] dataReceivedCounters;
        public NetMetricJob(INetMetricsRepository repository)
        {
            category = new PerformanceCounterCategory("Network Interface");
            instances = category.GetInstanceNames();
            _repository = repository;

            if (instances.Length > 0)
            {
                dataSentCounters = new PerformanceCounter[instances.Length];
                dataReceivedCounters = new PerformanceCounter[instances.Length];

                for (int i = 0; i < instances.Length; i++)
                {
                    dataReceivedCounters[i] = new PerformanceCounter(category.CategoryName, "Bytes Received/sec", instances[i]);
                    dataSentCounters[i] = new PerformanceCounter(category.CategoryName, "Bytes Sent/sec", instances[i]);
                }
            }
        }
        public Task Execute(IJobExecutionContext context)
        {
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            int uploadSpeed = 0;
            int downloadSpeed = 0;

            for (int i = 0; i < instances.Length; i++)
            {
                uploadSpeed += Convert.ToInt32(dataReceivedCounters[i].NextValue());
                downloadSpeed += Convert.ToInt32(dataSentCounters[i].NextValue());
            }

            _repository.Create(new Models.Metrics.NetMetric
            {
                Time = time,
                ValueDownload = downloadSpeed,
                ValueUpload = uploadSpeed
            });

            return Task.CompletedTask;
        }
    }
}
