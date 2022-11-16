using BoardingTracker.Application.Interviews.Queries.GetInterviewsById;
using FluentValidation;

namespace BoardingTracker.Application.Interviews.Validators
{
    public class GetInterviewByIdValidator : AbstractValidator<GetInterviewByIdRequest>
    {
        public GetInterviewByIdValidator()
        {
            RuleFor(interview => interview.Id).NotNull().NotEmpty();
        }
    }
}
