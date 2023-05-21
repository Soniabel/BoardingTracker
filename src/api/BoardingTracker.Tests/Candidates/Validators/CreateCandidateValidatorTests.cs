using BoardingTracker.Application.Candidates.Commands.CreateCandidate;
using BoardingTracker.Application.Candidates.Validators;
using FluentAssertions;
using System;
using Xunit;

namespace BoardingTracker.Tests.Candidates.Validators
{
    public class CreateCandidateValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new CreateCandidateValidator();
            var result = validator.Validate(new CreateCandidateRequest
            {
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
            var validator = new CreateCandidateValidator();
            var result = validator.Validate(new CreateCandidateRequest
            {
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
