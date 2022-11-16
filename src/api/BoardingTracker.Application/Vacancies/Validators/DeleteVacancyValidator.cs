using BoardingTracker.Application.Vacancies.Commands.DeleteVacancy;
using FluentValidation;

namespace BoardingTracker.Application.Vacancies.Validators
{
    public class DeleteVacancyValidator : AbstractValidator<DeleteVacancyRequest>
    {
        public DeleteVacancyValidator()
        {
            RuleFor(vacancy => vacancy.Id).NotNull().NotEmpty();
        }
    }
}
