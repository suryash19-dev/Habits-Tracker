using System.ComponentModel.DataAnnotations;

namespace Habits_Tracker.DTO
{
    public class ActivityDto
    {
        [Required]
        [MaxLength(100)]
        public required string ActivityName { get; set; }

        [MaxLength(250)]
        public string? ActivityDetails { get; set; }
    }
}
