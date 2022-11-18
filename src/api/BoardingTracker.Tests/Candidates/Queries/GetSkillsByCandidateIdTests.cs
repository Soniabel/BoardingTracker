using BoardingTracker.Application.Candidates.Queries.GetCandidateSkill;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
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
                    Id = 1
                };

                _candidateIdHandler = new GetSkillsByCandidateIdHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetSkillsByCandidateIdTest
        {
            [Fact]
            public async Task SkillsList_is_returned_when_request_is_valid()
            {
                var result = await _candidateIdHandler.Handle(_candidateIdRequest, new CancellationToken());

                result.Items.Should().HaveCount(x => x >= 1);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _candidateIdRequest.Id = 0;

                var result = _candidateIdHandler.Handle(_candidateIdRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
