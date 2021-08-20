using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Models.Dto
{
    public class NetMetricDto
    {
        public TimeSpan Time { get; set; }
        public int ValueDownload { get; set; }
        public int ValueUpload { get; set; }
        public int Id { get; set; }
    }
}
