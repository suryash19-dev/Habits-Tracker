using Habits_Tracker.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Habits_Tracker.Configurations
{
    public class MetricDefinitionConfiguration : IEntityTypeConfiguration<MetricDefinition>
    {
        public void Configure(EntityTypeBuilder<MetricDefinition> builder)
        {
            builder.ToTable("MetricDefinitions");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.MetricName)
               .IsRequired()
               .HasMaxLength(50);

            builder.HasIndex(m => m.MetricName)
               .IsUnique();

            builder.Property(m => m.Unit)
               .HasMaxLength(20);
        }
    }
}
