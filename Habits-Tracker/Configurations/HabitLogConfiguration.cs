using Habits_Tracker.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Habits_Tracker.Configurations
{
    public class HabitLogConfiguration : IEntityTypeConfiguration<HabitLog>
    {
        public void Configure(EntityTypeBuilder<HabitLog> builder)
        {
            builder.ToTable("HabitLogs");

            builder.HasKey(h => h.Id);

            builder.Property(h => h.LogDate)
                .HasColumnType("date")
                .IsRequired();

            builder.HasIndex(h => new { h.ActivityId, h.LogDate })
               .IsUnique();

            builder.HasOne(h => h.Activity)
                .WithMany()
                .HasForeignKey(h => h.ActivityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
