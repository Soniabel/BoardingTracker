using BoardingTracker.Application.Skills.Commands.UpdateSkill;
using BoardingTracker.Application.Skills.Models;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.Skills.Commands
{
    public abstract class UpdateSkillTests
    {
        public abstract class UpdateSkillTest : BaseTest
        {
            protected readonly UpdateSkillRequest _skillRequest;

            protected readonly UpdateSkillHandler _skillHandler;

            protected UpdateSkillTest()
            {
                _skillRequest = new UpdateSkillRequest()
                {
                    Id = 1,
                    Name = "TestName"
                };

                _skillHandler = new UpdateSkillHandler(_dbContext, _mapper);
            }
        }

        public class Handle : UpdateSkillTest
        {
            [Fact]
            public async Task Skill_model_is_returned_when_request_is_valid()
            {
                var expectedSkill = new SkillModel
                {
                    Id = 1,
                    Name = "TestName"
                };
                var result = await _skillHandler.Handle(_skillRequest, new CancellationToken());

                result.Should().BeEquivalentTo(expectedSkill);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _skillRequest.Id = 0;

                var result = _skillHandler.Handle(_skillRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
