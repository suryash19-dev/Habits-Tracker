namespace Habits_Tracker.Entities
{
    public class WaterIntake : BaseEntity
    {
        public required int WaterQuantity { get; set; }
        public DateTime Date { get; set; }
    }
}
