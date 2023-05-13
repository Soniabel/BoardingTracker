using BoardingTracker.Application.Recruiters.Queries.GetRecruitersById;
using BoardingTracker.Application.Recruiters.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.Recruiters.Validators
{
    public class GetRecruiterByIdValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new GetRecruiterByIdValidator();
            var result = validator.Validate(new GetRecruiterByIdRequest
            {
                Id = 1
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new GetRecruiterByIdValidator();
            var result = validator.Validate(new GetRecruiterByIdRequest
            {
                Id = 0
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
