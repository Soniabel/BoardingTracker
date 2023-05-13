using BoardingTracker.Application.Vacancies.Commands.CreateVacancy;
using FluentValidation;

namespace BoardingTracker.Application.Vacancies.Validators
{
    public class CreateVacancyValidator : AbstractValidator<CreateVacancyRequest>
    {
        public CreateVacancyValidator()
        {
            RuleFor(vacancy => vacancy.Title).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(vacancy => vacancy.Description).NotEmpty().NotNull();
            RuleFor(vacancy => vacancy.Salary).NotNull();
        }
    }
}
