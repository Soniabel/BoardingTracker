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
                    RecruiterId = Guid.NewGuid(),
                    CandidateId = Guid.NewGuid(),
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
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _interviewRequest.Title = null;

                var result = _interviewHandler.Handle(_interviewRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
