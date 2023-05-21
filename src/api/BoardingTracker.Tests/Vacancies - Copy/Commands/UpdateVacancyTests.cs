using BoardingTracker.Application.Recruiters.Models;
using BoardingTracker.Application.SeniorityLevels.Models;
using BoardingTracker.Application.Vacancies.Commands.UpdateVacancy;
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
    public abstract class UpdateVacancyTests
    {
        public abstract class UpdateVacancyTest : BaseTest
        {
            protected readonly UpdateVacancyRequest _vacancyRequest;

            protected readonly UpdateVacancyHandler _vacancyHandler;

            protected UpdateVacancyTest()
            {
                _vacancyRequest = new UpdateVacancyRequest()
                {
                    Id = 1,
                    Title = "TestTitle",
                    Description = "TestDescription",
                    Salary = 1234,
                    SeniorityLevelId = 1,
                    VacancyTypeId = 1,
                    VacancyStatusId = 1,
                    RecruiterId = Guid.NewGuid()
                };

                _vacancyHandler = new UpdateVacancyHandler(_dbContext, _mapper);
            }
        }

        public class Handle : UpdateVacancyTest
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
