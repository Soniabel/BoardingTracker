using BoardingTracker.Application.Candidates.Queries.GetCandidateSkill;
using FluentValidation;

namespace BoardingTracker.Application.Candidates.Validators
{
    public class GetSkillsByCandidateIdValidator : AbstractValidator<GetSkillsByCandidateIdRequest>
    {
        public GetSkillsByCandidateIdValidator()
        {
            RuleFor(candidate => candidate.UserId).NotNull().NotEmpty();
        }
    }
}
