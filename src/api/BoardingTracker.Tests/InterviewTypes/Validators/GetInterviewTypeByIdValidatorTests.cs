using BoardingTracker.Application.InterviewTypes.Queries.GetInterviewTypesById;
using BoardingTracker.Application.InterviewTypes.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.InterviewTypes.Validators
{
    public class GetInterviewTypeByIdValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new GetInterviewTypeByIdValidator();
            var result = validator.Validate(new GetInterviewTypeByIdRequest
            {
                Id = 1
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new GetInterviewTypeByIdValidator();
            var result = validator.Validate(new GetInterviewTypeByIdRequest
            {
                Id = 0
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
