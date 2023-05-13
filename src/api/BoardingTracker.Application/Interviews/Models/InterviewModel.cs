using BoardingTracker.Application.Candidates.Models;
using BoardingTracker.Application.InterviewTypes.Models;
using BoardingTracker.Application.Recruiters.Models;
using BoardingTracker.Application.Vacancies.Models;

namespace BoardingTracker.Application.Interviews.Models
{
    public class InterviewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public VacancyModel Vacancy { get; set; }

        public RecruiterModel Recruiter { get; set; }

        public CandidateModel Candidate { get; set; }

        public InterviewTypeModel InterviewType { get; set; }
    }
}
