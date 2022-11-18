using BoardingTracker.Application.Users.Models;
using BoardingTracker.Application.Users.Queries.GetUserById;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
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
                _userRequest = new GetUserByIdRequest()
                {
                    Id = 1
                };

                _userHandler = new GetUserByIdHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetUserByIdTest
        {
            [Fact]
            public async Task User_model_is_returned_when_request_is_valid()
            {
                var expectedUser = new UserModel
                {
                    Id = 1,
                    Email = "TestEmail",
                    Password = "TestPassword",
                    Role = "TestRole"
                };

                var result = await _userHandler.Handle(_userRequest, new CancellationToken());

                result.Should().BeEquivalentTo(expectedUser);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _userRequest.Id = 0;

                var result = _userHandler.Handle(_userRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
