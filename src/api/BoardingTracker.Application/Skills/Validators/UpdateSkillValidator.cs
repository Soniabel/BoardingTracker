using BoardingTracker.Application.Skills.Commands.UpdateSkill;
using FluentValidation;

namespace BoardingTracker.Application.Skills.Validators
{
    public class UpdateSkillValidator : AbstractValidator<UpdateSkillRequest>
    {
        public UpdateSkillValidator()
        {
            RuleFor(skill => skill.Id).NotNull();
            RuleFor(skill => skill.Name).NotEmpty().NotNull().MaximumLength(50);
        }
    }
}
