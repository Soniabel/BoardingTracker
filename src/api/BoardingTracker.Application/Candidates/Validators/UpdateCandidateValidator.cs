using BoardingTracker.Application.Candidates.Commands.UpdateCandidate;
using FluentValidation;

namespace BoardingTracker.Application.Candidates.Validators
{
    public class UpdateCandidateValidator : AbstractValidator<UpdateCandidateRequest>
    {
        public UpdateCandidateValidator()
        {
            RuleFor(candidate => candidate.Id).NotNull();
            RuleFor(candidate => candidate.FirstName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(candidate => candidate.LastName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(candidate => candidate.PhoneNumber).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(candidate => candidate.Biography).NotEmpty().NotNull();
            RuleFor(candidate => candidate.ResumeUrl).NotEmpty().NotNull();
        }
    }
}
