namespace Habits_Tracker.DTO
{
    public class DashboardResponseDto
    {
        public List<DailyMetricsGroupDto> DailyMetrics { get; set; } = [];
        public List<ActivityDashboardDto> Activities { get; set; } = [];
    }
}
