namespace BoardingTracker.Domain.Entities
{
    public partial class Interview
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? VacancyId { get; set; }
        public Guid? RecruiterId { get; set; }
        public Guid? CandidateId { get; set; }
        public int? InterviewTypeId { get; set; }

        public virtual Candidate? Candidate { get; set; }
        public virtual InterviewType? InterviewType { get; set; }
        public virtual Recruiter? Recruiter { get; set; }
        public virtual Vacancy? Vacancy { get; set; }
    }
}
