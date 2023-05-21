using BoardingTracker.Application.SeniorityLevels.Models;
using BoardingTracker.Application.SeniorityLevels.Queries.GetSeniorityLevelsById;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.SeniorityLevels.Queries
{
    public abstract class GetSeniorityLevelByIdTests
    {
        public abstract class GetSeniorityLevelByIdTest : BaseTest
        {
            protected readonly GetSeniorityLevelByIdRequest _seniorityLevelRequest;

            protected readonly GetSeniorityLevelByIdHandler _seniorityLevelHandler;

            protected GetSeniorityLevelByIdTest()
            {
                _seniorityLevelRequest = new GetSeniorityLevelByIdRequest()
                {
                    Id = 1
                };

                _seniorityLevelHandler = new GetSeniorityLevelByIdHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetSeniorityLevelByIdTest
        {
            [Fact]
            public async Task SeniorityLevel_is_returned_when_request_is_valid()
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
