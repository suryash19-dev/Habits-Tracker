namespace Habits_Tracker.DTO
{
    public class ActivityDashboardDto
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public List<ActivityDateStatusDto> DatesData { get; set; } = [];
    }
}
