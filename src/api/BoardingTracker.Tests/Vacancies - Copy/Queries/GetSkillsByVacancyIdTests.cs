using BoardingTracker.Application.Vacancies.Queries.GetVacancySkills;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.Vacancies.Queries
{
    public abstract class GetSkillsByVacancyIdTests
    {
        public abstract class GetSkillsByVacancyIdTest : BaseTest
        {
            protected readonly GetSkillsByVacancyIdRequest _vacancyIdRequest;

            protected readonly GetSkillsByVacancyIdHandler _vacancyIdHandler;

            protected GetSkillsByVacancyIdTest()
            {
                _vacancyIdRequest = new GetSkillsByVacancyIdRequest()
                {
                    Id = 1
                };

                _vacancyIdHandler = new GetSkillsByVacancyIdHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetSkillsByVacancyIdTest
        {
            [Fact]
            public async Task SkillsList_is_returned_when_request_is_valid()
            {
                var result = await _vacancyIdHandler.Handle(_vacancyIdRequest, new CancellationToken());

                result.Items.Should().HaveCount(x => x >= 1);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _vacancyIdRequest.Id = 0;

                var result = _vacancyIdHandler.Handle(_vacancyIdRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
