using BoardingTracker.Application.Recruiters.Models;
using BoardingTracker.Application.SeniorityLevels.Models;
using BoardingTracker.Application.Vacancies.Commands.CreateVacancy;
using BoardingTracker.Application.Vacancies.Models;
using BoardingTracker.Application.VacancyStatuses.Models;
using BoardingTracker.Application.VacancyTypes.Models;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.Vacancies.Commands
{
    public abstract class CreateVacancyTests
    {
        public abstract class CreateVacancyRequestTest : BaseTest
        {
            protected readonly CreateVacancyRequest _vacancyRequest;

            protected readonly CreateVacancyHandler _vacancyHandler;

            protected CreateVacancyRequestTest()
            {
                _vacancyRequest = new CreateVacancyRequest()
                {
                    Title = "TestTitle",
                    Description = "TestDescription",
                    Salary = 1234,
                    SeniorityLevelId = 1,
                    VacancyTypeId = 1,
                    VacancyStatusId = 1,
                    RecruiterId = Guid.NewGuid()
                };

                _vacancyHandler = new CreateVacancyHandler(_dbContext, _mapper);
            }
        }

        public class Handle : CreateVacancyRequestTest
        {

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _vacancyRequest.Title = null;

                var result = _vacancyHandler.Handle(_vacancyRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
