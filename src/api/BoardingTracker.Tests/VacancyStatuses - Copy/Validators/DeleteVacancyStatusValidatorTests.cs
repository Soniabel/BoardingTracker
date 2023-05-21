using BoardingTracker.Application.VacancyStatuses.Commands.DeleteVacancyStatus;
using BoardingTracker.Application.VacancyStatuses.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.VacancyStatuses.Validators
{
    public class DeleteVacancyStatusValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new DeleteVacancyStatusValidator();
            var result = validator.Validate(new DeleteVacancyStatusRequest
            {
                Id = 1
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new DeleteVacancyStatusValidator();
            var result = validator.Validate(new DeleteVacancyStatusRequest
            {
                Id = 0
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
