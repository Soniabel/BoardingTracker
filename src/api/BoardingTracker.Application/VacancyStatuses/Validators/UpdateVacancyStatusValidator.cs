using BoardingTracker.Application.VacancyStatuses.Commands.UpdateVacancyStatus;
using FluentValidation;

namespace BoardingTracker.Application.VacancyStatuses.Validators
{
    public class UpdateVacancyStatusValidator : AbstractValidator<UpdateVacancyStatusRequest>
    {
        public UpdateVacancyStatusValidator()
        {
            RuleFor(vacancyStatus => vacancyStatus.Id).NotNull();
            RuleFor(vacancyStatus => vacancyStatus.Name).NotEmpty().NotNull().MaximumLength(50);
        }
    }
}
