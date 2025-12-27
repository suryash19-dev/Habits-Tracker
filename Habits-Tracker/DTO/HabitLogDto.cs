namespace Habits_Tracker.DTO
{
    public class HabitLogDto
    {
        public required int ActivityId { get; set; }
        public DateOnly LogDate { get; set; }
        public bool IsDone { get; set; }
    }
}
