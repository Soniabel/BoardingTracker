using BoardingTracker.Application.InterviewTypes.Commands.UpdateInterviewType;
using BoardingTracker.Application.InterviewTypes.Models;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.InterviewTypes.Commands
{
    public abstract class UpdateInterviewTypeTests
    {
        public abstract class UpdateInterviewTypeTest : BaseTest
        {
            protected readonly UpdateInterviewTypeRequest _interviewTypeRequest;

            protected readonly UpdateInterviewTypeHandler _interviewTypeHandler;

            protected UpdateInterviewTypeTest()
            {
                _interviewTypeRequest = new UpdateInterviewTypeRequest()
                {
                    Id = 1,
                    Name = "TestName"
                };

                _interviewTypeHandler = new UpdateInterviewTypeHandler(_dbContext, _mapper);
            }
        }

        public class Handle : UpdateInterviewTypeTest
        {
            [Fact]
            public async Task InterviewType_model_is_returned_when_request_is_valid()
            {
                var expectedInterviewType = new InterviewTypeModel
                {
                    Id = 1,
                    Name = "TestName"
                };
                var result = await _interviewTypeHandler.Handle(_interviewTypeRequest, new CancellationToken());

                result.Should().BeEquivalentTo(expectedInterviewType);
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
