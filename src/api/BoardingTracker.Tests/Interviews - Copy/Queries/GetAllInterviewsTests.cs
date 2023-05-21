using BoardingTracker.Application.Interviews.Queries.GetAllInterviews;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BoardingTracker.Application.Interviews.Queries.GetAllInterviews.GetInterviews;

namespace BoardingTracker.Tests.Interviews.Queries
{
    public abstract class GetAllInterviewsTests
    {
        public abstract class GetAllInterviewsTest : BaseTest
        {
            protected readonly GetInterviews _interviews;

            protected readonly GetInterviewsHandler _interviewHandler;

            protected GetAllInterviewsTest()
            {
                _interviews = new GetInterviews();

                _interviewHandler = new GetInterviewsHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetAllInterviewsTest
        {
            [Fact]
            public async Task InterviewTypeList_is_returned_when_request_is_valid()
            {
                var result = await _interviewHandler.Handle(_interviews, new CancellationToken());

                result.Items.Should().HaveCount(x => x >= 1);
            }
        }
    }
}
