using BoardingTracker.Application.Users.Models;
using BoardingTracker.Application.Users.Queries.GetUserById;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.Users.Queries
{
    public abstract class GetUserByIdTests
    {
        public abstract class GetUserByIdTest : BaseTest
        {
            protected readonly GetUserByIdRequest _userRequest;

            protected readonly GetUserByIdHandler _userHandler;

            protected GetUserByIdTest()
            {
                var existingUser = _dbContext.Userss.FirstOrDefault();
                _userRequest = new GetUserByIdRequest()
                {
                    Id = existingUser.Id
                };

                _userHandler = new GetUserByIdHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetUserByIdTest
        {

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _userRequest.Id = Guid.Empty;

                var result = _userHandler.Handle(_userRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
