using BoardingTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardingTracker.Persistence.Configurations
{
    public class VacancyTypeConfiguration : IEntityTypeConfiguration<VacancyType>
    {
        public void Configure(EntityTypeBuilder<VacancyType> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(50);
        }
    }
}
