using BoardingTracker.Application.Skills.Models;
using MediatR;

namespace BoardingTracker.Application.Vacancies.Queries.GetVacancySkills
{
    public class GetSkillsByVacancyIdRequest : IRequest<SkillList>
    {
        public int Id { get; set; }
    }
}
