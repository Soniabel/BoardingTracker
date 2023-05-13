using BoardingTracker.Application.Interviews.Commands.UpdateInterview;
using FluentValidation;

namespace BoardingTracker.Application.Interviews.Validators
{
    public class UpdateInterviewValidator : AbstractValidator<UpdateInterviewRequest>
    {
        public UpdateInterviewValidator()
        {
            RuleFor(interview => interview.Id).NotNull();
            RuleFor(interview => interview.Title).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(interview => interview.StartTime).NotEmpty();
            RuleFor(interview => interview.EndTime).NotEmpty();
        }
    }
}
