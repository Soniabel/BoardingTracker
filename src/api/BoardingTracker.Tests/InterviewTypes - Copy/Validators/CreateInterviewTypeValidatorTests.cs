using BoardingTracker.Application.InterviewTypes.Commands.CreateInterviewType;
using BoardingTracker.Application.InterviewTypes.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.InterviewTypes.Validators
{
    public class CreateInterviewTypeValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new CreateInterviewTypeValidator();
            var result = validator.Validate(new CreateInterviewTypeRequest
            {
                Name = "TestName"
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new CreateInterviewTypeValidator();
            var result = validator.Validate(new CreateInterviewTypeRequest
            {
                Name = null
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
