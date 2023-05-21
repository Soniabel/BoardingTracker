using BoardingTracker.Application.Skills.Models;
using BoardingTracker.Application.Skills.Queries.GetSkillById;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.Skills.Queries
{
    public abstract class GetSkillByIdTests
    {
        public abstract class GetSkillByIdTest : BaseTest
        {
            protected readonly GetSkillByIdRequest _skillRequest;

            protected readonly GetSkillByIdHandler _skillHandler;

            protected GetSkillByIdTest()
            {
                _skillRequest = new GetSkillByIdRequest()
                {
                    Id = 1
                };

                _skillHandler = new GetSkillByIdHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetSkillByIdTest
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
