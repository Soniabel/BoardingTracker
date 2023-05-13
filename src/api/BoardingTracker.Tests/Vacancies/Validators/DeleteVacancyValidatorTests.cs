using BoardingTracker.Application.Vacancies.Commands.DeleteVacancy;
using BoardingTracker.Application.Vacancies.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.Vacancies.Validators
{
    public class DeleteVacancyValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new DeleteVacancyValidator();
            var result = validator.Validate(new DeleteVacancyRequest
            {
                Id = 1
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new DeleteVacancyValidator();
            var result = validator.Validate(new DeleteVacancyRequest
            {
                Id = 0
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
