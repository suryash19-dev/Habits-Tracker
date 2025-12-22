using System.ComponentModel.DataAnnotations.Schema;

namespace Habits_Tracker.Entities
{
    public class HabitsChart : BaseEntity
    {
        [ForeignKey(nameof(Activities))]
        public int ActivityId { get; set; }
        public required virtual Activities Activities { get; set; }
        public DateTime Date { get; set; }
        public bool IsDone { get; set; }
    }
}
