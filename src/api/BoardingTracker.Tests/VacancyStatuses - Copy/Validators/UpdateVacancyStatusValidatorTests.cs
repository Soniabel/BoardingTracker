using BoardingTracker.Application.VacancyStatuses.Commands.UpdateVacancyStatus;
using BoardingTracker.Application.VacancyStatuses.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.VacancyStatuses.Validators
{
    public class UpdateVacancyStatusValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new UpdateVacancyStatusValidator();
            var result = validator.Validate(new UpdateVacancyStatusRequest
            {
                Id = 1,
                Name = "TestName"
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new UpdateVacancyStatusValidator();
            var result = validator.Validate(new UpdateVacancyStatusRequest
            {
                Id = 0,
                Name = null
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
