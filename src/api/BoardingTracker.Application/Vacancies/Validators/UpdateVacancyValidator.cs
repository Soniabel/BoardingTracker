using BoardingTracker.Application.Vacancies.Commands.UpdateVacancy;
using FluentValidation;

namespace BoardingTracker.Application.Vacancies.Validators
{
    public class UpdateVacancyValidator : AbstractValidator<UpdateVacancyRequest>
    {
        public UpdateVacancyValidator()
        {
            RuleFor(vacancy => vacancy.Id).NotNull();
            RuleFor(vacancy => vacancy.Title).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(vacancy => vacancy.Description).NotEmpty().NotNull();
            RuleFor(vacancy => vacancy.Salary).NotNull();
        }
    }
}
