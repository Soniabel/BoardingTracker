using BoardingTracker.Application.Candidates.Commands.UpdateCandidate;
using BoardingTracker.Application.Candidates.Models;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.Candidates.Commands
{
    public abstract class UpdateCandidateTests
    {
        public abstract class UpdateCandidateTest : BaseTest
        {
            protected readonly UpdateCandidateRequest _candidateRequest;

            protected readonly UpdateCandidateHandler _candidateHandler;

            protected UpdateCandidateTest()
            {
                _candidateRequest = new UpdateCandidateRequest()
                {
                    Id = 1,
                    FirstName = "TestName",
                    LastName = "TestName",
                    PhoneNumber = "TestPhone",
                    Biography = "TestBiography",
                    ResumeUrl = "TestResumeUrl",
                    UserId = 1
                };

                _candidateHandler = new UpdateCandidateHandler(_dbContext, _mapper);
            }
        }

        public class Handle : UpdateCandidateTest
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
                    UserId = 1
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
