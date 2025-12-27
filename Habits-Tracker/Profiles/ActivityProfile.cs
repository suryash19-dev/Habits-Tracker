using AutoMapper;
using Habits_Tracker.DTO;
using Habits_Tracker.Entities;

namespace Habits_Tracker.Profiles
{
    public class ActivityProfile : Profile
    {
        public ActivityProfile()
        {
            CreateMap<Activity, ActivityDto>().ReverseMap();
            CreateMap<Activity, ActivityResponseDto>().ReverseMap();
        }
    }
}
