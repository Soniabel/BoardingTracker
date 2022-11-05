using BoardingTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardingTracker.Persistence.Configurations
{
    public class InterviewConfiguration : IEntityTypeConfiguration<Interview>
    {
        public void Configure(EntityTypeBuilder<Interview> builder)
        {
            builder.Property(e => e.EndTime).HasColumnType("datetime");

            builder.Property(e => e.StartTime).HasColumnType("datetime");

            builder.Property(e => e.Title).HasMaxLength(50);

            builder.HasOne(d => d.Candidate)
                .WithMany(p => p.Interviews)
                .HasForeignKey(d => d.CandidateId)
                .HasConstraintName("FK_Interviews_CandidateId");

            builder.HasOne(d => d.InterviewType)
                .WithMany(p => p.Interviews)
                .HasForeignKey(d => d.InterviewTypeId)
                .HasConstraintName("FK_Interviews_InterviewTypeId");

            builder.HasOne(d => d.Recruiter)
                .WithMany(p => p.Interviews)
                .HasForeignKey(d => d.RecruiterId)
                .HasConstraintName("FK_Interviews_RecruiterId");

            builder.HasOne(d => d.Vacancy)
                .WithMany(p => p.Interviews)
                .HasForeignKey(d => d.VacancyId)
                .HasConstraintName("FK_Interviews_VacancyId");
        }
    }
}
