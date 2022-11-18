using BoardingTracker.Application.SeniorityLevels.Queries.GetAllSeniorityLevels;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BoardingTracker.Application.SeniorityLevels.Queries.GetAllSeniorityLevels.GetSeniorityLevels;

namespace BoardingTracker.Tests.SeniorityLevels.Queries
{
    public abstract class GetAllSeniorityLevelsTests
    {
        public abstract class GetAllSEniorityLevelTest : BaseTest
        {
            protected readonly GetSeniorityLevels _seniorityLevels;

            protected readonly GetSeniorityLevelsHandler _seniorityLevelHandler;

            protected GetAllSEniorityLevelTest()
            {
                _seniorityLevels = new GetSeniorityLevels();

                _seniorityLevelHandler = new GetSeniorityLevelsHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetAllSEniorityLevelTest
        {
            [Fact]
            public async Task SeniorityLevelList_is_returned_when_request_is_valid()
            {
                var result = await _seniorityLevelHandler.Handle(_seniorityLevels, new CancellationToken());

                result.Items.Should().HaveCount(x => x >= 1);
            }
        }
    }
}
