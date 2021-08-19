using AutoMapper;
using MetricsAgent.Models.Dto;
using MetricsAgent.Models.Metrics;

namespace MetricsAgent.DAL.Other
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetric, CpuMetricDto>();
        }
    }
}
