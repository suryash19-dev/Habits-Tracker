namespace Habits_Tracker.Entities
{
    public class MetricDefinition : BaseEntity
    {
        public required string MetricName { get; set; }
        public string? Unit { get; set; }
    }
}
