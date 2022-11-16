using BoardingTracker.Application.Recruiters.Queries.GetRecruitersById;
using FluentValidation;

namespace BoardingTracker.Application.Recruiters.Validators
{
    public class GetRecruiterByIdValidator : AbstractValidator<GetRecruiterByIdRequest>
    {
        public GetRecruiterByIdValidator()
        {
            RuleFor(recruiter => recruiter.Id).NotNull().NotEmpty();
        }
    }
}
