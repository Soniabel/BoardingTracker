using BoardingTracker.Application.Recruiters.Commands.CreateRecruiter;
using FluentValidation;

namespace BoardingTracker.Application.Recruiters.Validators
{
    public class CreateRecruiterValidator : AbstractValidator<CreateRecruiterRequest>
    {
        public CreateRecruiterValidator()
        {
            RuleFor(recruiter => recruiter.FirstName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(recruiter => recruiter.LastName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(recruiter => recruiter.ProfileImageUrl).NotEmpty().NotNull();
        }
    }
}
