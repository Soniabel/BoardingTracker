using BoardingTracker.Application.InterviewTypes.Commands.CreateInterviewType;
using BoardingTracker.Application.InterviewTypes.Models;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.InterviewTypes.Commands
{
    public abstract class CreateInterviewTypeTests
    {
        public abstract class CreateInterviewTypeTest : BaseTest
        {
            protected readonly CreateInterviewTypeRequest _interviewTypeRequest;

            protected readonly CreateInterviewTypeHandler _interviewTypeHandler;

            protected CreateInterviewTypeTest()
            {
                _interviewTypeRequest = new CreateInterviewTypeRequest()
                {
                    Name = "TestName"
                };

                _interviewTypeHandler = new CreateInterviewTypeHandler(_dbContext, _mapper);
            }
        }

        public class Handle : CreateInterviewTypeTest
        {
            [Fact]
            public async Task InterviewType_model_is_returned_when_request_is_valid()
            {
                var expectedInterviewType = new InterviewTypeModel
                {
                    Id = 3,
                    Name = "TestName"
                };
                var result = await _interviewTypeHandler.Handle(_interviewTypeRequest, new CancellationToken());

                result.Should().BeEquivalentTo(expectedInterviewType);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _interviewTypeRequest.Name = null;

                var result = _interviewTypeHandler.Handle(_interviewTypeRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
