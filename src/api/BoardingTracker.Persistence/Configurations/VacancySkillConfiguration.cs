using BoardingTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardingTracker.Persistence.Configurations
{
    public class VacancySkillConfiguration : IEntityTypeConfiguration<VacancySkill>
    {
        public void Configure(EntityTypeBuilder<VacancySkill> builder)
        {
            builder.HasKey(e => new { e.SkillId, e.VacancyId });

            builder.HasOne(d => d.Skill)
                .WithMany()
                .HasForeignKey(d => d.SkillId)
                .HasConstraintName("FK_VacancySkill_SkillId");

            builder.HasOne(d => d.Vacancy)
                .WithMany()
                .HasForeignKey(d => d.VacancyId)
                .HasConstraintName("FK_VacancySkill_VacancyId");
        }
    }
}
