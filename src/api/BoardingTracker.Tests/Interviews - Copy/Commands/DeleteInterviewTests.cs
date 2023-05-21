using BoardingTracker.Application.Interviews.Commands.DeleteInterview;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Linq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.Interviews.Commands
{
    public abstract class DeleteInterviewTests
    {
        public abstract class DeleteInterviewTest : BaseTest
        {
            protected readonly DeleteInterviewRequest _interviewRequest;

            protected readonly DeleteInterviewHandler _interviewHandler;

            protected DeleteInterviewTest()
            {
                _interviewRequest = new DeleteInterviewRequest()
                {
                    Id = 1
                };

                _interviewHandler = new DeleteInterviewHandler(_dbContext);
            }
        }

        public class Handle : DeleteInterviewTest
        {
            [Fact]
            public async Task Deleted_Id_is_returned_when_request_is_valid()
            {
                var expectedId = 1;

                var result = await _interviewHandler.Handle(_interviewRequest, new CancellationToken());

                result.Should().Be(expectedId);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _interviewRequest.Id = 0;

                var result = _interviewHandler.Handle(_interviewRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
