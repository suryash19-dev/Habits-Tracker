using AutoMapper;
using Habits_Tracker.DTO;
using Habits_Tracker.Entities;

namespace Habits_Tracker.Profiles
{
    public class DailyMetricValueProfile : Profile
    {
        public DailyMetricValueProfile()
        {
            CreateMap<DailyMetricValue, DailyMetricValueDto>().ReverseMap();
            CreateMap<DailyMetricValue, DailyMetricValueResponseDto>().ReverseMap();
        }
    }
}
