using BoardingTracker.Application.Skills.Commands.DeleteSkill;
using FluentValidation;

namespace BoardingTracker.Application.Skills.Validators
{
    public class DeleteSkillValidator : AbstractValidator<DeleteSkillRequest>
    {
        public DeleteSkillValidator()
        {
            RuleFor(skill => skill.Id).NotNull().NotEmpty();
        }
    }
}
