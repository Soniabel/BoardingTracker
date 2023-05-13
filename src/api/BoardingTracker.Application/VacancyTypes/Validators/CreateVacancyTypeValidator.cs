using BoardingTracker.Application.VacancyTypes.Commands.CreateVacancyType;
using FluentValidation;

namespace BoardingTracker.Application.VacancyTypes.Validators
{
    public class CreateVacancyTypeValidator : AbstractValidator<CreateVacancyTypeRequest>
    {
        public CreateVacancyTypeValidator()
        {
            RuleFor(vacancyType => vacancyType.Name).NotEmpty().NotNull().MaximumLength(50);
        }
    }
}
