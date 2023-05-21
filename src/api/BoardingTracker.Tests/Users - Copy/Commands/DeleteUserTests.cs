using BoardingTracker.Application.Users.Commands.DeleteUser;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.Users.Commands
{
    public abstract class DeleteUserTests
    {
        public abstract class DeleteUserTest : BaseTest
        {
            protected readonly DeleteUserRequest _userRequest;

            protected readonly DeleteUserHandler _userHandler;

            protected DeleteUserTest()
            {
                var existingUser = _dbContext.Userss.FirstOrDefault();
                _userRequest = new DeleteUserRequest()
                {
                    Id = existingUser.Id
                };

                _userHandler = new DeleteUserHandler(_dbContext);
            }
        }

        public class Handle : DeleteUserTest
        {
            [Fact]
            public async Task Deleted_Id_is_returned_when_request_is_valid()
            {
                var expectedId = _userRequest.Id;

                var result = await _userHandler.Handle(_userRequest, new CancellationToken());

                result.Should().Be(expectedId);
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
