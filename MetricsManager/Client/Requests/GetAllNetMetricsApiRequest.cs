using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Client.Requests
{
    public class GetAllNetMetricsApiRequest
    {
        public int AgentAdress { get; }
        public TimeSpan FromTime { get; }
        public TimeSpan ToTime { get; }

        public GetAllNetMetricsApiRequest(int agentAdress, TimeSpan fromTime, TimeSpan toTime)
        {
            AgentAdress = agentAdress;
            FromTime = fromTime;
            ToTime = toTime;
        }
    }
}
