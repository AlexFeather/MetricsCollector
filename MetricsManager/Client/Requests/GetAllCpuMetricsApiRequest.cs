using MetricsManager.Client.DAL.Dto;
using MetricsManager.Controllers;
using MetricsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Client.Requests
{
    public class GetAllCpuMetricsApiRequest
    {

        public Uri AgentAdress { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public AgentsController _controller;

        public GetAllCpuMetricsApiRequest(Uri agentAdress, TimeSpan fromTime, TimeSpan toTime)
        {
            FromTime = fromTime;
            ToTime = toTime;
            AgentAdress = agentAdress;
        }
    }
}
