namespace BoardingTracker.Domain.Entities
{
    public partial class VacancyCandidate
    {
        public int? VacancyId { get; set; }
        public int? CandidateId { get; set; }

        public virtual Candidate? Candidate { get; set; }
        public virtual Vacancy? Vacancy { get; set; }
    }
}
