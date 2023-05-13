using BoardingTracker.Application.Vacancies.Queries.GetVacancySkills;
using FluentValidation;

namespace BoardingTracker.Application.Vacancies.Validators
{
    public class GetSkillsByVacancyIdValidator : AbstractValidator<GetSkillsByVacancyIdRequest>
    {
        public GetSkillsByVacancyIdValidator()
        {
            RuleFor(vacancy => vacancy.Id).NotNull().NotEmpty();
        }
    }
}
