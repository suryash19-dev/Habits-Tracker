using Habits_Tracker.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Habits_Tracker.Configurations
{
    public class DailyMetricValueConfiguration : IEntityTypeConfiguration<DailyMetricValue>
    {
        public void Configure(EntityTypeBuilder<DailyMetricValue> builder)
        {
            builder.ToTable("DailyMetricValues");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Date)
               .HasColumnType("date")
               .IsRequired();

            builder.Property(d => d.MetricValue)
               .HasPrecision(6, 2);

            builder.HasIndex(d => new { d.MetricDefinitionId, d.Date })
               .IsUnique();

            builder.HasOne(d => d.MetricDefinition)
               .WithMany()
               .HasForeignKey(d => d.MetricDefinitionId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
