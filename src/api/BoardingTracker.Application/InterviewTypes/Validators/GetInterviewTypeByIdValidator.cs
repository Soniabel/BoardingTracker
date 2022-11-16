using BoardingTracker.Application.InterviewTypes.Queries.GetInterviewTypesById;
using FluentValidation;

namespace BoardingTracker.Application.InterviewTypes.Validators
{
    public class GetInterviewTypeByIdValidator : AbstractValidator<GetInterviewTypeByIdRequest>
    {
        public GetInterviewTypeByIdValidator()
        {
            RuleFor(interviewType => interviewType.Id).NotNull().NotEmpty();
        }
    }
}
