using BoardingTracker.Application.VacancyTypes.Commands.DeleteVacancyType;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.VacancyTypes.Commands
{
    public abstract class DeleteVacancyTypeTests
    {
        public abstract class DeleteVacancyTypeTest : BaseTest
        {
            protected readonly DeleteVacancyTypeRequest _vacancyTypeRequest;

            protected readonly DeleteVacancyTypeHandler _vacancyTypeHandler;

            protected DeleteVacancyTypeTest()
            {
                _vacancyTypeRequest = new DeleteVacancyTypeRequest()
                {
                    Id = 2
                };

                _vacancyTypeHandler = new DeleteVacancyTypeHandler(_dbContext);
            }
        }

        public class Handle : DeleteVacancyTypeTest
        {
            [Fact]
            public async Task Deleted_Id_is_returned_when_request_is_valid()
            {
                var expectedId = 2;

                var result = await _vacancyTypeHandler.Handle(_vacancyTypeRequest, new CancellationToken());

                result.Should().Be(expectedId);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _vacancyTypeRequest.Id = 0;

                var result = _vacancyTypeHandler.Handle(_vacancyTypeRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
