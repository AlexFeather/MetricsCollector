using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Models.Metrics
{
    public class NetMetric
    {
        public int Id { get; set; }
        public int ValueDownload { get; set; }
        public int ValueUpload { get; set; }
        public TimeSpan Time { get; set; }
    }
}
