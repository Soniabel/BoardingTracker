﻿using BoardingTracker.Application.Recruiters.Commands.DeleteRecruiter;
using BoardingTracker.Application.Recruiters.Validators;
using FluentAssertions;
using System;
using Xunit;

namespace BoardingTracker.Tests.Recruiters.Validators
{
    public class DeleteRecruiterValidatorTests
    {
        [Fact]
        public void Validator_success_when_request_is_valid()
        {
            var validator = new DeleteRecruiterValidator();
            var result = validator.Validate(new DeleteRecruiterRequest
            {
                Id = Guid.NewGuid()
            });

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_failed_when_request_is_invalid()
        {
            var validator = new DeleteRecruiterValidator();
            var result = validator.Validate(new DeleteRecruiterRequest
            {
                Id = Guid.Empty
            });

            result.IsValid.Should().BeFalse();
        }
    }
}
