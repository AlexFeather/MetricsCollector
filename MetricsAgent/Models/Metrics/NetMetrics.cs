﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Models.Metrics
{
    public class NetMetrics
    {
        int Id { get; set; }
        int Value { get; set; }
        TimeSpan Time { get; set; }
    }
}
