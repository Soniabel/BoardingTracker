using BoardingTracker.Application.Recruiters.Models;
using BoardingTracker.Application.SeniorityLevels.Models;
using BoardingTracker.Application.VacancyStatuses.Models;
using BoardingTracker.Application.VacancyTypes.Models;

namespace BoardingTracker.Application.Vacancies.Models
{
    public class VacancyModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal? Salary { get; set; }

        public SeniorityLevelModel SeniorityLevel { get; set; }

        public VacancyTypeModel VacancyType { get; set; }

        public VacancyStatusModel VacancyStatus { get; set; }

        public RecruiterModel Recruiter { get; set; }
    }
}
