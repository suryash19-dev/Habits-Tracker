using AutoMapper;
using Habits_Tracker.DTO;
using Habits_Tracker.Entities;

namespace Habits_Tracker.Profiles
{
    public class MetricDefinitionProfile : Profile
    {
        public MetricDefinitionProfile()
        {
            CreateMap<MetricDefinition, MetricDefinitionDto>().ReverseMap();
            CreateMap<MetricDefinition, MetricDefinitionResponseDto>().ReverseMap();
        }
    }
}
