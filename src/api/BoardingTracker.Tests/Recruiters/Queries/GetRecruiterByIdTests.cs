using BoardingTracker.Application.Recruiters.Models;
using BoardingTracker.Application.Recruiters.Queries.GetRecruitersById;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.Recruiters.Queries
{
    public abstract class GetRecruiterByIdTests
    {
        public abstract class GetRecruiterByIdTest : BaseTest
        {
            protected readonly GetRecruiterByIdRequest _recruiterRequest;

            protected readonly GetRecruiterByIdHandler _recruiterHandler;

            protected GetRecruiterByIdTest()
            {
                _recruiterRequest = new GetRecruiterByIdRequest()
                {
                    Id = 1
                };

                _recruiterHandler = new GetRecruiterByIdHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetRecruiterByIdTest
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
