using BoardingTracker.Application.InterviewTypes.Commands.DeleteInterviewType;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.InterviewTypes.Commands
{
    public abstract class DeleteInterviewTypeTests
    {
        public abstract class DeleteInterviewTypeTest : BaseTest
        {
            protected readonly DeleteInterviewTypeRequest _interviewTypeRequest;

            protected readonly DeleteInterviewTypeHandler _interviewTypeHandler;

            protected DeleteInterviewTypeTest()
            {
                _interviewTypeRequest = new DeleteInterviewTypeRequest()
                {
                    Id = 2
                };

                _interviewTypeHandler = new DeleteInterviewTypeHandler(_dbContext);
            }
        }

        public class Handle : DeleteInterviewTypeTest
        {
            [Fact]
            public async Task Deleted_Id_is_returned_when_request_is_valid()
            {
                var expectedId = 2;

                var result = await _interviewTypeHandler.Handle(_interviewTypeRequest, new CancellationToken());

                result.Should().Be(expectedId);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _interviewTypeRequest.Id = 0;

                var result = _interviewTypeHandler.Handle(_interviewTypeRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
