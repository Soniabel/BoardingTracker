﻿using BoardingTracker.Application.Skills.Commands.CreateSkill;
using BoardingTracker.Application.Skills.Models;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.Skills.Commands
{
    public abstract class CreateSkillTests
    {
        public abstract class CreateSkillRequestTest : BaseTest
        {
            protected readonly CreateSkillRequest _skillRequest;

            protected readonly CreateSkillHandler _skillHandler;

            protected CreateSkillRequestTest()
            {
                _skillRequest = new CreateSkillRequest()
                {
                    Name = "TestName"
                };

                _skillHandler = new CreateSkillHandler(_dbContext, _mapper);
            }
        }

        public class Handler : CreateSkillRequestTest
        {
            [Fact]
            public async Task Skill_model_is_returned_when_request_is_valid()
            {
                var expectedSkill = new SkillModel
                {
                    Id = 3,
                    Name = "TestName"
                };
                var result = await _skillHandler.Handle(_skillRequest, new CancellationToken());

                result.Should().BeEquivalentTo(expectedSkill);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _skillRequest.Name = null;

                var result = _skillHandler.Handle(_skillRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
