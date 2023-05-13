using BoardingTracker.Application.SeniorityLevels.Commands.DeleteSeniorityLevel;
using FluentValidation;

namespace BoardingTracker.Application.SeniorityLevels.Validators
{
    public class DeleteSeniorityLevelValidator : AbstractValidator<DeleteSeniorityLevelRequest>
    {
        public DeleteSeniorityLevelValidator()
        {
            RuleFor(seniorityLevel => seniorityLevel.Id).NotNull().NotEmpty();
        }
    }
}
