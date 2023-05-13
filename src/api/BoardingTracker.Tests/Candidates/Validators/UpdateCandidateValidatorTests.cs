using BoardingTracker.Application.Candidates.Commands.UpdateCandidate;
using BoardingTracker.Application.Candidates.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.Candidates.Validators
{
    public class UpdateCandidateValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new UpdateCandidateValidator();
            var result = validator.Validate(new UpdateCandidateRequest
            {
                Id = 1,
                FirstName = "TestName",
                LastName = "TestName",
                PhoneNumber = "TestPhone",
                Biography = "TestBiography",
                ResumeUrl = "TestResumeUrl",
                UserId = 1
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new UpdateCandidateValidator();
            var result = validator.Validate(new UpdateCandidateRequest
            {
                Id = 0,
                FirstName = null,
                LastName = null,
                PhoneNumber = null,
                Biography = null,
                ResumeUrl = null,
                UserId = 0
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
