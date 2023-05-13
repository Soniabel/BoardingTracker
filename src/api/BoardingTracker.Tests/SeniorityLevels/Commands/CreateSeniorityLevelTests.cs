using BoardingTracker.Application.SeniorityLevels.Commands.CreateSeniorityLevel;
using BoardingTracker.Application.SeniorityLevels.Models;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.SeniorityLevels.Commands
{
    public abstract class CreateSeniorityLevelTest : BaseTest
    {
        protected readonly CreateSeniorityLevelRequest _seniorityLevelRequest;

        protected readonly CreateSeniorityLevelHandler _seniorityLevelHandler;

        protected CreateSeniorityLevelTest()
        {
            _seniorityLevelRequest = new CreateSeniorityLevelRequest()
            {
                Name = "TestName"
            };

            _seniorityLevelHandler = new CreateSeniorityLevelHandler(_dbContext, _mapper);
        }
    }

    public class Handle : CreateSeniorityLevelTest
    {
        [Fact]
        public async Task SeniorityLevel_model_is_returned_when_request_is_valid()
        {
            var expectedSeniorityLevel = new SeniorityLevelModel
            {
                Id = 3,
                Name = "TestName"
            };
            var result = await _seniorityLevelHandler.Handle(_seniorityLevelRequest, new CancellationToken());

            result.Should().BeEquivalentTo(expectedSeniorityLevel);
        }

        [Fact]
        public async Task Bad_request_is_returned_when_request_is_invalid()
        {
            _seniorityLevelRequest.Name = null;

            var result = _seniorityLevelHandler.Handle(_seniorityLevelRequest, new CancellationToken());

            result.Exception.Should().NotBeNull();
        }
    }
}
