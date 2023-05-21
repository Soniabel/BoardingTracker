using BoardingTracker.Application.VacancyTypes.Models;
using BoardingTracker.Application.VacancyTypes.Queries.GetVacancyTypesById;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.VacancyTypes.Queries
{
    public abstract class GetVacancyTypeByIdTests
    {
        public abstract class GetVacancyTypeByIdTest : BaseTest
        {
            protected readonly GetVacancyTypeByIdRequest _vacancyTypeRequest;

            protected readonly GetVacancyTypeByIdHandler _vacancyTypeHandler;

            protected GetVacancyTypeByIdTest()
            {
                _vacancyTypeRequest = new GetVacancyTypeByIdRequest()
                {
                    Id = 1
                };

                _vacancyTypeHandler = new GetVacancyTypeByIdHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetVacancyTypeByIdTest
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
