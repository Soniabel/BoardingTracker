using BoardingTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardingTracker.Persistence.Configurations
{
    public class VacancyCandidateConfiguration : IEntityTypeConfiguration<VacancyCandidate>
    {
        public void Configure(EntityTypeBuilder<VacancyCandidate> builder)
        {
            builder.HasKey(e => new { e.VacancyId, e.CandidateId });

            builder.HasOne(d => d.Candidate)
                .WithMany()
                .HasForeignKey(d => d.CandidateId)
                .HasConstraintName("FK_VacancyCandidate_CandidateId");

            builder.HasOne(d => d.Vacancy)
                .WithMany()
                .HasForeignKey(d => d.VacancyId)
                .HasConstraintName("FK_VacancyCandidate_VacancyId");
        }
    }
}
