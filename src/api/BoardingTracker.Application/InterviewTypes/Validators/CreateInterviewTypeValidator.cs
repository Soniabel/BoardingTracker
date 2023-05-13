using BoardingTracker.Application.InterviewTypes.Commands.CreateInterviewType;
using FluentValidation;

namespace BoardingTracker.Application.InterviewTypes.Validators
{
    public class CreateInterviewTypeValidator : AbstractValidator<CreateInterviewTypeRequest>
    {
        public CreateInterviewTypeValidator()
        {
            RuleFor(interviewType => interviewType.Name).NotEmpty().NotNull().MaximumLength(50);
        }
    }
}
