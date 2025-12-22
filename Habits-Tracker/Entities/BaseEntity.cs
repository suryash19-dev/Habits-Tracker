using System.ComponentModel.DataAnnotations;

namespace Habits_Tracker.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
