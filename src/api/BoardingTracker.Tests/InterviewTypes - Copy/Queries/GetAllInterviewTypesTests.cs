using BoardingTracker.Application.InterviewTypes.Queries.GetAllInterviewTypes;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BoardingTracker.Application.InterviewTypes.Queries.GetAllInterviewTypes.GetInterviewTypes;

namespace BoardingTracker.Tests.InterviewTypes.Queries
{
    public abstract class GetAllInterviewTypesTests
    {
        public abstract class GetAllInterviewTypesTest : BaseTest
        {
            protected readonly GetInterviewTypes _interviewTypes;

            protected readonly GetInterviewTypesHandler _interviewTypeHandler;

            protected GetAllInterviewTypesTest()
            {
                _interviewTypes = new GetInterviewTypes();

                _interviewTypeHandler = new GetInterviewTypesHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetAllInterviewTypesTest
        {
            [Fact]
            public async Task InterviewList_is_returned_when_request_is_valid()
            {
                var result = await _interviewTypeHandler.Handle(_interviewTypes, new CancellationToken());

                result.Items.Should().HaveCount(x => x >= 1);
            }
        }
    }
}
