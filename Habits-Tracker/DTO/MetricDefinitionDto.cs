using System.ComponentModel.DataAnnotations;

namespace Habits_Tracker.DTO
{
    public class MetricDefinitionDto
    {
        [Required]
        [MaxLength(100)]
        public required string MetricName { get; set; }

        [MaxLength(100)]
        public string? Unit { get; set; }
    }
}
