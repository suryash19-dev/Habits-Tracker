using System.ComponentModel.DataAnnotations.Schema;

namespace Habits_Tracker.Entities
{
    public class DailyMetricValue : BaseEntity
    {
        public int MetricDefinitionId { get; set; }
        public required MetricDefinition MetricDefinition { get; set; }

        public DateOnly MetricDate { get; set; }
        public decimal? MetricValue { get; set; }
    }
}
