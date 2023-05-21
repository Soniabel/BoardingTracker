using BoardingTracker.Application.Candidates.Queries.GetCandidateById;
using BoardingTracker.Application.Candidates.Validators;
using FluentAssertions;
using System;
using Xunit;

namespace BoardingTracker.Tests.Candidates.Validators
{
    public class GetCandidateByIdValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new GetCandidateByIdValidator();
            var result = validator.Validate(new GetCandidateByIdRequest
            {
                Id = Guid.NewGuid()
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new GetCandidateByIdValidator();
            var result = validator.Validate(new GetCandidateByIdRequest
            {
                Id = Guid.Empty
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
