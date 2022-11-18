using BoardingTracker.Application.InterviewTypes.Models;
using BoardingTracker.Application.InterviewTypes.Queries.GetInterviewTypesById;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.InterviewTypes.Queries
{
    public abstract class GetInterviewTypeByIdTests
    {
        public abstract class GetInterviewTypeByIdTest : BaseTest
        {
            protected readonly GetInterviewTypeByIdRequest _interviewTypeRequest;

            protected readonly GetInterviewTypeByIdHandler _interviewTypeHandler;

            protected GetInterviewTypeByIdTest()
            {
                _interviewTypeRequest = new GetInterviewTypeByIdRequest()
                {
                    Id = 1
                };

                _interviewTypeHandler = new GetInterviewTypeByIdHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetInterviewTypeByIdTest
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
