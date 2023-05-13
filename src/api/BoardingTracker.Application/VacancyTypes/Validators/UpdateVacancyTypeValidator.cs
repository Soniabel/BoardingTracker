using BoardingTracker.Application.VacancyTypes.Commands.UpdateVacancyType;
using FluentValidation;

namespace BoardingTracker.Application.VacancyTypes.Validators
{
    public class UpdateVacancyTypeValidator : AbstractValidator<UpdateVacancyTypeRequest>
    {
        public UpdateVacancyTypeValidator()
        {
            RuleFor(vacancyType => vacancyType.Id).NotNull();
            RuleFor(vacancyType => vacancyType.Name).NotEmpty().NotNull().MaximumLength(50);
        }
    }
}
