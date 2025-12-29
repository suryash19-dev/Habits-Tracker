using Habits_Tracker.DTO;

namespace Habits_Tracker.Interfaces
{
    public interface IDashboardService
    {
        Task<ResultDto<DashboardResponseDto>> GetDashboardAsync(DateOnly date);
    }
}
