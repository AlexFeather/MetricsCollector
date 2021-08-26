using MetricsManager.Models;
using System.Collections.Generic;

namespace MetricsManager.Client.Responses
{
    public class AllAgentsResponse
    {
        public IList<AgentInfo> Agents { get; set; }
    }
}
