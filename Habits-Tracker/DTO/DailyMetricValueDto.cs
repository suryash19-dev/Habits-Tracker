namespace Habits_Tracker.DTO
{
    public class DailyMetricValueDto
    {
        public required int MetricDefinitionId { get; set; }
        public DateOnly MetricDate { get; set; }
        public decimal? MetricValue { get; set; }
    }
}
