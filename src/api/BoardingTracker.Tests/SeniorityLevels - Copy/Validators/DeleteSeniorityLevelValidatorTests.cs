using BoardingTracker.Application.SeniorityLevels.Commands.DeleteSeniorityLevel;
using BoardingTracker.Application.SeniorityLevels.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.SeniorityLevels.Validators
{
    public class DeleteSeniorityLevelValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new DeleteSeniorityLevelValidator();
            var result = validator.Validate(new DeleteSeniorityLevelRequest
            {
                Id = 1
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new DeleteSeniorityLevelValidator();
            var result = validator.Validate(new DeleteSeniorityLevelRequest
            {
                Id = 0
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
