using Habits_Tracker.DTO;

namespace Habits_Tracker.Interfaces
{
    public interface IHabitLogService
    {
        Task<ResultDto<List<HabitLogResponseDto>>> GetAllHabitLogs();
    }
}
