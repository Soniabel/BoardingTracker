using BoardingTracker.Application.Candidates.Commands.DeleteCandidate;
using BoardingTracker.Application.Candidates.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.Candidates.Validators
{
    public class DeleteCandidateValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new DeleteCandidateValidator();
            var result = validator.Validate(new DeleteCandidateRequest
            {
                Id = 1
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new DeleteCandidateValidator();
            var result = validator.Validate(new DeleteCandidateRequest
            {
                Id = 0
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
