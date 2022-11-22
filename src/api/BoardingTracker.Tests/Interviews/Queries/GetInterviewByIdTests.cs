using BoardingTracker.Application.Interviews.Queries.GetInterviewsById;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.Interviews.Queries
{
    public abstract class GetInterviewByIdTests
    {
        public abstract class GetInterviewByIdTest : BaseTest
        {
            protected readonly GetInterviewByIdRequest _interviewRequest;

            protected readonly GetInterviewByIdHandler _interviewHandler;

            protected GetInterviewByIdTest()
            {
                _interviewRequest = new GetInterviewByIdRequest()
                {
                    Id = 1
                };

                _interviewHandler = new GetInterviewByIdHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetInterviewByIdTest
        {

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
