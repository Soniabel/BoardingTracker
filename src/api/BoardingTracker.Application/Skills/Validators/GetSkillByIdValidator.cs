using BoardingTracker.Application.Skills.Queries.GetSkillById;
using FluentValidation;

namespace BoardingTracker.Application.Skills.Validators
{
    public class GetSkillByIdValidator : AbstractValidator<GetSkillByIdRequest>
    {
        public GetSkillByIdValidator()
        {
            RuleFor(skill => skill.Id).NotNull().NotEmpty();
        }
    }
}
