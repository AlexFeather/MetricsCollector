using MetricsAgent.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Models.Responses
{
    public class RamMetricsResponse
    {
        public IList<RamMetricDto> Metrics { get; set; }
    }
}
