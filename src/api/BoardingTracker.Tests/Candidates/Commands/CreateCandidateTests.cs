using BoardingTracker.Application.Candidates.Commands.CreateCandidate;
using BoardingTracker.Application.Candidates.Models;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.Candidates.Commands
{
    public abstract class CreateCandidateTests
    {
        public abstract class CreateCandidateTest : BaseTest
        {
            protected readonly CreateCandidateRequest _candidateRequest;

            protected readonly CreateCandidateHandler _candidateHandler;

            protected CreateCandidateTest()
            {
                _candidateRequest = new CreateCandidateRequest()
                {
                    FirstName = "TestName",
                    LastName = "TestName",
                    PhoneNumber = "TestPhone",
                    Biography = "TestBiography",
                    ResumeUrl = "TestResumeUrl",
                    UserId = Guid.NewGuid()
                };

                _candidateHandler = new CreateCandidateHandler(_dbContext, _mapper);
            }
        }

        public class Handle : CreateCandidateTest
        {
            [Fact]
            public async Task Candidate_model_is_returned_when_request_is_valid()
            {
                var expectedCandidate = new CandidateModel
                {
                    Id = Guid.NewGuid(),
                    FirstName = "TestName",
                    LastName = "TestName",
                    PhoneNumber = "TestPhone",
                    Biography = "TestBiography",
                    ResumeUrl = "TestResumeUrl",
                    UserId = Guid.NewGuid()
                };
                var result = await _candidateHandler.Handle(_candidateRequest, new CancellationToken());

                result.Should().BeEquivalentTo(expectedCandidate);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _candidateRequest.FirstName = null;

                var result = _candidateHandler.Handle(_candidateRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
