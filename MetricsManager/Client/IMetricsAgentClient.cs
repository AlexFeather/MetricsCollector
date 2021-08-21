using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Client.Responses
{
    interface IMetricsAgentClient
    {
        AllRamMetricsApiResponse GetAllRamMetrics(GetAllRamMetricsApiRequest request);

        DonNetMetricsApiResponse GetDonNetMetrics(DonNetHeapMetrisApiRequest request);

        AllCpuMetricsApiResponse GetCpuMetrics(GetAllCpuMetricsApiRequest request);

    }
}
