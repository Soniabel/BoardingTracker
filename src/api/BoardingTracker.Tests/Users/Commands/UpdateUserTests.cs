using BoardingTracker.Application.Users.Commands.UpdateUser;
using BoardingTracker.Application.Users.Models;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.Users.Commands
{
    public abstract class UpdateUserTests
    {
        public abstract class UpdateUserTest : BaseTest
        {
            protected readonly UpdateUserRequest _userRequest;

            protected readonly UpdateUserHandler _userHandler;

            protected UpdateUserTest()
            {
                _userRequest = new UpdateUserRequest()
                {
                    Id = 1,
                    Email = "TestEmail",
                    Password = "TestPassword",
                    Role = "TestRole"
                };

                _userHandler = new UpdateUserHandler(_dbContext, _mapper);
            }
        }

        public class Handle : UpdateUserTest
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
