namespace Habits_Tracker.DTO
{
    public class DailyMetricValueDto
    {
        public required int MetricDefinitionId { get; set; }
        public DateOnly Date { get; set; }
        public decimal? MetricValue { get; set; }
    }
}
