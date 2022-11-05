using BoardingTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardingTracker.Persistence.Configurations
{
    public class VacancyConfiguration : IEntityTypeConfiguration<Vacancy>
    {
        public void Configure(EntityTypeBuilder<Vacancy> builder)
        {
            builder.Property(e => e.Salary).HasColumnType("decimal(18, 0)");

            builder.Property(e => e.Title).HasMaxLength(50);

            builder.HasOne(d => d.Recruiter)
                .WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.RecruiterId)
                .HasConstraintName("FK_Vacancies_RecruiterId");

            builder.HasOne(d => d.SeniorityLevel)
                .WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.SeniorityLevelId)
                .HasConstraintName("FK_Vacancies_SeniorityLevelId");

            builder.HasOne(d => d.VacancyStatus)
                .WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.VacancyStatusId)
                .HasConstraintName("FK_Vacancies_VacancyStatusId");

            builder.HasOne(d => d.VacancyType)
                .WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.VacancyTypeId)
                .HasConstraintName("FK_Vacancies_VacancyTypeId");
        }
    }
}
