using BoardingTracker.Application.Vacancies.Commands.CreateVacancy;
using BoardingTracker.Application.Vacancies.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.Vacancies.Validators
{
    public class CreateVacancyValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new CreateVacancyValidator();
            var result = validator.Validate(new CreateVacancyRequest
            {
                Title = "TestName",
                Description = "TestName",
                Salary = 1000
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new CreateVacancyValidator();
            var result = validator.Validate(new CreateVacancyRequest
            {
                Title = null,
                Description = null,
                Salary = null
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
