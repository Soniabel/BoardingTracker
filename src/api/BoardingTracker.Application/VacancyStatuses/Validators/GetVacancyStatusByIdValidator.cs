using BoardingTracker.Application.VacancyStatuses.Queries.GetVacancyStatusesById;
using FluentValidation;

namespace BoardingTracker.Application.VacancyStatuses.Validators
{
    public class GetVacancyStatusByIdValidator : AbstractValidator<GetVacancyStatusByIdRequest>
    {
        public GetVacancyStatusByIdValidator()
        {
            RuleFor(vacancyStatus => vacancyStatus.Id).NotNull().NotEmpty();
        }
    }
}
