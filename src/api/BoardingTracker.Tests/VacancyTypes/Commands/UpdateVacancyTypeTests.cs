using BoardingTracker.Application.VacancyTypes.Commands.UpdateVacancyType;
using BoardingTracker.Application.VacancyTypes.Models;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.VacancyTypes.Commands
{
    public abstract class UpdateVacancyTypeTests
    {
        public abstract class UpdateVacancyTypeTest : BaseTest
        {
            protected readonly UpdateVacancyTypeRequest _vacancyTypeRequest;

            protected readonly UpdateVacancyTypeHandler _vacancyTypeHandler;

            protected UpdateVacancyTypeTest()
            {
                _vacancyTypeRequest = new UpdateVacancyTypeRequest()
                {
                    Id = 1,
                    Name = "TestName"
                };

                _vacancyTypeHandler = new UpdateVacancyTypeHandler(_dbContext, _mapper);
            }
        }

        public class Handle : UpdateVacancyTypeTest
        {
            [Fact]
            public async Task VacancyType_model_is_returned_when_request_is_valid()
            {
                var expectedVacancyType = new VacancyTypeModel
                {
                    Id = 1,
                    Name = "TestName"
                };
                var result = await _vacancyTypeHandler.Handle(_vacancyTypeRequest, new CancellationToken());

                result.Should().BeEquivalentTo(expectedVacancyType);
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
