using BoardingTracker.Application.Recruiters.Models;
using BoardingTracker.Application.Recruiters.Queries.GetRecruitersById;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System;
using System.Linq;
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
                var existingRecruiter = _dbContext.Recruiters.FirstOrDefault();
                _recruiterRequest = new GetRecruiterByIdRequest()
                {
                    Id = existingRecruiter.Id
                };

                _recruiterHandler = new GetRecruiterByIdHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetRecruiterByIdTest
        {

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _recruiterRequest.Id = Guid.Empty;

                var result = _recruiterHandler.Handle(_recruiterRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
