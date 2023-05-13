using BoardingTracker.Application.Recruiters.Commands.DeleteRecruiter;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.Recruiters.Commands
{
    public abstract class DeleteRecruiterTests
    {
        public abstract class DeleteRecruiterTest : BaseTest
        {
            protected readonly DeleteRecruiterRequest _recruiterRequest;

            protected readonly DeleteRecruiterHandler _recruiterHandler;

            protected DeleteRecruiterTest()
            {
                _recruiterRequest = new DeleteRecruiterRequest()
                {
                    Id = 2
                };

                _recruiterHandler = new DeleteRecruiterHandler(_dbContext);
            }
        }

        public class Handle : DeleteRecruiterTest
        {
            [Fact]
            public async Task Deleted_Id_is_returned_when_request_is_valid()
            {
                var expectedId = 2;

                var result = await _recruiterHandler.Handle(_recruiterRequest, new CancellationToken());

                result.Should().Be(expectedId);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _recruiterRequest.Id = 0;

                var result = _recruiterHandler.Handle(_recruiterRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
