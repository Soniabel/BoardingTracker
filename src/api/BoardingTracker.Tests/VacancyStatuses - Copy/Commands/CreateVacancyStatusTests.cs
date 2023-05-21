using BoardingTracker.Application.VacancyStatuses.Commands.CreateVacancyStatus;
using BoardingTracker.Application.VacancyStatuses.Models;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.VacancyStatuses.Commands
{
    public abstract class CreateVacancyStatusTests
    {
        public abstract class CreateVacancyStatusTest : BaseTest
        {
            protected readonly CreateVacancyStatusRequest _vacancyStatusRequest;

            protected readonly CreateVacancyStatusHandler _vacancyStatusHandler;

            protected CreateVacancyStatusTest()
            {
                _vacancyStatusRequest = new CreateVacancyStatusRequest()
                {
                    Name = "TestName"
                };

                _vacancyStatusHandler = new CreateVacancyStatusHandler(_dbContext, _mapper);
            }
        }

        public class Handle : CreateVacancyStatusTest
        {
            [Fact]
            public async Task VacancyStatus_model_is_returned_when_request_is_valid()
            {
                var expectedVacancyStatus = new VacancyStatusModel
                {
                    Id = 3,
                    Name = "TestName"
                };
                var result = await _vacancyStatusHandler.Handle(_vacancyStatusRequest, new CancellationToken());

                result.Should().BeEquivalentTo(expectedVacancyStatus);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _vacancyStatusRequest.Name = null;

                var result = _vacancyStatusHandler.Handle(_vacancyStatusRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
