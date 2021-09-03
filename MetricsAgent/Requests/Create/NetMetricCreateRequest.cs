using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Models.Requests
{
    public class NetMetricCreateRequest
    {
        public TimeSpan Time { get; set; }
        public int ValueDownload { get; set; }
        public int ValueUpload { get; set; }
    }
}
