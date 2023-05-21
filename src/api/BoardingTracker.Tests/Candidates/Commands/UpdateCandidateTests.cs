using BoardingTracker.Application.Candidates.Commands.UpdateCandidate;
using BoardingTracker.Application.Candidates.Models;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System;
using System.Linq;
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
                var existingCandidate = _dbContext.Candidates.FirstOrDefault();
                _candidateRequest = new UpdateCandidateRequest()
                {
                    Id = existingCandidate.Id,
                    FirstName = "TestName",
                    LastName = "TestName",
                    PhoneNumber = "TestPhone",
                    Biography = "TestBiography",
                    ResumeUrl = "TestResumeUrl",
                    UserId = Guid.NewGuid()
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
                    Id = _candidateRequest.Id,
                    FirstName = "TestName",
                    LastName = "TestName",
                    PhoneNumber = "TestPhone",
                    Biography = "TestBiography",
                    ResumeUrl = "TestResumeUrl",
                    UserId = _candidateRequest.UserId
                };
                var result = await _candidateHandler.Handle(_candidateRequest, new CancellationToken());

                result.Should().BeEquivalentTo(expectedCandidate);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _candidateRequest.Id = Guid.Empty;

                var result = _candidateHandler.Handle(_candidateRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
