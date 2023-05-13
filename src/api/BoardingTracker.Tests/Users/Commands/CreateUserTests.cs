using BoardingTracker.Application.Users.Commands.CreateUser;
using BoardingTracker.Application.Users.Models;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.Users.Commands
{
    public abstract class CreateUserTests
    {
        public abstract class CreateUserTest : BaseTest
        {
            protected readonly CreateUserRequest _userRequest;

            protected readonly CreateUserHandler _userHandler;

            protected CreateUserTest()
            {
                _userRequest = new CreateUserRequest()
                {
                    Email = "TestEmail",
                    Password = "TestPassword",
                    Role = "TestRole"
                };

                _userHandler = new CreateUserHandler(_dbContext, _mapper);
            }
        }

        public class Handle : CreateUserTest
        {
            [Fact]
            public async Task User_model_is_returned_when_request_is_valid()
            {
                var expectedUser = new UserModel
                {
                    Id = 3,
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
                _userRequest.Email = null;

                var result = _userHandler.Handle(_userRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
