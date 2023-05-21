using BoardingTracker.Application.Users.Commands.CreateUser;
using BoardingTracker.Application.Users.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.Users.Validators
{
    public class CreateUserValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new CreateUserValidator();
            var result = validator.Validate(new CreateUserRequest
            {
                Email = "TestEmail",
                Password = "TestPassword",
                Role = "TestRole"
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new CreateUserValidator();
            var result = validator.Validate(new CreateUserRequest
            {
                Email = null,
                Password = null,
                Role = null
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
