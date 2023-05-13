namespace BoardingTracker.Domain.Entities
{
    public partial class VacancySkill
    {
        public int? VacancyId { get; set; }
        public int? SkillId { get; set; }

        public virtual Skill? Skill { get; set; }
        public virtual Vacancy? Vacancy { get; set; }
    }
}
