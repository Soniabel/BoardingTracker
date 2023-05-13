using BoardingTracker.Application.Skills.Queries.GetAllSkills;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BoardingTracker.Application.Skills.Queries.GetAllSkills.GetSkills;

namespace BoardingTracker.Tests.Skills.Queries
{
    public abstract class GetAllSkillsTests
    {
        public abstract class GetAllSkillsTest : BaseTest
        {
            protected readonly GetSkills _skillRequest;

            protected readonly GetSkillsHandler _skillHandler;

            protected GetAllSkillsTest()
            {
                _skillRequest = new GetSkills();

                _skillHandler = new GetSkillsHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetAllSkillsTest
        {
            [Fact]
            public async Task SkillList_is_returned_when_request_is_valid()
            {
                var result = await _skillHandler.Handle(_skillRequest, new CancellationToken());

                result.Items.Should().HaveCount(x => x >= 1);
            }
        }
    }
}
