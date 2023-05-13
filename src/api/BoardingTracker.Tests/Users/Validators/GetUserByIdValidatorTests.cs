using BoardingTracker.Application.Users.Queries.GetUserById;
using BoardingTracker.Application.Users.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.Users.Validators
{
    public class GetUserByIdValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new GetUserByIdValidator();
            var result = validator.Validate(new GetUserByIdRequest
            {
                Id = 1
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new GetUserByIdValidator();
            var result = validator.Validate(new GetUserByIdRequest
            {
                Id = 0
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
