using BoardingTracker.Application.SeniorityLevels.Commands.UpdateSeniorityLevel;
using BoardingTracker.Application.SeniorityLevels.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.SeniorityLevels.Validators
{
    public class UpdateSeniorityLevelValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new UpdateSeniorityLevelValidator();
            var result = validator.Validate(new UpdateSeniorityLevelRequest
            {
                Id = 1,
                Name = "TestName"
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new UpdateSeniorityLevelValidator();
            var result = validator.Validate(new UpdateSeniorityLevelRequest
            {
                Id = 0,
                Name = null
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
