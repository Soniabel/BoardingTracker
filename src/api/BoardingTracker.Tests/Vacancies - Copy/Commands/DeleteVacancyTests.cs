using BoardingTracker.Application.Vacancies.Commands.DeleteVacancy;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.Vacancies.Commands
{
    public abstract class DeleteVacancyTests
    {
        public abstract class DeleteVacancyTest : BaseTest
        {
            protected readonly DeleteVacancyRequest _vacancyRequest;

            protected readonly DeleteVacancyHandler _vacancyHandler;

            protected DeleteVacancyTest()
            {
                _vacancyRequest = new DeleteVacancyRequest()
                {
                    Id = 2
                };

                _vacancyHandler = new DeleteVacancyHandler(_dbContext);
            }
        }

        public class Handle : DeleteVacancyTest
        {
            [Fact]
            public async Task Deleted_Id_is_returned_when_request_is_valid()
            {
                var expectedId = 2;

                var result = await _vacancyHandler.Handle(_vacancyRequest, new CancellationToken());

                result.Should().Be(expectedId);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _vacancyRequest.Id = 0;

                var result = _vacancyHandler.Handle(_vacancyRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
