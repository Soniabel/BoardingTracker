using BoardingTracker.Application.Interviews.Commands.DeleteInterview;
using FluentValidation;

namespace BoardingTracker.Application.Interviews.Validators
{
    public class DeleteInterviewValidator : AbstractValidator<DeleteInterviewRequest>
    {
        public DeleteInterviewValidator()
        {
            RuleFor(interview => interview.Id).NotNull().NotEmpty();
        }
    }
}
