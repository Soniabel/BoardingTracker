using BoardingTracker.Application.Candidates.Queries.GetCandidateById;
using BoardingTracker.Application.Candidates.Validators;
using FluentAssertions;
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
                Id = 1
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new GetCandidateByIdValidator();
            var result = validator.Validate(new GetCandidateByIdRequest
            {
                Id = 0
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
