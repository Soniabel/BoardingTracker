using BoardingTracker.Application.Recruiters.Commands.UpdateRecruiter;
using BoardingTracker.Application.Recruiters.Models;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.Recruiters.Commands
{
    public abstract class UpdateRecruiterTests
    {
        public abstract class UpdateRecruiterTest : BaseTest
        {
            protected readonly UpdateRecruiterRequest _recruiterRequest;

            protected readonly UpdateRecruiterHandler _recruiterHandler;

            protected UpdateRecruiterTest()
            {
                _recruiterRequest = new UpdateRecruiterRequest()
                {
                    Id = 1,
                    FirstName = "TestFirstName",
                    LastName = "TestLastName",
                    ProfileImageUrl = "TestImage",
                    UserId = 1
                };

                _recruiterHandler = new UpdateRecruiterHandler(_dbContext, _mapper);
            }
        }

        public class Handle : UpdateRecruiterTest
        {
            [Fact]
            public async Task Recruiter_model_is_returned_when_request_is_valid()
            {
                var expectedRecruiter = new RecruiterModel
                {
                    Id = 1,
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
                _recruiterRequest.Id = 0;

                var result = _recruiterHandler.Handle(_recruiterRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
