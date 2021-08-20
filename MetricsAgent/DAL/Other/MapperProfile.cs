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
            CreateMap<NetMetric, NetMetricDto>();
            CreateMap<RamMetric, RamMetricDto>();

            CreateMap<CpuMetricDto, CpuMetric>();
            CreateMap<NetMetricDto, NetMetric>();
            CreateMap<RamMetricDto, RamMetric>();
        }
    }
}
