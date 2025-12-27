using AutoMapper;
using Habits_Tracker.DTO;
using Habits_Tracker.Entities;

namespace Habits_Tracker.Profiles
{
    public class HabitLogProfile : Profile
    {
        public HabitLogProfile()
        {
            CreateMap<HabitLog, HabitLogDto>().ReverseMap();
            CreateMap<HabitLog, HabitLogResponseDto>().ReverseMap();
        }
    }
}
