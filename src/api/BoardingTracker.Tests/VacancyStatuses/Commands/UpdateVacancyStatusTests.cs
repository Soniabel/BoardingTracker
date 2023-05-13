using BoardingTracker.Application.VacancyStatuses.Commands.UpdateVacancyStatus;
using BoardingTracker.Application.VacancyStatuses.Models;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.VacancyStatuses.Commands
{
    public abstract class UpdateVacancyStatusTests
    {
        public abstract class UpdateVacancyStatusTest : BaseTest
        {
            protected readonly UpdateVacancyStatusRequest _vacancyStatusRequest;

            protected readonly UpdateVacancyStatusHandler _vacancyStatusHandler;

            protected UpdateVacancyStatusTest()
            {
                _vacancyStatusRequest = new UpdateVacancyStatusRequest()
                {
                    Id = 1,
                    Name = "TestName"
                };

                _vacancyStatusHandler = new UpdateVacancyStatusHandler(_dbContext, _mapper);
            }
        }

        public class Handle : UpdateVacancyStatusTest
        {
            [Fact]
            public async Task VacancyStatus_model_is_returned_when_request_is_valid()
            {
                var expectedVacancyStatus = new VacancyStatusModel
                {
                    Id = 1,
                    Name = "TestName"
                };
                var result = await _vacancyStatusHandler.Handle(_vacancyStatusRequest, new CancellationToken());

                result.Should().BeEquivalentTo(expectedVacancyStatus);
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
