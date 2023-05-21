using BoardingTracker.Application.VacancyStatuses.Models;
using BoardingTracker.Application.VacancyStatuses.Queries.GetVacancyStatusesById;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.VacancyStatuses.Queries
{
    public abstract class GetVacancyStatusByIdTests
    {
        public abstract class GetVacancyStatusByIdTest : BaseTest
        {
            protected readonly GetVacancyStatusByIdRequest _vacancyStatusRequest;

            protected readonly GetVacancyStatusByIdHandler _vacancyStatusHandler;

            protected GetVacancyStatusByIdTest()
            {
                _vacancyStatusRequest = new GetVacancyStatusByIdRequest()
                {
                    Id = 1
                };

                _vacancyStatusHandler = new GetVacancyStatusByIdHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetVacancyStatusByIdTest
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
