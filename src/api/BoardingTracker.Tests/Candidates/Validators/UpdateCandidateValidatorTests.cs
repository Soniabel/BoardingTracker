using BoardingTracker.Application.Candidates.Commands.UpdateCandidate;
using BoardingTracker.Application.Candidates.Validators;
using FluentAssertions;
using System;
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
                Id = Guid.NewGuid(),
                FirstName = "TestName",
                LastName = "TestName",
                PhoneNumber = "TestPhone",
                Biography = "TestBiography",
                ResumeUrl = "TestResumeUrl",
                UserId = Guid.NewGuid()
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new UpdateCandidateValidator();
            var result = validator.Validate(new UpdateCandidateRequest
            {
                Id = Guid.Empty,
                FirstName = null,
                LastName = null,
                PhoneNumber = null,
                Biography = null,
                ResumeUrl = null,
                UserId = Guid.Empty
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
