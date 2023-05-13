using BoardingTracker.Application.VacancyTypes.Commands.UpdateVacancyType;
using BoardingTracker.Application.VacancyTypes.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.VacancyTypes.Validators
{
    public class UpdateVacancyTypeValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new UpdateVacancyTypeValidator();
            var result = validator.Validate(new UpdateVacancyTypeRequest
            {
                Id = 1,
                Name = "TestName"
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new UpdateVacancyTypeValidator();
            var result = validator.Validate(new UpdateVacancyTypeRequest
            {
                Id = 0,
                Name = null
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
