using BoardingTracker.Application.Recruiters.Commands.CreateRecruiter;
using BoardingTracker.Application.Recruiters.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.Recruiters.Validators
{
    public class CreateRecruiterValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new CreateRecruiterValidator();
            var result = validator.Validate(new CreateRecruiterRequest
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                ProfileImageUrl = "TestImage"
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new CreateRecruiterValidator();
            var result = validator.Validate(new CreateRecruiterRequest
            {
                FirstName = null,
                LastName = null,
                ProfileImageUrl = null
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
