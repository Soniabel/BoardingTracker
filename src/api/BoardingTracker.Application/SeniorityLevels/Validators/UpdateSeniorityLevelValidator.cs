using BoardingTracker.Application.SeniorityLevels.Commands.UpdateSeniorityLevel;
using FluentValidation;

namespace BoardingTracker.Application.SeniorityLevels.Validators
{
    public class UpdateSeniorityLevelValidator : AbstractValidator<UpdateSeniorityLevelRequest>
    {
        public UpdateSeniorityLevelValidator()
        {
            RuleFor(seniorityLevel => seniorityLevel.Id).NotNull();
            RuleFor(seniorityLevel => seniorityLevel.Name).NotEmpty().NotNull().MaximumLength(50);
        }
    }
}
