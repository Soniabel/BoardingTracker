using BoardingTracker.Application.InterviewTypes.Commands.DeleteInterviewType;
using FluentValidation;

namespace BoardingTracker.Application.InterviewTypes.Validators
{
    public class DeleteInterviewTypeValidator : AbstractValidator<DeleteInterviewTypeRequest>
    {
        public DeleteInterviewTypeValidator()
        {
            RuleFor(interviewType => interviewType.Id).NotNull().NotEmpty();
        }
    }
}
