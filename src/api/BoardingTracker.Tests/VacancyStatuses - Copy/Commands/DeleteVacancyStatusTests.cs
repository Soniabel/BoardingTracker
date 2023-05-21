using BoardingTracker.Application.VacancyStatuses.Commands.DeleteVacancyStatus;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.VacancyStatuses.Commands
{
    public abstract class DeleteVacancyStatusTests
    {
        public abstract class DeleteVacancyStatusTest : BaseTest
        {
            protected readonly DeleteVacancyStatusRequest _vacancyStatusRequest;

            protected readonly DeleteVacancyStatusHandler _vacancyStatusHandler;

            protected DeleteVacancyStatusTest()
            {
                _vacancyStatusRequest = new DeleteVacancyStatusRequest()
                {
                    Id = 2
                };

                _vacancyStatusHandler = new DeleteVacancyStatusHandler(_dbContext);
            }
        }

        public class Handle : DeleteVacancyStatusTest
        {
            [Fact]
            public async Task Deleted_Id_is_returned_when_request_is_valid()
            {
                var expectedId = 2;

                var result = await _vacancyStatusHandler.Handle(_vacancyStatusRequest, new CancellationToken());

                result.Should().Be(expectedId);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _vacancyStatusRequest.Id = 0;

                var result = _vacancyStatusHandler.Handle(_vacancyStatusRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
