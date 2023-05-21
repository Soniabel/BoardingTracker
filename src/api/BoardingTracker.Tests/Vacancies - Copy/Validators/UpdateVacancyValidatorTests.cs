using BoardingTracker.Application.Vacancies.Commands.UpdateVacancy;
using BoardingTracker.Application.Vacancies.Validators;
using FluentAssertions;
using System;
using Xunit;

namespace BoardingTracker.Tests.Vacancies.Validators
{
    public class UpdateVacancyValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new UpdateVacancyValidator();
            var result = validator.Validate(new UpdateVacancyRequest
            {
                Id = 1,
                Title = "TestTitle",
                Description = "TestDescription",
                Salary = 1234,
                SeniorityLevelId = 1,
                VacancyTypeId = 1,
                VacancyStatusId = 1,
                RecruiterId = Guid.NewGuid()
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new UpdateVacancyValidator();
            var result = validator.Validate(new UpdateVacancyRequest
            {
                Id = 0,
                Title = null,
                Description = null,
                Salary = null,
                SeniorityLevelId = 1,
                VacancyTypeId = 1,
                VacancyStatusId = 1,
                RecruiterId = Guid.NewGuid()
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
