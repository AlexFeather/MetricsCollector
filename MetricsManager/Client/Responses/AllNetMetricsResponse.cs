using MetricsManager.Client.DAL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Client.Responses
{
    public class AllNetMetricsResponse
    {
        public IList<NetMetricDto> Metrics { get; set; }
    }
}
