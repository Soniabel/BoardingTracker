using BoardingTracker.Application.Candidates.Models;
using BoardingTracker.Application.Candidates.Queries.GetCandidateById;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System;
using System.Linq;
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
                var existingCandidate = _dbContext.Candidates.FirstOrDefault();
                _candidateRequest = new GetCandidateByIdRequest()
                {
                    Id = existingCandidate.Id
                };

                _candidateHandler = new GetCandidateByIdHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetCandidateByIdTest
        {

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
