using BoardingTracker.Application.Recruiters.Commands.DeleteRecruiter;
using FluentValidation;

namespace BoardingTracker.Application.Recruiters.Validators
{
    public class DeleteRecruiterValidator : AbstractValidator<DeleteRecruiterRequest>
    {
        public DeleteRecruiterValidator()
        {
            RuleFor(recruiter => recruiter.Id).NotNull().NotEmpty();
        }
    }
}
