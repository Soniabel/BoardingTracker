using BoardingTracker.Application.Recruiters.Commands.UpdateRecruiter;
using BoardingTracker.Application.Recruiters.Validators;
using FluentAssertions;
using System;
using Xunit;

namespace BoardingTracker.Tests.Recruiters.Validators
{
    public class UpdateRecruiterValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new UpdateRecruiterValidator();
            var result = validator.Validate(new UpdateRecruiterRequest
            {
                Id = Guid.NewGuid(),
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                ProfileImageUrl = "TestImage",
                UserId = Guid.NewGuid()
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new UpdateRecruiterValidator();
            var result = validator.Validate(new UpdateRecruiterRequest
            {
                Id = Guid.NewGuid(),
                FirstName = null,
                LastName = null,
                ProfileImageUrl = null,
                UserId = Guid.NewGuid()
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
