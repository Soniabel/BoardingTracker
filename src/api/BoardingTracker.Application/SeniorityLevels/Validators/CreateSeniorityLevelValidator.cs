using BoardingTracker.Application.SeniorityLevels.Commands.CreateSeniorityLevel;
using FluentValidation;

namespace BoardingTracker.Application.SeniorityLevels.Validators
{
    public class CreateSeniorityLevelValidator : AbstractValidator<CreateSeniorityLevelRequest>
    {
        public CreateSeniorityLevelValidator()
        {
            RuleFor(seniorityLevel => seniorityLevel.Name).NotEmpty().NotNull().MaximumLength(50);
        }
    }
}
