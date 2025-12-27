namespace Habits_Tracker.DTO
{
    public class HabitLogResponseDto : HabitLogDto
    {
        public int Id {  get; set; }
        public string? ActivityName { get; set; }
    }
}
