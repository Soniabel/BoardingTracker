using BoardingTracker.Application.Users.Commands.DeleteUser;
using BoardingTracker.Application.Users.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.Users.Validators
{
    public class DeleteUserValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new DeleteUserValidator();
            var result = validator.Validate(new DeleteUserRequest
            {
                Id = 1
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new DeleteUserValidator();
            var result = validator.Validate(new DeleteUserRequest
            {
                Id = 0
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
