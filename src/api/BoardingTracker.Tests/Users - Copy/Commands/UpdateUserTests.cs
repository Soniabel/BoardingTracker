using BoardingTracker.Application.Users.Commands.UpdateUser;
using BoardingTracker.Application.Users.Models;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System;
using System.Linq;
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
                var existingUser = _dbContext.Userss.FirstOrDefault();
                _userRequest = new UpdateUserRequest()
                {
                    Id = existingUser.Id,
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
                    Id = _userRequest.Id,
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
                _userRequest.Id = Guid.Empty;

                var result = _userHandler.Handle(_userRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
