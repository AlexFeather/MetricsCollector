using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Client.DAL.Dto
{
    public class NetMetricDto
    {
        public int Id { get; set; }
        public int ValueDownload { get; set; }
        public int ValueUpload { get; set; }
        public TimeSpan Time { get; set; }
        public int AgentId { get; set; }
    }
}
