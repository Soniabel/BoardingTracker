using BoardingTracker.Application.Recruiters.Queries.GetAllRecruiters;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BoardingTracker.Application.Recruiters.Queries.GetAllRecruiters.GetRecruiters;

namespace BoardingTracker.Tests.Recruiters.Queries
{
    public abstract class GetAllRecruitersTests
    {
        public abstract class GetAllRecruitersTest : BaseTest
        {
            protected readonly GetRecruiters _recruiterRequest;

            protected readonly GetRecruitersHandler _recruiterHandler;

            protected GetAllRecruitersTest()
            {
                _recruiterRequest = new GetRecruiters();

                _recruiterHandler = new GetRecruitersHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetAllRecruitersTest
        {
            [Fact]
            public async Task RecruiterList_is_returned_when_request_is_valid()
            {
                var result = await _recruiterHandler.Handle(_recruiterRequest, new CancellationToken());

                result.Items.Should().HaveCount(x => x >= 1);
            }
        }
    }
}
