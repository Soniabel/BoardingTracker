using BoardingTracker.Application.Skills.Commands.CreateSkill;
using BoardingTracker.Application.Skills.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.Skills.Validators
{
    public class CreateSkillValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new CreateSkillValidator();
            var result = validator.Validate(new CreateSkillRequest
            {
                Name = "Not Empty"
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new CreateSkillValidator();
            var result = validator.Validate(new CreateSkillRequest
            {
                Name = null
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
