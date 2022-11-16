using BoardingTracker.Application.VacancyTypes.Queries.GetVacancyTypesById;
using FluentValidation;

namespace BoardingTracker.Application.VacancyTypes.Validators
{
    public class GetVacancyTypeByIdValidator : AbstractValidator<GetVacancyTypeByIdRequest>
    {
        public GetVacancyTypeByIdValidator()
        {
            RuleFor(vacancyType => vacancyType.Id).NotNull().NotEmpty();
        }
    }
}
