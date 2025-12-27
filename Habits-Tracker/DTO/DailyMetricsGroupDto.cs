namespace Habits_Tracker.DTO
{
    public class DailyMetricsGroupDto
    {
        public DateOnly Date {  get; set; }
        public List<DailyMetricValueResponseDto> Metrics { get; set; } = [];
    }
}
