using System.ComponentModel.DataAnnotations.Schema;

namespace Habits_Tracker.Entities
{
    public class DailyMetricValue : BaseEntity
    {
        public int MetricDefinitionId { get; set; }
        public MetricDefinition MetricDefinition { get; set; }

        public DateOnly Date { get; set; }
        public decimal? MetricValue { get; set; }
    }
}
