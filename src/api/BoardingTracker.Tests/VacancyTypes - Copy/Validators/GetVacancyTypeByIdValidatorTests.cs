using BoardingTracker.Application.VacancyTypes.Queries.GetVacancyTypesById;
using BoardingTracker.Application.VacancyTypes.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.VacancyTypes.Validators
{
    public class GetVacancyTypeByIdValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new GetVacancyTypeByIdValidator();
            var result = validator.Validate(new GetVacancyTypeByIdRequest
            {
                Id = 1
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new GetVacancyTypeByIdValidator();
            var result = validator.Validate(new GetVacancyTypeByIdRequest
            {
                Id = 0
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
