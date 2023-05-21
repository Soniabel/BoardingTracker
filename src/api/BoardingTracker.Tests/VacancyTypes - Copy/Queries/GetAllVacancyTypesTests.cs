using BoardingTracker.Application.VacancyTypes.Queries.GetAllVacancyTypes;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BoardingTracker.Application.VacancyTypes.Queries.GetAllVacancyTypes.GetVacancyTypes;

namespace BoardingTracker.Tests.VacancyTypes.Queries
{
    public abstract class GetAllVacancyTypesTests
    {
        public abstract class GetAllVacancyTypesTest : BaseTest
        {
            protected readonly GetVacancyTypes _vacancyTypeRequest;

            protected readonly GetVacancyTypesHandler _vacancyTypeHandler;

            protected GetAllVacancyTypesTest()
            {
                _vacancyTypeRequest = new GetVacancyTypes();

                _vacancyTypeHandler = new GetVacancyTypesHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetAllVacancyTypesTest
        {
            [Fact]
            public async Task VacancyTypeList_is_returned_when_request_is_valid()
            {
                var result = await _vacancyTypeHandler.Handle(_vacancyTypeRequest, new CancellationToken());

                result.Items.Should().HaveCount(x => x >= 1);
            }
        }
    }
}
