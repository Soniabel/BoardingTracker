using BoardingTracker.Application.Candidates.Queries.GetAllCandidates;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BoardingTracker.Application.Candidates.Queries.GetAllCandidates.GetCandidates;

namespace BoardingTracker.Tests.Candidates.Queries
{
    public abstract class GetAllCandidatesTests
    {
        public abstract class GetAllCandidatesTest : BaseTest
        {
            protected readonly GetCandidates _candidateTypes;

            protected readonly GetCandidatesHandler _candidateHandler;

            protected GetAllCandidatesTest()
            {
                _candidateTypes = new GetCandidates();

                _candidateHandler = new GetCandidatesHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetAllCandidatesTest
        {
            [Fact]
            public async Task CandidateList_is_returned_when_request_is_valid()
            {
                var result = await _candidateHandler.Handle(_candidateTypes, new CancellationToken());

                result.Items.Should().HaveCount(x => x >= 1);
            }
        }
    }
}
