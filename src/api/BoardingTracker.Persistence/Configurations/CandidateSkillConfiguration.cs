using BoardingTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardingTracker.Persistence.Configurations
{
    public class CandidateSkillConfiguration : IEntityTypeConfiguration<CandidateSkill>
    {
        public void Configure(EntityTypeBuilder<CandidateSkill> builder)
        {
            builder.HasKey(e => new { e.CandidateId, e.SkillId });

            builder.HasOne(d => d.Candidate)
                .WithMany()
                .HasForeignKey(d => d.CandidateId)
                .HasConstraintName("FK_CandidateSkill_CandidateId");

            builder.HasOne(d => d.Skill)
                .WithMany()
                .HasForeignKey(d => d.SkillId)
                .HasConstraintName("FK_CandidateSkill_SkillId");
        }
    }

}
