using BoardingTracker.Application.Skills.Commands.CreateSkill;
using FluentValidation;

namespace BoardingTracker.Application.Skills.Validators
{
    public class CreateSkillValidator : AbstractValidator<CreateSkillRequest>
    {
        public CreateSkillValidator()
        {
            RuleFor(skill => skill.Name).NotEmpty().NotNull().MaximumLength(50);
        }
    }
}
