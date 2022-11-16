using BoardingTracker.Application.VacancyStatuses.Commands.DeleteVacancyStatus;
using FluentValidation;

namespace BoardingTracker.Application.VacancyStatuses.Validators
{
    public class DeleteVacancyStatusValidator : AbstractValidator<DeleteVacancyStatusRequest>
    {
        public DeleteVacancyStatusValidator()
        {
            RuleFor(vacancyStatus => vacancyStatus.Id).NotNull().NotEmpty();
        }
    }
}
