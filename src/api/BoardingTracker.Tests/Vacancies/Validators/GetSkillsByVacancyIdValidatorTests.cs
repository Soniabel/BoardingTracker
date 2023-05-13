using BoardingTracker.Application.Vacancies.Queries.GetVacancySkills;
using BoardingTracker.Application.Vacancies.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.Vacancies.Validators
{
    public class GetSkillsByVacancyIdValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new GetSkillsByVacancyIdValidator();
            var result = validator.Validate(new GetSkillsByVacancyIdRequest
            {
                Id = 1
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new GetSkillsByVacancyIdValidator();
            var result = validator.Validate(new GetSkillsByVacancyIdRequest
            {
                Id = 0
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
