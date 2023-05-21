using BoardingTracker.Application.Skills.Commands.DeleteSkill;
using BoardingTracker.Application.Skills.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.Skills.Validators
{
    public class DeleteSkillValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new DeleteSkillValidator();
            var result = validator.Validate(new DeleteSkillRequest
            {
                Id = 1
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new DeleteSkillValidator();
            var result = validator.Validate(new DeleteSkillRequest
            {
                Id = 0
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
