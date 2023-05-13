using BoardingTracker.Application.Interviews.Commands.UpdateInterview;
using BoardingTracker.Application.Interviews.Validators;
using FluentAssertions;
using System;
using Xunit;

namespace BoardingTracker.Tests.Interviews.Validators
{
    public class UpdateInterviewValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new UpdateInterviewValidator();
            var result = validator.Validate(new UpdateInterviewRequest
            {
                Id = 1,
                Title = "TestTitle",
                StartTime = new DateTime(2022, 12, 12),
                EndTime = new DateTime(2022, 12, 12),
                VacancyId = 1,
                RecruiterId = 1,
                CandidateId = 1,
                InterviewTypeId = 1
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new UpdateInterviewValidator();
            var result = validator.Validate(new UpdateInterviewRequest
            {
                Id = 0,
                Title = null,
                StartTime = new DateTime(),
                EndTime = new DateTime(),
                VacancyId = 0,
                RecruiterId = 0,
                CandidateId = 0,
                InterviewTypeId = 0
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
