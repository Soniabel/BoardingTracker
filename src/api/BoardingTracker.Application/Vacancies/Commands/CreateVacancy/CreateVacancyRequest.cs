using BoardingTracker.Application.Vacancies.Models;
using MediatR;

namespace BoardingTracker.Application.Vacancies.Commands.CreateVacancy
{
    public class CreateVacancyRequest : IRequest<VacancyModel>
    {
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal? Salary { get; set; }

        public int SeniorityLevelId { get; set; }

        public int VacancyTypeId { get; set; }

        public int VacancyStatusId { get; set; }

        public Guid RecruiterId { get; set; }
    }
}
