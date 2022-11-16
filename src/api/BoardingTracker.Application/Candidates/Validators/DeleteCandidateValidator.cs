using BoardingTracker.Application.Candidates.Commands.DeleteCandidate;
using FluentValidation;

namespace BoardingTracker.Application.Candidates.Validators
{
    public class DeleteCandidateValidator : AbstractValidator<DeleteCandidateRequest>
    {
        public DeleteCandidateValidator()
        {
            RuleFor(candidate => candidate.Id).NotNull().NotEmpty();
        }
    }
}
