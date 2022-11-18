using BoardingTracker.Application.Recruiters.Commands.CreateRecruiter;
using BoardingTracker.Application.Recruiters.Models;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.Recruiters.Commands
{
    public abstract class CreateRecruiterTests
    {
        public abstract class CreateRecruiterTest : BaseTest
        {
            protected readonly CreateRecruiterRequest _recruiterRequest;

            protected readonly CreateRecruiterHandler _recruiterHandler;

            protected CreateRecruiterTest()
            {
                _recruiterRequest = new CreateRecruiterRequest()
                {
                    FirstName = "TestFirstName",
                    LastName = "TestLastName",
                    ProfileImageUrl = "TestImage",
                    UserId = 1
                };

                _recruiterHandler = new CreateRecruiterHandler(_dbContext, _mapper);
            }
        }

        public class Handle : CreateRecruiterTest
        {
            [Fact]
            public async Task Recruiter_model_is_returned_when_request_is_valid()
            {
                var expectedRecruiter = new RecruiterModel
                {
                    Id = 3,
                    FirstName = "TestFirstName",
                    LastName = "TestLastName",
                    ProfileImageUrl = "TestImage",
                    UserId = 1
                };

                var result = await _recruiterHandler.Handle(_recruiterRequest, new CancellationToken());

                result.Should().BeEquivalentTo(expectedRecruiter);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _recruiterRequest.FirstName = null;

                var result = _recruiterHandler.Handle(_recruiterRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
