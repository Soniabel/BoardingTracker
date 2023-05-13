using BoardingTracker.Application.InterviewTypes.Commands.UpdateInterviewType;
using BoardingTracker.Application.InterviewTypes.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.InterviewTypes.Validators
{
    public class UpdateInterviewTypeValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new UpdateInterviewTypeValidator();
            var result = validator.Validate(new UpdateInterviewTypeRequest
            {
                Id = 1,
                Name = "TestName"
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new UpdateInterviewTypeValidator();
            var result = validator.Validate(new UpdateInterviewTypeRequest
            {
                Id = 0,
                Name = null
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
