using MetricsManager.Client.DAL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Client.Responses
{
    public class AllRamMetricsResponse
    {
        public IList<RamMetricDto> Metrics { get; set; }
    }
}
