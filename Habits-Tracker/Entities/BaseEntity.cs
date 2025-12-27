using System.ComponentModel.DataAnnotations;

namespace Habits_Tracker.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
