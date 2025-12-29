using System.ComponentModel.DataAnnotations;

namespace Habits_Tracker.DTO
{
    public class HabitLogDto
    {
        [Required]
        public int ActivityId { get; set; }

        [Required]
        public DateOnly LogDate { get; set; }

        [Range(0, 1000)]
        public bool IsDone { get; set; }
    }
}
