using BoardingTracker.Application.VacancyTypes.Commands.CreateVacancyType;
using BoardingTracker.Application.VacancyTypes.Models;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.VacancyTypes.Commands
{
    public abstract class CreateVacancyTypeTests
    {
        public abstract class CreateVacancyTypeTest : BaseTest
        {
            protected readonly CreateVacancyTypeRequest _vacancyTypeRequest;

            protected readonly CreateVacancyTypeHandler _vacancyTypeHandler;

            protected CreateVacancyTypeTest()
            {
                _vacancyTypeRequest = new CreateVacancyTypeRequest()
                {
                    Name = "TestName"
                };

                _vacancyTypeHandler = new CreateVacancyTypeHandler(_dbContext, _mapper);
            }
        }

        public class Handle : CreateVacancyTypeTest
        {
            [Fact]
            public async Task VacancyType_model_is_returned_when_request_is_valid()
            {
                var expectedVacancyType = new VacancyTypeModel
                {
                    Id = 3,
                    Name = "TestName"
                };
                var result = await _vacancyTypeHandler.Handle(_vacancyTypeRequest, new CancellationToken());

                result.Should().BeEquivalentTo(expectedVacancyType);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _vacancyTypeRequest.Name = null;

                var result = _vacancyTypeHandler.Handle(_vacancyTypeRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
