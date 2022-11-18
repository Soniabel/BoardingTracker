using BoardingTracker.Application.Candidates.Commands.DeleteCandidate;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.Candidates.Commands
{
    public abstract class DeleteCandidateTests
    {
        public abstract class DeleteCandidateTest : BaseTest
        {
            protected readonly DeleteCandidateRequest _candidateRequest;

            protected readonly DeleteCandidateHandler _candidateHandler;

            protected DeleteCandidateTest()
            {
                _candidateRequest = new DeleteCandidateRequest()
                {
                    Id = 2
                };

                _candidateHandler = new DeleteCandidateHandler(_dbContext);
            }
        }

        public class Handle : DeleteCandidateTest
        {
            [Fact]
            public async Task Deleted_Id_is_returned_when_request_is_valid()
            {
                var expectedId = 2;

                var result = await _candidateHandler.Handle(_candidateRequest, new CancellationToken());

                result.Should().Be(expectedId);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _candidateRequest.Id = 0;

                var result = _candidateHandler.Handle(_candidateRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
