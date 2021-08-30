﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Models
{
    public class CpuMetric
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public TimeSpan Time { get; set; }
        public int Value { get; set; }
    }
}