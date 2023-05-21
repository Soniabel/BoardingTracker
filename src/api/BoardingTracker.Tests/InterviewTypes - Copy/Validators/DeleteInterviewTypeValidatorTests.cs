using BoardingTracker.Application.InterviewTypes.Commands.DeleteInterviewType;
using BoardingTracker.Application.InterviewTypes.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.InterviewTypes.Validators
{
    public class DeleteInterviewTypeValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new DeleteInterviewTypeValidator();
            var result = validator.Validate(new DeleteInterviewTypeRequest
            {
                Id = 1
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new DeleteInterviewTypeValidator();
            var result = validator.Validate(new DeleteInterviewTypeRequest
            {
                Id = 0
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
