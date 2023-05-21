using BoardingTracker.Application.Candidates.Queries.GetCandidateSkill;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.Candidates.Queries
{
    public abstract class GetSkillsByCandidateIdTests
    {
        public abstract class GetSkillsByCandidateIdTest : BaseTest
        {
            protected readonly GetSkillsByCandidateIdRequest _candidateIdRequest;

            protected readonly GetSkillsByCandidateIdHandler _candidateIdHandler;

            protected GetSkillsByCandidateIdTest()
            {
                _candidateIdRequest = new GetSkillsByCandidateIdRequest()
                {
                    Id = Guid.NewGuid()
                };

                _candidateIdHandler = new GetSkillsByCandidateIdHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetSkillsByCandidateIdTest
        {
            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _candidateIdRequest.Id = Guid.Empty;

                var result = _candidateIdHandler.Handle(_candidateIdRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
