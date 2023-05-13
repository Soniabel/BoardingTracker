using BoardingTracker.Application.Interviews.Commands.CreateInterview;
using FluentValidation;

namespace BoardingTracker.Application.Interviews.Validators
{
    public class CreateInterviewValidator : AbstractValidator<CreateInterviewRequest>
    {
        public CreateInterviewValidator()
        {
            RuleFor(interview => interview.Title).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(interview => interview.StartTime).NotEmpty();
            RuleFor(interview => interview.EndTime).NotEmpty();
        }
    }
}
