using BoardingTracker.Application.VacancyTypes.Commands.DeleteVacancyType;
using FluentValidation;

namespace BoardingTracker.Application.VacancyTypes.Validators
{
    public class DeleteVacancyTypeValidator : AbstractValidator<DeleteVacancyTypeRequest>
    {
        public DeleteVacancyTypeValidator()
        {
            RuleFor(vacancyType => vacancyType.Id).NotNull().NotEmpty();
        }
    }
}
