using BoardingTracker.Application.Interviews.Commands.DeleteInterview;
using BoardingTracker.Application.Interviews.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.Interviews.Validators
{
    public class DeleteInterviewValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new DeleteInterviewValidator();
            var result = validator.Validate(new DeleteInterviewRequest
            {
                Id = 1
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new DeleteInterviewValidator();
            var result = validator.Validate(new DeleteInterviewRequest
            {
                Id = 0
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
