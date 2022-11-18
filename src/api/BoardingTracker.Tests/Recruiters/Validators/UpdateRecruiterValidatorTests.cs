using BoardingTracker.Application.Recruiters.Commands.UpdateRecruiter;
using BoardingTracker.Application.Recruiters.Validators;
using FluentAssertions;
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
                Id = 1,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                ProfileImageUrl = "TestImage",
                UserId = 1
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new UpdateRecruiterValidator();
            var result = validator.Validate(new UpdateRecruiterRequest
            {
                Id = 0,
                FirstName = null,
                LastName = null,
                ProfileImageUrl = null,
                UserId = 0
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
