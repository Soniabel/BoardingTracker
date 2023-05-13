using BoardingTracker.Application.Candidates.Queries.GetCandidateById;
using FluentValidation;

namespace BoardingTracker.Application.Candidates.Validators
{
    public class GetCandidateByIdValidator : AbstractValidator<GetCandidateByIdRequest>
    {
        public GetCandidateByIdValidator()
        {
            RuleFor(candidate => candidate.Id).NotNull().NotEmpty();
        }
    }
}
