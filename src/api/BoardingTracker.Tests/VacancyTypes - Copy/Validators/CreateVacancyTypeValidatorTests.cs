using BoardingTracker.Application.VacancyTypes.Commands.CreateVacancyType;
using BoardingTracker.Application.VacancyTypes.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.VacancyTypes.Validators
{
    public class CreateVacancyTypeValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new CreateVacancyTypeValidator();
            var result = validator.Validate(new CreateVacancyTypeRequest
            {
                Name = "TestName"
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new CreateVacancyTypeValidator();
            var result = validator.Validate(new CreateVacancyTypeRequest
            {
                Name = null
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
