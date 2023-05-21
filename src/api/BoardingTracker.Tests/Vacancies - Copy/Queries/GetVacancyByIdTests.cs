using BoardingTracker.Application.Recruiters.Models;
using BoardingTracker.Application.SeniorityLevels.Models;
using BoardingTracker.Application.Vacancies.Models;
using BoardingTracker.Application.Vacancies.Queries.GetVacanciesById;
using BoardingTracker.Application.VacancyStatuses.Models;
using BoardingTracker.Application.VacancyTypes.Models;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.Vacancies.Queries
{
    public abstract class GetVacancyByIdTests
    {
        public abstract class GetVacancyByIdTest : BaseTest
        {
            protected readonly GetVacancyByIdRequest _vacancyRequest;

            protected readonly GetVacancyByIdHandler _vacancyHandler;

            protected GetVacancyByIdTest()
            {
                _vacancyRequest = new GetVacancyByIdRequest()
                {
                    Id = 1
                };

                _vacancyHandler = new GetVacancyByIdHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetVacancyByIdTest
        {

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
