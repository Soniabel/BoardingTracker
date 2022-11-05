using BoardingTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardingTracker.Persistence.Configurations
{
    public class InterviewTypeConfiguration : IEntityTypeConfiguration<InterviewType>
    {
        public void Configure(EntityTypeBuilder<InterviewType> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(50);
        }
    }
}
