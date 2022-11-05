namespace BoardingTracker.Domain.Entities
{
    public partial class Vacancy
    {
        public Vacancy()
        {
            Interviews = new HashSet<Interview>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal? Salary { get; set; }
        public int? SeniorityLevelId { get; set; }
        public int? VacancyTypeId { get; set; }
        public int? VacancyStatusId { get; set; }
        public int? RecruiterId { get; set; }

        public virtual Recruiter? Recruiter { get; set; }
        public virtual SeniorityLevel? SeniorityLevel { get; set; }
        public virtual VacancyStatus? VacancyStatus { get; set; }
        public virtual VacancyType? VacancyType { get; set; }
        public virtual ICollection<Interview> Interviews { get; set; }
    }
}
