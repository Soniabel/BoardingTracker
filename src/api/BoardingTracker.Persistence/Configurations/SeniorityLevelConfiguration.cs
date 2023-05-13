using BoardingTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardingTracker.Persistence.Configurations
{
    public class SeniorityLevelConfiguration : IEntityTypeConfiguration<SeniorityLevel>
    {
        public void Configure(EntityTypeBuilder<SeniorityLevel> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(50);
        }
    }
}
