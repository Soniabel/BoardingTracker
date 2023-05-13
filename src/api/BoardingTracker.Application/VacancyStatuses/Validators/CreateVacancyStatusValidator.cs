using BoardingTracker.Application.VacancyStatuses.Commands.CreateVacancyStatus;
using FluentValidation;

namespace BoardingTracker.Application.VacancyStatuses.Validators
{
    public class CreateVacancyStatusValidator : AbstractValidator<CreateVacancyStatusRequest>
    {
        public CreateVacancyStatusValidator()
        {
            RuleFor(vacancyStatus => vacancyStatus.Name).NotEmpty().NotNull().MaximumLength(50);
        }
    }
}
