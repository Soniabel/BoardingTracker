using BoardingTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardingTracker.Persistence.Configurations
{
    public class VacancyStatusConfiguration : IEntityTypeConfiguration<VacancyStatus>
    {
        public void Configure(EntityTypeBuilder<VacancyStatus> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(50);
        }
    }
}
