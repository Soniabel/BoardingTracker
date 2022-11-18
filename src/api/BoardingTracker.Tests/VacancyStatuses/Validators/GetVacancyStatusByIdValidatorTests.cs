using BoardingTracker.Application.VacancyStatuses.Queries.GetVacancyStatusesById;
using BoardingTracker.Application.VacancyStatuses.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.VacancyStatuses.Validators
{
    public class GetVacancyStatusByIdValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new GetVacancyStatusByIdValidator();
            var result = validator.Validate(new GetVacancyStatusByIdRequest
            {
                Id = 1
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new GetVacancyStatusByIdValidator();
            var result = validator.Validate(new GetVacancyStatusByIdRequest
            {
                Id = 0
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
