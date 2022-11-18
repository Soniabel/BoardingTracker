﻿using BoardingTracker.Application.SeniorityLevels.Queries.GetSeniorityLevelsById;
using BoardingTracker.Application.SeniorityLevels.Validators;
using FluentAssertions;
using Xunit;

namespace BoardingTracker.Tests.SeniorityLevels.Validators
{
    public class GetSeniorityLevelByIdValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new GetSeniorityLevelByIdValidator();
            var result = validator.Validate(new GetSeniorityLevelByIdRequest
            {
                Id = 1
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new GetSeniorityLevelByIdValidator();
            var result = validator.Validate(new GetSeniorityLevelByIdRequest
            {
                Id = 0
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
