using BoardingTracker.Application.Recruiters.Models;
using BoardingTracker.Application.SeniorityLevels.Models;
using BoardingTracker.Application.Vacancies.Commands.CreateVacancy;
using BoardingTracker.Application.Vacancies.Models;
using BoardingTracker.Application.VacancyStatuses.Models;
using BoardingTracker.Application.VacancyTypes.Models;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
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
                    RecruiterId = 1
                };

                _vacancyHandler = new CreateVacancyHandler(_dbContext, _mapper);
            }
        }

        public class Handle : CreateVacancyRequestTest
        {
            [Fact]
            public async Task Vacancy_model_is_returned_when_request_is_valid()
            {
                var expectedVacancy = new VacancyModel
                {
                    Id = 3,
                    Title = "TestTitle",
                    Description = "TestDescription",
                    Salary = 1234,
                    SeniorityLevel = new SeniorityLevelModel { Id = 1, Name = "TestName" },
                    VacancyType = new VacancyTypeModel { Id = 1, Name = "TestName" },
                    VacancyStatus = new VacancyStatusModel { Id = 1, Name = "TestName" },
                    Recruiter = new RecruiterModel
                    {
                        Id = 1,
                        FirstName = "TestFirstName",
                        LastName = "TestLastName",
                        ProfileImageUrl = "TestImage",
                        UserId = 1
                    }
                };
                var result = await _vacancyHandler.Handle(_vacancyRequest, new CancellationToken());

                result.Should().BeEquivalentTo(expectedVacancy);
            }

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
