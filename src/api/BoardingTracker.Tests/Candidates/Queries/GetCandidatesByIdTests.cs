using BoardingTracker.Application.Candidates.Models;
using BoardingTracker.Application.Candidates.Queries.GetCandidateById;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.Candidates.Queries
{
    public abstract class GetCandidateByIdTests
    {
        public abstract class GetCandidateByIdTest : BaseTest
        {
            protected readonly GetCandidateByIdRequest _candidateRequest;

            protected readonly GetCandidateByIdHandler _candidateHandler;

            protected GetCandidateByIdTest()
            {
                _candidateRequest = new GetCandidateByIdRequest()
                {
                    Id = 1
                };

                _candidateHandler = new GetCandidateByIdHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetCandidateByIdTest
        {
            [Fact]
            public async Task Candidate_model_is_returned_when_request_is_valid()
            {
                var expectedCandidate = new CandidateModel
                {
                    Id = 1,
                    FirstName = "TestName",
                    LastName = "TestName",
                    PhoneNumber = "TestPhone",
                    Biography = "TestBiography",
                    ResumeUrl = "TestResumeUrl",
                    UserId = 1,
                    Email = "TestEmail"
                };

                var result = await _candidateHandler.Handle(_candidateRequest, new CancellationToken());

                result.Should().BeEquivalentTo(expectedCandidate);
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
