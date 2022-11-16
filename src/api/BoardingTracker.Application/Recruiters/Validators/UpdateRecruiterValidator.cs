using BoardingTracker.Application.Recruiters.Commands.UpdateRecruiter;
using FluentValidation;

namespace BoardingTracker.Application.Recruiters.Validators
{
    public class UpdateRecruiterValidator : AbstractValidator<UpdateRecruiterRequest>
    {
        public UpdateRecruiterValidator()
        {
            RuleFor(recruiter => recruiter.Id).NotNull();
            RuleFor(recruiter => recruiter.FirstName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(recruiter => recruiter.LastName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(recruiter => recruiter.ProfileImageUrl).NotEmpty().NotNull();
        }
    }
}
