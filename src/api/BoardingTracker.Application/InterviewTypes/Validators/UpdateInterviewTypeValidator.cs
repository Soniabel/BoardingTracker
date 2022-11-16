using BoardingTracker.Application.InterviewTypes.Commands.UpdateInterviewType;
using FluentValidation;

namespace BoardingTracker.Application.InterviewTypes.Validators
{
    public class UpdateInterviewTypeValidator : AbstractValidator<UpdateInterviewTypeRequest>
    {
        public UpdateInterviewTypeValidator()
        {
            RuleFor(interviewType => interviewType.Id).NotNull().NotEmpty();
            RuleFor(interviewType => interviewType.Name).NotEmpty().NotNull().MaximumLength(50);
        }
    }
}
