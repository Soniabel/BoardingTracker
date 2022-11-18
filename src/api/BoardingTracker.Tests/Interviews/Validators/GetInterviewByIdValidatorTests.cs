using BoardingTracker.Application.Interviews.Queries.GetInterviewsById;
using BoardingTracker.Application.Interviews.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.Interviews.Validators
{
    public class GetInterviewByIdValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new GetInterviewByIdValidator();
            var result = validator.Validate(new GetInterviewByIdRequest
            {
                Id = 1
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new GetInterviewByIdValidator();
            var result = validator.Validate(new GetInterviewByIdRequest
            {
                Id = 0
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
