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

                var result = await _candidateHandler.Handle(_candidateRequest, new CancellationToken());

                result.Should().NotBeNull();
                result.FirstName.Should().Be(_candidateRequest.FirstName);
                result.LastName.Should().Be(_candidateRequest.LastName);
                result.PhoneNumber.Should().Be(_candidateRequest.PhoneNumber);
                result.Biography.Should().Be(_candidateRequest.Biography);
                result.ResumeUrl.Should().Be(_candidateRequest.ResumeUrl);
                result.UserId.Should().Be(_candidateRequest.UserId);
                //var expectedCandidate = new CandidateModel
                //{
                //    Id = _candidateHandler.,
                //    FirstName = "TestName",
                //    LastName = "TestName",
                //    PhoneNumber = "TestPhone",
                //    Biography = "TestBiography",
                //    ResumeUrl = "TestResumeUrl",
                //    UserId = _candidateRequest.UserId
                //};
                //var result = await _candidateHandler.Handle(_candidateRequest, new CancellationToken());

                //result.Should().BeEquivalentTo(expectedCandidate);
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
