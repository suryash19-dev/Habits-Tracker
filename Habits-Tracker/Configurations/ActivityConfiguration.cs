using Habits_Tracker.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Habits_Tracker.Configurations
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.ToTable("Activities");

            builder.HasIndex(a => a.ActivityName)
                .IsUnique();

            builder.HasKey(a => a.Id);

            builder.Property(a => a.ActivityName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.ActivityDetails)
                .HasMaxLength(255);
        }
    }
}
