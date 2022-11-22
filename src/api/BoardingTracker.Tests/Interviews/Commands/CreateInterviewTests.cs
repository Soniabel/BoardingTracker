using BoardingTracker.Application.Candidates.Models;
using BoardingTracker.Application.Interviews.Commands.CreateInterview;
using BoardingTracker.Application.Interviews.Models;
using BoardingTracker.Application.InterviewTypes.Models;
using BoardingTracker.Application.Recruiters.Models;
using BoardingTracker.Application.SeniorityLevels.Models;
using BoardingTracker.Application.Vacancies.Models;
using BoardingTracker.Application.VacancyStatuses.Models;
using BoardingTracker.Application.VacancyTypes.Models;
using BoardingTracker.Infrastructure.SendGrid.Interfaces;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.Interviews.Commands
{
    public abstract class CreateInterviewTests
    {
        public abstract class CreateInterviewTest : BaseTest
        {
            protected readonly CreateInterviewRequest _interviewRequest;

            protected readonly CreateInterviewHandler _interviewHandler;

            private readonly Mock<IEmailSender> _emailSender = new();

            protected CreateInterviewTest()
            {
                _interviewRequest = new CreateInterviewRequest()
                {
                    Title = "TestTitle",
                    StartTime = new DateTime(2022, 12, 12),
                    EndTime = new DateTime(2022, 12, 12),
                    VacancyId = 1,
                    RecruiterId = 1,
                    CandidateId = 1,
                    InterviewTypeId = 1
                };

                var emails = new List<string>();

                _emailSender.Setup(x => x.SendEmailAsync(emails));

                _interviewHandler = new CreateInterviewHandler(_dbContext, _mapper, _emailSender.Object);
            }
        }

        public class Handle : CreateInterviewTest
        {
            [Fact]
            public async Task Interview_model_is_returned_when_request_is_valid()
            {
                var expectedInterview = new InterviewModel
                {
                    Id = 2,
                    Title = "TestTitle",
                    StartTime = new DateTime(2022, 12, 12),
                    EndTime = new DateTime(2022, 12, 12),
                    Vacancy = new VacancyModel
                    {
                        Id = 1,
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
                    },
                    Recruiter = new RecruiterModel
                    {
                        Id = 1,
                        FirstName = "TestFirstName",
                        LastName = "TestLastName",
                        ProfileImageUrl = "TestImage",
                        UserId = 1
                    },
                    Candidate = new CandidateModel
                    {
                        Id = 1,
                        FirstName = "TestName",
                        LastName = "TestName",
                        PhoneNumber = "TestPhone",
                        Biography = "TestBiography",
                        ResumeUrl = "TestResumeUrl",
                        UserId = 1
                    },
                    InterviewType = new InterviewTypeModel { Id = 1, Name = "TestName" }
                };
                var result = await _interviewHandler.Handle(_interviewRequest, new CancellationToken());

                result.Should().BeEquivalentTo(expectedInterview);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _interviewRequest.Title = null;

                var result = _interviewHandler.Handle(_interviewRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
