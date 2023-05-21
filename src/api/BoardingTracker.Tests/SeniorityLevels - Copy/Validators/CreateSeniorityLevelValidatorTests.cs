using BoardingTracker.Application.SeniorityLevels.Commands.CreateSeniorityLevel;
using BoardingTracker.Application.SeniorityLevels.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.SeniorityLevels.Validators
{
    public class CreateSeniorityLevelValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new CreateSeniorityLevelValidator();
            var result = validator.Validate(new CreateSeniorityLevelRequest
            {
                Name = "TestName"
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new CreateSeniorityLevelValidator();
            var result = validator.Validate(new CreateSeniorityLevelRequest
            {
                Name = null
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
