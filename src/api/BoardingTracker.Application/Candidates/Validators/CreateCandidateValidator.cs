using BoardingTracker.Application.Candidates.Commands.CreateCandidate;
using FluentValidation;

namespace BoardingTracker.Application.Candidates.Validators
{
    public class CreateCandidateValidator : AbstractValidator<CreateCandidateRequest>
    {
        public CreateCandidateValidator()
        {
            RuleFor(candidate => candidate.FirstName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(candidate => candidate.LastName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(candidate => candidate.PhoneNumber).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(candidate => candidate.Biography).NotEmpty().NotNull();
            RuleFor(candidate => candidate.ResumeUrl).NotEmpty().NotNull();
        }
    }
}
