using BoardingTracker.Application.Skills.Commands.UpdateSkill;
using BoardingTracker.Application.Skills.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.Skills.Validators
{
    public class UpdateSkillValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new UpdateSkillValidator();
            var result = validator.Validate(new UpdateSkillRequest
            {
                Id = 1,
                Name = "TestName"
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new UpdateSkillValidator();
            var result = validator.Validate(new UpdateSkillRequest
            {
                Id = 0,
                Name = null
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
