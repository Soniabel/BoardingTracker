using BoardingTracker.Application.Vacancies.Queries.GetVacanciesById;
using FluentValidation;

namespace BoardingTracker.Application.Vacancies.Validators
{
    public class GetVacancyByIdValidator : AbstractValidator<GetVacancyByIdRequest>
    {
        public GetVacancyByIdValidator()
        {
            RuleFor(vacancy => vacancy.Id).NotNull().NotEmpty();
        }
    }
}
