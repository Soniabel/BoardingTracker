using BoardingTracker.Application.SeniorityLevels.Queries.GetSeniorityLevelsById;
using FluentValidation;

namespace BoardingTracker.Application.SeniorityLevels.Validators
{
    public class GetSeniorityLevelByIdValidator : AbstractValidator<GetSeniorityLevelByIdRequest>
    {
        public GetSeniorityLevelByIdValidator()
        {
            RuleFor(seniorityLevel => seniorityLevel.Id).NotNull().NotEmpty();
        }
    }
}
