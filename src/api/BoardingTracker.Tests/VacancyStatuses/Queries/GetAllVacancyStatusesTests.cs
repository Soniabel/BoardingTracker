using BoardingTracker.Application.VacancyStatuses.Queries.GetAllVacancyStatuses;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BoardingTracker.Application.VacancyStatuses.Queries.GetAllVacancyStatuses.GetVacancyStatuses;

namespace BoardingTracker.Tests.VacancyStatuses.Queries
{
    public abstract class GetAllVacancyStatusesTests
    {
        public abstract class GetAllVacancyStatusesTest : BaseTest
        {
            protected readonly GetVacancyStatuses _vacancyStatusRequest;

            protected readonly GetVacancyStatusesHandler _vacancyStatusHandler;

            protected GetAllVacancyStatusesTest()
            {
                _vacancyStatusRequest = new GetVacancyStatuses();

                _vacancyStatusHandler = new GetVacancyStatusesHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetAllVacancyStatusesTest
        {
            [Fact]
            public async Task VacancyStatusList_is_returned_when_request_is_valid()
            {
                var result = await _vacancyStatusHandler.Handle(_vacancyStatusRequest, new CancellationToken());

                result.Items.Should().HaveCount(x => x >= 1);
            }
        }
    }
}
