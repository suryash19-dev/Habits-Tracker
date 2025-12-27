namespace Habits_Tracker.Entities
{
    public class Activity : BaseEntity
    {
        public required string ActivityName { get; set; }
        public string? ActivityDetails { get; set; }
    }
}
