using Habits_Tracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace Habits_Tracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Activities> Activities { get; set; }
        public DbSet<HabitsChart> HabitsChart { get; set; }
        public DbSet<WaterIntake> WaterIntake { get; set; }
    }
}
