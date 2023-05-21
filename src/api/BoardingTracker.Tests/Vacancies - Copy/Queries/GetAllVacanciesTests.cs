using BoardingTracker.Application.Vacancies.Queries.GetAllVacancies;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BoardingTracker.Application.Vacancies.Queries.GetAllVacancies.GetVacancies;

namespace BoardingTracker.Tests.Vacancies.Queries
{
    public abstract class GetAllVacanciesTests
    {
        public abstract class GetAllVacanciesTest : BaseTest
        {
            protected readonly GetVacancies _vacanciesRequest;

            protected readonly GetVacanciesHandler _vacanciesHandler;

            protected GetAllVacanciesTest()
            {
                _vacanciesRequest = new GetVacancies();

                _vacanciesHandler = new GetVacanciesHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetAllVacanciesTest
        {
            [Fact]
            public async Task VacancyList_is_returned_when_request_is_valid()
            {
                var result = await _vacanciesHandler.Handle(_vacanciesRequest, new CancellationToken());

                result.Items.Should().HaveCount(x => x >= 1);
            }
        }
    }
}
