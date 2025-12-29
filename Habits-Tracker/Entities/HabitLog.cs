using System.ComponentModel.DataAnnotations.Schema;

namespace Habits_Tracker.Entities
{
    public class HabitLog : BaseEntity
    {
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        public DateOnly LogDate { get; set; }
        public bool IsDone { get; set; }
    }
}
