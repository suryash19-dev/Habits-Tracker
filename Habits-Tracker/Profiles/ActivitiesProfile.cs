using AutoMapper;
using Habits_Tracker.DTO;
using Habits_Tracker.Entities;

namespace Habits_Tracker.Profiles
{
    public class ActivitiesProfile : Profile
    {
        public ActivitiesProfile()
        {
            CreateMap<Activities, ActivityDto>().ReverseMap();
            CreateMap<Activities, ActivityResponseDto>().ReverseMap();
        }
    }
}
