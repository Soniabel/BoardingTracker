using BoardingTracker.Application.VacancyStatuses.Commands.CreateVacancyStatus;
using BoardingTracker.Application.VacancyStatuses.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.VacancyStatuses.Validators
{
    public class CreateVacancyStatusValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new CreateVacancyStatusValidator();
            var result = validator.Validate(new CreateVacancyStatusRequest
            {
                Name = "TestName"
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new CreateVacancyStatusValidator();
            var result = validator.Validate(new CreateVacancyStatusRequest
            {
                Name = null
            });

            result.IsValid.Should().BeFalse();
        }
    }

}
