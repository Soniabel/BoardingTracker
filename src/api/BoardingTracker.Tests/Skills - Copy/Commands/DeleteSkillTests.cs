using BoardingTracker.Application.Skills.Commands.DeleteSkill;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.Skills.Commands
{
    public abstract class DeleteSkillTests
    {
        public abstract class DeleteSkillTest : BaseTest
        {
            protected readonly DeleteSkillRequest _skillRequest;

            protected readonly DeleteSkillHandler _skillHandler;

            protected DeleteSkillTest()
            {
                _skillRequest = new DeleteSkillRequest()
                {
                    Id = 2
                };

                _skillHandler = new DeleteSkillHandler(_dbContext);
            }
        }

        public class Handle : DeleteSkillTest
        {
            [Fact]
            public async Task Deleted_Id_is_returned_when_request_is_valid()
            {
                var expectedId = 2;

                var result = await _skillHandler.Handle(_skillRequest, new CancellationToken());

                result.Should().Be(expectedId);
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
