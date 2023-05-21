using BoardingTracker.Application.Interviews.Commands.CreateInterview;
using BoardingTracker.Application.Interviews.Validators;
using FluentAssertions;
using System;
using Xunit;

namespace BoardingTracker.Tests.Interviews.Validators
{
    public class CreateInterviewValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new CreateInterviewValidator();
            var result = validator.Validate(new CreateInterviewRequest
            {
                Title = "TestTitle",
                StartTime = new DateTime(2022, 12, 12),
                EndTime = new DateTime(2022, 12, 12),
                VacancyId = 1,
                RecruiterId = Guid.NewGuid(),
                CandidateId = Guid.NewGuid(),
                InterviewTypeId = 1
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new CreateInterviewValidator();
            var result = validator.Validate(new CreateInterviewRequest
            {
                Title = null,
                StartTime = new DateTime(),
                EndTime = new DateTime(),
                VacancyId = 0,
                RecruiterId = Guid.NewGuid(),
                CandidateId = Guid.NewGuid(),
                InterviewTypeId = 0
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
