using BoardingTracker.Application.SeniorityLevels.Commands.UpdateSeniorityLevel;
using BoardingTracker.Application.SeniorityLevels.Models;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.SeniorityLevels.Commands
{
    public abstract class UpdateSeniorityLevelTests
    {
        public abstract class UpdateSeniorityLevelTest : BaseTest
        {
            protected readonly UpdateSeniorityLevelRequest _seniorityLevelRequest;

            protected readonly UpdateSeniorityLevelHandler _seniorityLevelHandler;

            protected UpdateSeniorityLevelTest()
            {
                _seniorityLevelRequest = new UpdateSeniorityLevelRequest()
                {
                    Id = 1,
                    Name = "TestName"
                };

                _seniorityLevelHandler = new UpdateSeniorityLevelHandler(_dbContext, _mapper);
            }
        }

        public class Handle : UpdateSeniorityLevelTest
        {
            [Fact]
            public async Task SeniorityLevel_model_is_returned_when_request_is_valid()
            {
                var expectedSeniorityLevel = new SeniorityLevelModel
                {
                    Id = 1,
                    Name = "TestName"
                };
                var result = await _seniorityLevelHandler.Handle(_seniorityLevelRequest, new CancellationToken());

                result.Should().BeEquivalentTo(expectedSeniorityLevel);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _seniorityLevelRequest.Id = 0;

                var result = _seniorityLevelHandler.Handle(_seniorityLevelRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
