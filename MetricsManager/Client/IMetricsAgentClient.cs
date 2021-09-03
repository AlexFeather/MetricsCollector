using MetricsManager.Client.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Client.Responses
{
    public interface IMetricsAgentClient
    {
        AllRamMetricsResponse GetAllRamMetrics(GetAllRamMetricsApiRequest request);

        AllCpuMetricsResponse GetAllCpuMetrics(GetAllCpuMetricsApiRequest request);

        AllNetMetricsResponse GetAllNetMetrics(GetAllNetMetricsApiRequest request);

    }
}
