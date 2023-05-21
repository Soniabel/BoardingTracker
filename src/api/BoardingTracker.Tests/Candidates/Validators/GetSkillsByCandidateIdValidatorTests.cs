using BoardingTracker.Application.Candidates.Queries.GetCandidateSkill;
using BoardingTracker.Application.Candidates.Validators;
using FluentAssertions;
using System;
using Xunit;

namespace BoardingTracker.Tests.Candidates.Validators
{
    public class GetSkillsByCandidateIdValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new GetSkillsByCandidateIdValidator();
            var result = validator.Validate(new GetSkillsByCandidateIdRequest
            {
                Id = Guid.NewGuid()
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new GetSkillsByCandidateIdValidator();
            var result = validator.Validate(new GetSkillsByCandidateIdRequest
            {
                Id = Guid.Empty
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
