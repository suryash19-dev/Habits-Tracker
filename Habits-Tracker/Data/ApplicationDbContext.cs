using Habits_Tracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace Habits_Tracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Activity> Activities => Set<Activity>();
        public DbSet<HabitLog> HabitLogs => Set<HabitLog>();
        public DbSet<MetricDefinition> MetricDefinitions => Set<MetricDefinition>();
        public DbSet<DailyMetricValue> DailyMetricValues => Set<DailyMetricValue>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ApplicationDbContext).Assembly);
        }
    }
}
