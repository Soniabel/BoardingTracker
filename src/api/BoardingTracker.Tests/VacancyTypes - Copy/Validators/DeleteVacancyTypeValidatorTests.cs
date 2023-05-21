using BoardingTracker.Application.VacancyTypes.Commands.DeleteVacancyType;
using BoardingTracker.Application.VacancyTypes.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.VacancyTypes.Validators
{
    public class DeleteVacancyTypeValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new DeleteVacancyTypeValidator();
            var result = validator.Validate(new DeleteVacancyTypeRequest
            {
                Id = 1
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new DeleteVacancyTypeValidator();
            var result = validator.Validate(new DeleteVacancyTypeRequest
            {
                Id = 0
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
