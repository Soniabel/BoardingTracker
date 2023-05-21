using BoardingTracker.Application.SeniorityLevels.Commands.DeleteSeniorityLevel;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.SeniorityLevels.Commands
{
    public abstract class DeleteSeniorityLevelTests
    {
        public abstract class DeleteSeniorityLevelTest : BaseTest
        {
            protected readonly DeleteSeniorityLevelRequest _seniorityLevelReguest;

            protected readonly DeleteSeniorityLevelHandler _seniorityLevelHandler;

            protected DeleteSeniorityLevelTest()
            {
                _seniorityLevelReguest = new DeleteSeniorityLevelRequest()
                {
                    Id = 2
                };

                _seniorityLevelHandler = new DeleteSeniorityLevelHandler(_dbContext);
            }
        }

        public class Handle : DeleteSeniorityLevelTest
        {
            [Fact]
            public async Task Deleted_Id_is_returned_when_request_is_valid()
            {
                var expectedId = 2;

                var result = await _seniorityLevelHandler.Handle(_seniorityLevelReguest, new CancellationToken());

                result.Should().Be(expectedId);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _seniorityLevelReguest.Id = 0;

                var result = _seniorityLevelHandler.Handle(_seniorityLevelReguest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
