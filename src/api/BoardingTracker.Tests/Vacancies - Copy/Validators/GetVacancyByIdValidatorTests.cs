using BoardingTracker.Application.Vacancies.Queries.GetVacanciesById;
using BoardingTracker.Application.Vacancies.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.Vacancies.Validators
{
    public class GetVacancyByIdValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new GetVacancyByIdValidator();
            var result = validator.Validate(new GetVacancyByIdRequest
            {
                Id = 1
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new GetVacancyByIdValidator();
            var result = validator.Validate(new GetVacancyByIdRequest
            {
                Id = 0
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
