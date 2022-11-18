using BoardingTracker.Application.Skills.Queries.GetSkillById;
using BoardingTracker.Application.Skills.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.Skills.Validators
{
    public class GetSkillByIdValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new GetSkillByIdValidator();
            var result = validator.Validate(new GetSkillByIdRequest
            {
                Id = 1
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new GetSkillByIdValidator();
            var result = validator.Validate(new GetSkillByIdRequest
            {
                Id = 0
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
