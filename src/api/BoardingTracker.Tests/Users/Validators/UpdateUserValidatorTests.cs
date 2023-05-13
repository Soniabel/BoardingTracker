using BoardingTracker.Application.Users.Commands.UpdateUser;
using BoardingTracker.Application.Users.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.Users.Validators
{
    public class UpdateUserValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new UpdateUserValidator();
            var result = validator.Validate(new UpdateUserRequest
            {
                Id = 1,
                Email = "TestEmail",
                Password = "TestPassword",
                Role = "TestRole"
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new UpdateUserValidator();
            var result = validator.Validate(new UpdateUserRequest
            {
                Id = 0,
                Email = null,
                Password = null,
                Role = null
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
